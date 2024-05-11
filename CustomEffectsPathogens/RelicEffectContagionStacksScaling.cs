using CustomEffectsPathogens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomEffectsPathogens;

namespace Test_Bounce.CustomEffectsPathogens
    //currently not working Apr 10th 2024
{
    internal class RelicEffectContagionStacksScaling : RelicEffectBase, ICharacterActionRelicEffect, IRelicEffect, ITriggerRelicEffect, IStatusEffectRelicEffect
    {
        public override bool CanApplyInPreviewMode
        {
            get
            {
                return true;
            }
        }

        public override bool CanShowNotifications
        {
            get
            {
                return true;
            }
        }

        public bool TestCharacterTriggerEffect(CharacterTriggerRelicEffectParams relicEffectParams)
        {
            CharacterState characterState = relicEffectParams.characterState;
            if (relicEffectParams.trigger != this.trigger || characterState.GetTeamType() != this.sourceTeam)
            {
                return false;
            }
            foreach (StatusEffectStackData statusEffectStackData in this.statusEffects)
            {
                if (!characterState.HasStatusEffect(statusEffectStackData.statusId))
                {
                    return false;
                }
                else
                {
                    this.statusMultiplier = characterState.GetStatusEffectStacks(statusEffectStackData.statusId);
                }
            }
            if (this.trigger == CharacterTriggerData.Trigger.OnDeath && characterState.IsAlive)
            {
                return false;
            }
            if (!characterState.GetCharacterManager().DoesCharacterPassSubtypeCheck(characterState, this.subtypeData))
            {
                return false;
            }
            SpawnPoint spawnPoint = characterState.GetSpawnPoint(true);
            int roomIndex = (spawnPoint != null) ? spawnPoint.GetRoomOwner().GetRoomIndex() : relicEffectParams.roomManager.GetSelectedRoom();
            TargetHelper.CollectTargetsData data = new TargetHelper.CollectTargetsData
            {
                targetMode = this.targetMode,
                targetModeStatusEffectsFilter = new List<string>(),
                targetModeHealthFilter = CardEffectData.HealthFilter.Both,
                targetTeamType = this.sourceTeam,
                roomIndex = roomIndex,
                heroManager = relicEffectParams.heroManager,
                monsterManager = relicEffectParams.monsterManager,
                roomManager = relicEffectParams.roomManager,
                inCombat = false,
                isTesting = true
            };
            this._targets.Clear();
            TargetHelper.CollectTargets(data, ref this._targets);
            return this._targets.Count > 0;
        }

        public IEnumerator ApplyCharacterTriggerEffect(CharacterTriggerRelicEffectParams relicEffectParams)
        {
            List<CharacterState> list = new List<CharacterState>(this._targets);
            foreach (CharacterState characterState in list)
            {
                //base.NotifyRelicTriggered(relicEffectParams.relicManager, characterState);

                
                characterState.AddStatusEffect(StatusEffectContagion.statusID, this.statusAmount * this.statusMultiplier / 2); 
                //yield return relicEffectParams.combatManager.ApplyDamageToTarget((this.damageAmount * this.statusMultiplier), characterState, new CombatManager.ApplyDamageToTargetParameters
                /*{
                    relicState = this._srcRelicState,
                    vfxAtLoc = this._srcRelicEffectData.GetAppliedVfx(),
                    showDamageVfx = true
                });*/
            }

            yield break;
        }

        public override void Initialize(RelicState relicState, RelicData srcRelicData, RelicEffectData relicEffectData)
        {
            base.Initialize(relicState, srcRelicData, relicEffectData);
            this.trigger = relicEffectData.GetParamTrigger();
            this.sourceTeam = relicEffectData.GetParamSourceTeam();
            this.statusAmount = relicEffectData.GetParamInt();
            this.statusEffects = relicEffectData.GetParamStatusEffects();
            this.subtypeData = relicEffectData.GetParamCharacterSubtype();
            this.targetMode = relicEffectData.GetTargetMode();
            this.statusMultiplier = 0;
        }

        public StatusEffectStackData[] GetStatusEffects()
        {
            return this.statusEffects;
        }

        public CharacterTriggerData.Trigger GetTrigger()
        {
            return this.trigger;
        }

        public bool HideTriggerTooltip()
        {
            return false;
        }

        private CharacterTriggerData.Trigger trigger;

        private Team.Type sourceTeam;

        private int statusMultiplier;

        private int statusAmount;

        private StatusEffectStackData[] statusEffects;

        private SubtypeData subtypeData;

        private TargetMode targetMode;

        private List<CharacterState> _targets = new List<CharacterState>();
    }

}


