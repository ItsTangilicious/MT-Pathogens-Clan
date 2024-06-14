using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using CustomEffectsPathogens;
using Trainworks.Interfaces;
using Trainworks.ConstantsV2;
using Trainworks.AssetConstructors;
using ShinyShoe;
using static UnityEngine.TouchScreenKeyboard;
using Trainworks.Managers;





namespace CustomEffectsPathogens
{

    public class StatusEffectContagion : StatusEffectState, IDamageStatusEffect
    {
        public static StatusEffectData data;
        public const string statusID = "status_contagion";
        private CharacterState associatedCharacter;
        private CombatManager combatManager;
        int stacks;


        public static void Build()
        {
            data = new StatusEffectDataBuilder()
            {
                StatusEffectStateType = typeof(StatusEffectContagion),
                StatusID = statusID,
                IsStackable = true,
                IconPath = "AssetsAll/ClanAssets/ContagionLarge.png",
                TooltipIconPath = "AssetsAll/ClanAssets/ContagionSmall.png",
                TriggerStage = StatusEffectData.TriggerStage.OnPostCombatPoison,
                DisplayCategory = StatusEffectData.DisplayCategory.Negative,
                ShowStackCount = true,
                RemoveAtEndOfTurn = false,
                RemoveWhenTriggered = false,
                //Description = "At the end of turn, each unit with Contagion applies Contagion 1 to all enemy units. If a unit has Contagion stacks at least equal to its health, it then takes damage equal its number of Contagion stacks.",
                ParamInt = 1,


            }.Build();

        }


        public override bool TestTrigger(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            if (inputTriggerParams.associatedCharacter != null && inputTriggerParams.associatedCharacter.IsAlive)
            {
                associatedCharacter = inputTriggerParams.associatedCharacter;
            }
            else
            {
                associatedCharacter = null;
            }
            combatManager = inputTriggerParams.combatManager;
            stacks = associatedCharacter?.GetStatusEffectStacks(GetStatusId()) ?? 0;
            if (stacks > 0 && combatManager != null)
            {
                return associatedCharacter != null;
            }
            return false;
        }

        protected override IEnumerator OnTriggered(InputTriggerParams inputTriggerParams, OutputTriggerParams outputTriggerParams)
        {
            CoreSignals.DamageAppliedPlaySound.Dispatch(Damage.Type.DirectAttack);
            int numStacks = associatedCharacter.GetStatusEffectStacks(base.GetStatusId());
            ProviderManager.TryGetProvider<RoomManager>(out var roomManager);
            roomManager.GetSelectedRoom();
                             

            if (numStacks >= associatedCharacter.GetHP() && combatManager != null)
            {

                yield return combatManager.ApplyDamageToTarget(GetDamageAmount(stacks), associatedCharacter, new CombatManager.ApplyDamageToTargetParameters
                {
                    damageType = Damage.Type.DirectAttack,
                    vfxAtLoc = GetSourceStatusEffectData()?.GetOnAffectedVFX(),
                    showDamageVfx = true,
                    relicState = inputTriggerParams.suppressingRelic
                });
            }

            if (numStacks > 0)
            {
                List<CharacterState> list = new List<CharacterState>();
                //ProviderManager.CombatManager.GetHeroManager().AddCharactersInRoomToList(list, roomManager.GetSelectedRoom());
                //thanks Brandon for th ehelp fixing the combat math issues!
                RoomState roomState = associatedCharacter.GetSpawnPoint().GetRoomOwner();
                if (roomState != null)

                { roomState.AddCharactersToList(list, Team.Type.Heroes);
                    foreach (CharacterState characterState in list)

                    {
                        //if (roomManager.GetSelectedRoom() == -1)
                        {
                            characterState.AddStatusEffect(StatusEffectContagion.statusID, 1);
                        }
                    }
                };
            }
        }

        public override int GetEffectMagnitude(int stacks = 1)
        {
            return GetDamageAmount(stacks);
        }

        private int GetDamageAmount(int stacks)
        {
            return (GetParamInt() + relicManager.GetModifiedStatusMagnitudePerStack("status_contagion", GetAssociatedCharacter().GetTeamType())) * stacks;
        }
    }
}
    