using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using UnityEngine;
using static MutableRules;

namespace CustomEffectsPathogens
{
    internal class CustomCardTraitReserveAndPurge : CardTraitState
    {
        private RemoveFromStandByCondition condition;
        public override IEnumerator OnCardDiscarded(CardManager.DiscardCardParams discardCardParams, CardManager cardManager, RelicManager relicManager, CombatManager combatManager, RoomManager roomManager, SaveManager saveManager)
        {
            if (discardCardParams.handDiscarded)
            {
                yield return cardManager.PurgeCard(discardCardParams.discardCard);
            }
        }

        /*public override string GetCardText()
        {
            return LocalizeTraitKey("CardTraitSelfPurge_CardText");
        }*/
    }

    
}

