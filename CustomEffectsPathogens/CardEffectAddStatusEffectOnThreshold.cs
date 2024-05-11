using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomEffectsPathogens
{
    internal class CardEffectAddStatusEffectOnThreshold : CardEffectBase
    {
        private StatusEffectStackData statusRequirement;

        private StatusEffectStackData statusToAdd;

        public override void Setup(CardEffectState cardEffectState)
        {
            base.Setup(cardEffectState);
            StatusEffectStackData[] paramStatusEffectStackData = cardEffectState.GetParamStatusEffectStackData();
            statusRequirement = paramStatusEffectStackData[0];
            statusToAdd = paramStatusEffectStackData[1];
        }

        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            List<CharacterState> targets = cardEffectParams.targets;
            if (targets.Count <= 0)
            {
                return false;
            }
            CharacterState characterState = targets[0];
            int statusEffectStacks = characterState.GetStatusEffectStacks(statusRequirement.statusId);
            if (characterState.HasStatusEffect(statusToAdd.statusId))
            {
                return statusEffectStacks >= statusRequirement.count;
            }
            return false;
        }

        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            List<CharacterState> targets = cardEffectParams.targets;
            if (targets.Count > 0)
            {
                targets[0].AddStatusEffect(statusToAdd.statusId, statusToAdd.count);
            }
            yield break;
        }

        public override void GetTooltipsStatusList(CardEffectState cardEffectState, ref List<string> outStatusIdList)
        {
            GetTooltipsStatusList(cardEffectState.GetSourceCardEffectData(), ref outStatusIdList);
        }

        public static void GetTooltipsStatusList(CardEffectData cardEffectData, ref List<string> outStatusIdList)
        {
            CardEffectAddStatusEffect.GetTooltipsStatusList(cardEffectData, ref outStatusIdList);
        }
    }
}
