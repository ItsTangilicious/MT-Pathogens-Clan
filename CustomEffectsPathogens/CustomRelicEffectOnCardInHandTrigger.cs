using ShinyShoe.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using static CharacterTriggerData;

namespace Test_Bounce.CustomEffectsPathogens
//deleted from the actual mod as it was unused
{
    internal class CustomRelicEffectOnCardInHandTrigger : RelicEffectBase/*, ITriggerRelicEffect*/
    {
        private CardTriggerData paramCardTrigger;

        private int countModifier;

        private bool allTriggers;

        private List<CardTriggerType> excludedCardTriggers;

        public override bool CanApplyInPreviewMode => true;


        public CardTriggerData GetParamTrigger()
        {
            return paramCardTrigger;
        }

        public override void Initialize(RelicState relicState, RelicData relicData, RelicEffectData relicEffectData)
        {
            base.Initialize(relicState, relicData, relicEffectData);
            //paramCardTrigger = relicEffectData.GetParamTrigger();
            countModifier = relicEffectData.GetParamInt();
            allTriggers = relicEffectData.GetParamBool();
            excludedCardTriggers = relicEffectData.GetCardTriggers();
            if (countModifier == 0)
            {
                Log.Warning(LogGroups.Gameplay, "Improper use of relic effect, trigger count should be modified by a non-zero amount.");
            }
        }
        public int GetTriggerCountModifier()
        {
            return countModifier;
        }

        public bool GetAllTriggers()
        {
            return allTriggers;
        }

        public List<CardTriggerType> GetExcludedCardTriggers()
        {
            return excludedCardTriggers;
        }
    }
}
