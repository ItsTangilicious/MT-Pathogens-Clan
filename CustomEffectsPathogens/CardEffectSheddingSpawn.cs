using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MonsterCardPathogens;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using UnityEngine;


namespace CustomEffectsPathogens 
{
    public sealed class CardEffectSheddingSpawn : CardEffectBase
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
            if (sheddingCost >= 0)
            {
                cardEffectParams.selfTarget.RemoveStatusEffect(VanillaStatusEffectIDs.Shard, removeAtEndOfTurn: false, sheddingCost, showNotification: true, cardEffectParams.sourceRelic);
                //cardEffectParams.selfTarget.RemoveStatusEffect("status_SheddingDummy", removeAtEndOfTurn: false, sheddingCost, showNotification: true, cardEffectParams.sourceRelic);
            }
            SaveManager saveManager = cardEffectParams.saveManager;
            SpawnMode spawnMode = SpawnMode.SelectedSlot;
            RoomState room = cardEffectParams.GetSelectedRoom();
            CharacterState selfCharacter = cardEffectParams.selfTarget;
            //CharacterData selfCharacterData = CustomCharacterManager.GetCharacterDataByID(RecombinantVirusMonster.CharID);
            CharacterData selfCharacterData = cardEffectState.GetParamCharacterData();
            SpawnPoint fromMonsterSpawnPoint = selfCharacter.GetSpawnPoint(allowLastKnownSpawnPoint: true);
            int spawnIndex2 = fromMonsterSpawnPoint.GetIndexInRoom();
            int num = room.ShiftSpawnPoints(Team.Type.Monsters, spawnIndex2);
            spawnIndex2 = Mathf.Max(spawnIndex2 - num, 0);

            if (!saveManager.PreviewMode && num > 0)
            {
                yield return cardEffectParams.roomManager.GetRoomUI().CenterCharacters(room, fromMonsterSpawnPoint != null, fromEndOfRoomCombat: false, forceRecenter: true);
            }
            _ = cardEffectParams.relicManager;
            int numSpawns = Mathf.Min(1, room.GetRemainingSpawnPointCount(Team.Type.Monsters));
            for (int i = spawnIndex2; i < spawnIndex2 + numSpawns && i < saveManager.GetNumSpawnPointsPerFloor(); i++)
            {
                SpawnPoint spawnPoint = room.GetMonsterPoint(i);
                CardState spawnerCard = (cardEffectState.GetParamBool() ? null : cardEffectParams.playedCard);
                if (fromMonsterSpawnPoint != null && spawnerCard != null)
                {
                    spawnerCard = CardManager.CopyCardState(spawnerCard, cardEffectParams.relicManager, saveManager, cardEffectParams.allGameData, cardEffectParams.combatManager.GetCardManager().GetCardStatistics());
                }
                List<string> startingStatusEffects = new List<string> { "cardless" };
                CharacterState newMonster = null;
                yield return cardEffectParams.monsterManager.CreateMonsterState(selfCharacterData, spawnerCard, cardEffectParams.selectedRoom, delegate (CharacterState character)
                {
                    /*newMonster = character;
                    if (newMonster != null)
                    {
                        CharacterHelper.CopyCharacterStats(newMonster, selfCharacter);
                        newMonster.SetAttackDamage(selfCharacter.GetAttackDamageWithoutStatusEffectBuffs());
                        newMonster.SetHealth(newMonster.GetMaxHP(), newMonster.GetMaxHP());
                    }*/
                }, spawnMode, spawnPoint, null, recruitedUnit: false, null, startingStatusEffects);
                CardUpgradeData paramCardUpgradeData = cardEffectState.GetParamCardUpgradeData();
                /* if (newMonster != null && paramCardUpgradeData != null)
                 {
                     CardUpgradeState upgradeState = new CardUpgradeState();
                     upgradeState.Setup(paramCardUpgradeData);
                     yield return newMonster.ApplyCardUpgrade(upgradeState);
                     if (spawnerCard != null && !saveManager.PreviewMode)
                     {
                         spawnerCard.GetTemporaryCardStateModifiers().AddUpgrade(upgradeState);
                         spawnerCard.UpdateCardBodyText();
                     }
                 } */
            }
            if (!saveManager.PreviewMode)
            {
                yield return cardEffectParams.roomManager.GetRoomUI().CenterCharacters(room, fromMonsterSpawnPoint != null, fromEndOfRoomCombat: false, forceRecenter: true);
            }
            else
            {
                room.ShiftSpawnPoints(Team.Type.Monsters);
            }
        }
    }
}
