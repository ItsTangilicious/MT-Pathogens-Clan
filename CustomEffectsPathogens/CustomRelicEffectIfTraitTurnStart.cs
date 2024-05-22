using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomEffectsPathogens
    //deleted from the actual mod as it was unused
{
    //couldn't get to work Mar 22 2024 :(
    public sealed class CustomRelicEffectIfTraitTurnStart : RelicEffectBase/*, IStartOfPlayerTurnAfterDrawRelicEffect*/
    {
        public override bool CanApplyInPreviewMode
        {
            get
            {
                return false;
            }
        }
        public override void Initialize(RelicState relicState, RelicData relicData, RelicEffectData relicEffectData)
        {
            base.Initialize(relicState, relicData, relicEffectData);
            this.returnees = relicEffectData.GetParamInt();
            this.teamFilter = relicEffectData.GetParamSourceTeam();
            this.cardType = relicEffectData.GetParamCardType();
            this.cardTrait = relicEffectData.GetTargetTrait();
        }

        public bool TestEffect(RelicEffectParams relicEffectParams)
        {
            List<CardState> hand = relicEffectParams.cardManager.GetHand();

            foreach (CardState card in hand)
            {
                if (card.GetCardType() == this.cardType)
                {
                    foreach (CardTraitData trait in card.GetTraits())
                    {                       
                        if (trait.GetTraitStateName() == this.cardTrait)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public IEnumerator ApplyEffect(RelicEffectParams relicEffectParams, CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            if (relicEffectParams.saveManager.PreviewMode)
            {
                yield break;
            }
            CardState cardState = PickRandomSpell(cardEffectParams.targetCards);
            base.NotifyRoomRelicTriggered(new RelicEffectParams
            {
                relicManager = relicEffectParams.relicManager,
                playerManager = relicEffectParams.playerManager,
                roomManager = relicEffectParams.roomManager,
                saveManager = relicEffectParams.saveManager
            });
            
            if (cardState != null)
            {
                relicEffectParams.cardManager.RestoreExhaustedOrEatenCard(cardState);
                //cardEffectParams.targetCards.Remove(cardState);
                //cardEffectParams.cardManager.RestoreExhaustedOrEatenCard(cardState);
                ApplyCardUpgrade(cardEffectState, cardState, cardEffectParams.cardManager, cardEffectParams.relicManager);
                cardEffectParams.cardManager.DrawSpecificCard(cardState, 0f, HandUI.DrawSource.Consume, cardEffectParams.playedCard);
            }
            //relicEffectParams.cardManager.(this.returnees);
            relicEffectParams.cardManager.DrawCards(1, null, CardType.Invalid);
            yield break;
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

        public string GetTooltipBaseKey(CardEffectState cardEffectState)
        {
            return null;
        }

        public string GetTipTooltipKey(CardEffectState cardEffectState)
        {
            return null;
        }
        private int returnees;
       
        private Team.Type teamFilter;

        private CardType cardType;

        private string cardTrait;
    }
    
    }

