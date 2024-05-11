using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using UnityEngine;

namespace CustomEffectsPathogens
    //thank you RisingDusk and the Unofficial Balance Patch!
{
    internal class CardEffectSheddingReturnConsumed : CardEffectBase, ICardTargetingCardEffect, ICardEffectStatuslessTooltip, ICardEffectTipTooltip
    {
        public override bool CanPlayAfterBossDead => false;

        public override bool CanApplyInPreviewMode => false;

        public int GetNumCardTargets(CardState cardState, CardEffectState cardEffectState, CardStatistics cardStatistics)
        {
            SubtypeData targetCharacterSubtype = cardEffectState.GetTargetCharacterSubtype();
            bool flag = targetCharacterSubtype != null && !targetCharacterSubtype.IsNone;
            CardStatistics.TrackedValueType trackedValue = CardStatistics.TrackedValueType.TypeInDeck;
            switch (cardEffectState.GetTargetMode())
            {
                case TargetMode.DrawPile:
                    trackedValue = (flag ? CardStatistics.TrackedValueType.SubtypeInDrawPile : CardStatistics.TrackedValueType.TypeInDrawPile);
                    break;
                case TargetMode.Discard:
                    trackedValue = (flag ? CardStatistics.TrackedValueType.SubtypeInDiscardPile : CardStatistics.TrackedValueType.TypeInDiscardPile);
                    break;
                case TargetMode.Exhaust:
                    trackedValue = (flag ? CardStatistics.TrackedValueType.SubtypeInExhaustPile : CardStatistics.TrackedValueType.TypeInExhaustPile);
                    break;
                case TargetMode.Eaten:
                    trackedValue = (flag ? CardStatistics.TrackedValueType.SubtypeInEatenPile : CardStatistics.TrackedValueType.TypeInEatenPile);
                    break;
            }
            CardStatistics.StatValueData statValueData = default(CardStatistics.StatValueData);
            statValueData.cardState = cardState;
            statValueData.trackedValue = trackedValue;
            statValueData.entryDuration = CardStatistics.EntryDuration.ThisBattle;
            statValueData.cardTypeTarget = cardStatistics.ConvertCardTypeToCardTargetType(cardEffectState.GetTargetCardType());
            statValueData.paramSubtype = cardEffectState.GetTargetCharacterSubtype();
            CardStatistics.StatValueData statValueData2 = statValueData;
            return cardStatistics.GetStatValue(statValueData2);
        }

        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            return base.TestEffect(cardEffectState, cardEffectParams);
        }

        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            if (cardEffectParams.targetCards.Count > 0)
            {
                if (cardEffectState.GetTargetCardSelectionMode() == CardEffectData.CardSelectionMode.RandomToHand)
                {
                    yield return HandleRandomCard(cardEffectState, cardEffectParams);
                }
            }
            else if (!cardEffectParams.saveManager.PreviewMode)
            {
                cardEffectParams.cardManager.ShowCardsDrawnErrorMessage(CardSelectionBehaviour.SelectionError.NoCardsDrawn);
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

        private IEnumerator HandleRandomCard(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            if (cardEffectParams.targetCards.Count <= 0)
            {
                yield break;
            }
            RoomState selectedRoom = CardEffectBase.GetSelectedRoom(cardEffectParams);
            if (selectedRoom == null)
            {
                yield break;
            }
            int num = cardEffectParams.selfTarget.GetStatusEffectStacks(VanillaStatusEffectIDs.Shard);
                       
            for (int i = 0; i < num; i++)
            {
                CardState cardState = PickRandomSpell(cardEffectParams.targetCards);
                if (cardState != null)
                {
                    cardEffectParams.targetCards.Remove(cardState);
                    cardEffectParams.cardManager.RestoreExhaustedOrEatenCard(cardState);
                    ApplyCardUpgrade(cardEffectState, cardState, cardEffectParams.cardManager, cardEffectParams.relicManager);
                    cardEffectParams.cardManager.DrawSpecificCard(cardState, 0f, HandUI.DrawSource.Consume, cardEffectParams.playedCard);
                }
            }
        }

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
