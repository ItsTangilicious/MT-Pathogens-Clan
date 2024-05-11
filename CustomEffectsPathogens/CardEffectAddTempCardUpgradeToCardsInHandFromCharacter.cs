using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomEffectsPathogens
{ //Thank you Brandon!
    public sealed class CardEffectAddTempCardUpgradeToCardsInHandFromCharacter : CardEffectBase, ICardEffectTipTooltip
    {
        public override bool CanPlayAfterBossDead => false;

        public override bool CanApplyInPreviewMode => false;

        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            CardUpgradeState cardUpgradeState = new CardUpgradeState();
            cardUpgradeState.Setup(cardEffectState.GetParamCardUpgradeData());
            foreach (CardState item in cardEffectParams.cardManager.GetHand())
            {
                bool flag = false;
                foreach (CardUpgradeMaskData filter in cardUpgradeState.GetFilters())
                {
                    if (!filter.FilterCard(item, cardEffectParams.relicManager))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                bool flag2 = true;

                foreach (CardTraitState traitState in cardEffectParams.selfTarget.GetSpawnerCard().GetTraitStates())
                {
                    flag2 = flag2 && traitState.OnCardBeingUpgraded(item, cardEffectParams.selfTarget.GetSpawnerCard(), cardEffectParams.cardManager, cardUpgradeState);
                }
                if (flag2)
                {
                    CardUpgradeState cardUpgradeState2 = new CardUpgradeState();
                    cardUpgradeState2.Setup(cardUpgradeState);
                    cardUpgradeState2.SetAttackDamage(cardUpgradeState2.GetAttackDamage() * item.GetMagicPowerMultiplierFromTraits());
                    cardUpgradeState2.SetAdditionalHeal(cardUpgradeState2.GetAdditionalHeal() * item.GetMagicPowerMultiplierFromTraits());
                    
                    item.GetTemporaryCardStateModifiers().AddUpgrade(cardUpgradeState2);
                    item.UpdateCardBodyText();
                    cardEffectParams.cardManager?.RefreshCardInHand(item, cleanupTweens: false);
                    cardEffectParams.cardManager.GetCardInHand(item)?.ShowEnhanceFX();
                }
            }
            yield break;
        }

        public override void GetTooltipsStatusList(CardEffectState cardEffectState, ref List<string> outStatusIdList)
        {
            GetTooltipsStatusList(cardEffectState.GetSourceCardEffectData(), ref outStatusIdList);
        }

        public static void GetTooltipsStatusList(CardEffectData cardEffectData, ref List<string> outStatusIdList)
        {
            foreach (StatusEffectStackData statusEffectUpgrade in cardEffectData.GetParamCardUpgradeData().GetStatusEffectUpgrades())
            {
                outStatusIdList.Add(statusEffectUpgrade.statusId);
            }
        }

        public string GetTipTooltipKey(CardEffectState cardEffectState)
        {
            if (cardEffectState.GetParamCardUpgradeData() != null && cardEffectState.GetParamCardUpgradeData().HasUnitStatUpgrade())
            {
                return "TipTooltip_StatChangesStick";
            }
            return null;
        }
    }
}