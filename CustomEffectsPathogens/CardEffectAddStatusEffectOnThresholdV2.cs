using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.ConstantsV2;

namespace CustomEffectsPathogens
{
    public sealed class CardEffectAddStatusEffectOnStatusThresholdV2 : CardEffectBase
    {
        private StatusEffectStackData statusRequirement;

        private StatusEffectStackData statusToAdd;

       /* public override void Setup(CardEffectState cardEffectState)
        {
            base.Setup(cardEffectState);
            StatusEffectStackData[] paramStatusEffectStackData = cardEffectState.GetParamStatusEffectStackData();
            statusRequirement = paramStatusEffectStackData[0];
            statusToAdd = paramStatusEffectStackData[1];
        }*/

        public override bool TestEffect(CardEffectState cardEffectState, CardEffectParams cardEffectParams)
        {
            List<CharacterState> targets = cardEffectParams.targets;
            int shardCost = cardEffectState.GetParamInt();
            if (cardEffectParams.selfTarget.GetStatusEffectStacks(VanillaStatusEffectIDs.Shard) < shardCost)
            {
                return false;
            }
            /*CharacterState characterState = targets[0];
            int statusEffectStacks = characterState.GetStatusEffectStacks(VanillaStatusEffectIDs.Shard);
            if (characterState.HasStatusEffect(statusToAdd.statusId))
            {
                return statusEffectStacks >= shardCost;
            }
            return false;*/
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
                cardEffectParams.selfTarget.AddStatusEffect(statusToAdd.statusId, statusToAdd.count);
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
