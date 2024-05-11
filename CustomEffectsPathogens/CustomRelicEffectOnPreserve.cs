using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Test_Bounce.CustomEffectsPathogens
    //couldn't get to work Mar 22 2024 :(
{

    public sealed class RelicEffectOnPreserve : RelicEffectBase, /*IEndTurnPreHandDiscardRelicEffect,*/ IRelicEffect
    {
        private int numCards;
        private List<CardTraitData> triggerOnTraits;
       
        private CardUpgradeData cardUpgradeData;
        private bool removeOnDiscard;

        public override void Initialize(RelicState relicState, RelicData relicData, RelicEffectData relicEffectData)
        {
            base.Initialize(relicState, relicData, relicEffectData);
            triggerOnTraits = relicEffectData.GetTraits();
            numCards = relicEffectData.GetParamInt();
        }

        public bool TestEffect(EndTurnPreHandDiscardRelicEffectParams relicEffectParams)
        {
            /* List<CardState> hand = relicEffectParams.cardManager.GetHand(shouldCopy: true);
             return Mathf.Min(numCards, hand.Count) > 0;*/
            return true;
         
        }

        public IEnumerator IEndTurnPreHandDiscardRelicEffectApplyEffect(EndTurnPreHandDiscardRelicEffectParams relicEffectParams, CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            if (relicEffectParams.saveManager.PreviewMode)
            {
                yield break;
            }
            foreach (CardState item in relicEffectParams.cardManager.GetHand())
            {
                int num = 0;
                foreach (CardTraitData triggerOnTrait in triggerOnTraits)
                {
                    //List<CardState> hand = relicEffectParams.cardManager.GetHand(shouldCopy: true);
                    //foreach (CardState cardInHand in hand)
                    foreach (CardTraitState traitState in item.GetTraitStates())
                    {
                        if (traitState.GetTraitStateName() == triggerOnTrait.GetTraitStateName())
                        //if (cardInHand.HasTriggerType(CardTriggerType.OnUnplayed))
                        {
                            num++;
                            break;
                        }
                    }
                }
                if (num == triggerOnTraits.Count)
                {
                    CardState cardState = PickRandomSpell(cardEffectParams.targetCards);
                    if (cardState != null)
                    {
                        relicEffectParams.cardManager.RestoreExhaustedOrEatenCard(cardState);
                        //cardEffectParams.targetCards.Remove(cardState);
                        //cardEffectParams.cardManager.RestoreExhaustedOrEatenCard(cardState);
                        ApplyCardUpgrade(cardEffectState, cardState, cardEffectParams.cardManager, cardEffectParams.relicManager);
                        cardEffectParams.cardManager.DrawSpecificCard(cardState, 0f, HandUI.DrawSource.Consume, cardEffectParams.playedCard);
                    }
                    //yield return HandleRandomCard(cardEffectState, cardEffectParams);
                    /*CardStateModifiers temporaryCardStateModifiers = item.GetTemporaryCardStateModifiers();
                    CardUpgradeState cardUpgradeState = new CardUpgradeState();
                    cardUpgradeState.Setup(cardUpgradeData);
                    cardUpgradeState.SetRemoveOnDiscard(removeOnDiscard);
                    CardAnimator.CardUpgradeAnimationInfo type = new CardAnimator.CardUpgradeAnimationInfo(item, cardUpgradeState);
                    CardAnimator.DoAddRecentCardUpgrade.Dispatch(type);
                    temporaryCardStateModifiers.AddUpgrade(cardUpgradeState);
                    item.UpdateCardBodyText();
                    relicEffectParams.cardManager?.RefreshCardInHand(item);
                    NotifyRelicTriggered(relicEffectParams.relicManager);*/
                }
            }
        }
        private CardState PickRandomSpell(List<CardState> allCards)
        {
            List<CardState> list = new List<CardState>();
            foreach (CardState allCard in allCards)
            {
                if (allCard.GetCardType() == CardType.Spell)
                {
                    list.Add(allCard);
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            return list[RandomManager.Range(0, list.Count - 1, RngId.Battle)];
        }

        private void ApplyCardUpgrade(CardEffectState cardEffectState, CardState toCardState, CardManager cardManager, RelicManager relicManager)
        {
            if (cardEffectState.GetParamCardUpgradeData() == null)
            {
                return;
            }
            CardUpgradeState cardUpgradeState = new CardUpgradeState();
            cardUpgradeState.Setup(cardEffectState.GetParamCardUpgradeData());
            foreach (CardUpgradeMaskData filter in cardUpgradeState.GetFilters())
            {
                if (!filter.FilterCard(toCardState, relicManager))
                {
                    return;
                }
            }
            CardAnimator.CardUpgradeAnimationInfo type = new CardAnimator.CardUpgradeAnimationInfo(toCardState, cardUpgradeState);
            CardAnimator.DoAddRecentCardUpgrade.Dispatch(type);
            toCardState.GetTemporaryCardStateModifiers().AddUpgrade(cardUpgradeState);
            toCardState.UpdateCardBodyText();
            cardManager?.RefreshCardInHand(toCardState);
        }

        /*private IEnumerator HandleRandomCard(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            if (cardEffectParams.targetCards.Count <= 0)
            {
                yield break;
            }
            
           
            if (cardEffectParams.targetCards.Count > 0)
            {
                CardState cardState = PickRandomSpell(cardEffectParams.targetCards);
                if (cardState != null)
                {
                    //cardEffectParams.targetCards.Remove(cardState);
                    cardEffectParams.cardManager.RestoreExhaustedOrEatenCard(cardState);
                    ApplyCardUpgrade(cardEffectState, cardState, cardEffectParams.cardManager, cardEffectParams.relicManager);
                    cardEffectParams.cardManager.DrawSpecificCard(cardState, 0f, HandUI.DrawSource.Consume, cardEffectParams.playedCard);
                }
            }
        }*/

        public string GetTooltipBaseKey(CardEffectState cardEffectState)
        {
            return null;
        }

        public string GetTipTooltipKey(CardEffectState cardEffectState)
        {
            return null;
        }
    }



}
