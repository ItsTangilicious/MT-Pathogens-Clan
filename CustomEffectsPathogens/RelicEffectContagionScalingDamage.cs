using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static MutableRules;
using UnityEngine;

namespace Test_Bounce.CustomEffectsPathogens
{
    internal class RelicEffectContagionScalingDamage : RelicEffectBase, ICharacterActionRelicEffect, IRelicEffect, ITriggerRelicEffect, IStatusEffectRelicEffect
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
               
                {
                    base.NotifyRelicTriggered(relicEffectParams.relicManager, characterState);
                    yield return relicEffectParams.combatManager.ApplyDamageToTarget((this.damageAmount * this.statusMultiplier) / 2, characterState, new CombatManager.ApplyDamageToTargetParameters
                    {
                        relicState = this._srcRelicState,
                        vfxAtLoc = this._srcRelicEffectData.GetAppliedVfx(),
                        showDamageVfx = true
                    });
                }
            }
            
            yield break;         
        }
        
        public override void Initialize(RelicState relicState, RelicData srcRelicData, RelicEffectData relicEffectData)
        {
            base.Initialize(relicState, srcRelicData, relicEffectData);
            this.trigger = relicEffectData.GetParamTrigger();
            this.sourceTeam = relicEffectData.GetParamSourceTeam();
            this.damageAmount = relicEffectData.GetParamInt();
            //this.damageAmountFraction = relicEffectData.GetParamFloat();
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
               
        private int damageAmount;

        //public float damageAmountFraction { get; private set; }

        private StatusEffectStackData[] statusEffects;
               
        private SubtypeData subtypeData;
             
        private TargetMode targetMode;
                
        private List<CharacterState> _targets = new List<CharacterState>();

        private readonly Dictionary<Condition, List<IBalanceEditingRelicEffect>> ruleMap = new Dictionary<Condition, List<IBalanceEditingRelicEffect>>();

    

        
    }
    
}
