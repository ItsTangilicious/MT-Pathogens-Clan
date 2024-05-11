using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;


namespace CustomEffectsPathogens
{
    public sealed class CardEffectSheddingMultistrike : CardEffectBase
    {
        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            int sheddingCost = cardEffectState.GetParamInt();
            if (cardEffectParams.selfTarget.GetStatusEffectStacks(VanillaStatusEffectIDs.Shard) < sheddingCost)
            //if (cardEffectParams.selfTarget.GetStatusEffectStacks("status_SheddingDummy") < sheddingCost)
            {
                return false;
            }
            CardUpgradeData paramCardUpgradeData = cardEffectState.GetParamCardUpgradeData();
            if (paramCardUpgradeData != null)
            {
                int bounsMaxHP = paramCardUpgradeData.GetBonusHP();
                if (cardEffectParams.selfTarget.GetMaxHP() + bounsMaxHP <= 0)
                {
                    return false;
                }
            }
            RoomState selectedRoom = cardEffectParams.GetSelectedRoom();
            if (!(selectedRoom == null))
            {
                return selectedRoom.IsRoomEnabled();
            }
            return true;
        }

        public override IEnumerator ApplyEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            int sheddingCost = cardEffectState.GetParamInt();
            if (sheddingCost > 0)
            {
                cardEffectParams.selfTarget.RemoveStatusEffect(VanillaStatusEffectIDs.Shard, removeAtEndOfTurn: false, sheddingCost, showNotification: true, cardEffectParams.sourceRelic);
                //cardEffectParams.selfTarget.RemoveStatusEffect("status_SheddingDummy", removeAtEndOfTurn: false, sheddingCost, showNotification: true, cardEffectParams.sourceRelic);
            }

            SaveManager saveManager = cardEffectParams.saveManager;
            CharacterState selfCharacter = cardEffectParams.selfTarget;
            if (!saveManager.PreviewMode)
            {
                selfCharacter.AddStatusEffect(VanillaStatusEffectIDs.Multistrike, 1);
            }
            CharacterState newMonster = null;
            CardUpgradeData paramCardUpgradeData = cardEffectState.GetParamCardUpgradeData();
            if (newMonster != null)
            {
                if (paramCardUpgradeData != null)
                {
                    
                    CardUpgradeState upgradeState = new CardUpgradeState();
                    upgradeState.Setup(paramCardUpgradeData);
                    yield return newMonster.ApplyCardUpgrade(upgradeState);
                }
            }
        }
    }
}
