using HarmonyLib;
using ShinyShoe.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Enums.MTTriggers;
using Trainworks.Managers;
using UnityEngine;
using Trainworks.ConstantsV2;
using RelicsPathogens;

namespace CustomEffectsPathogens
{
    
    public static class CustomTriggerBetterRally
    {

        //public static CharacterTriggerData.Trigger OnRallyBetterCharTrigger = (new CharacterTrigger("OnBetterRally")).GetEnum();
        public const string IDName = "CustonmTriggerBetterRally";
        //public static CharacterTrigger OnRallyBetterCharTrigger = new CharacterTrigger("Culture");
        public static CharacterTrigger OnCustomTriggerBetterRallyCharTrigger;
        public static CardTrigger OnCustomTriggerBetterRallyCardTrigger;

        static CustomTriggerBetterRally()
        {
            OnCustomTriggerBetterRallyCharTrigger = new CharacterTrigger("CustomTriggerBetterRally_Char");
            OnCustomTriggerBetterRallyCardTrigger = new CardTrigger("CustomTriggerBetterRally");
            CustomTriggerManager.AssociateTriggers(OnCustomTriggerBetterRallyCardTrigger, OnCustomTriggerBetterRallyCharTrigger);
        }
    }


    [HarmonyPatch(typeof(CharacterState), nameof(CharacterState.OnOtherCharacterSpawned))]
    class OnBetterRallyTriggerPatch
    {       
        private static void Postfix(CharacterState __instance, MonsterManager monsterManager, HeroManager heroManager, CombatManager ___combatManager)
        {
            //Provider manager through return:} needed to make trigger only on the target floor.
            ProviderManager.TryGetProvider<RoomManager>(out var roomManager);
            roomManager.GetSelectedRoom();
            if (roomManager.GetSelectedRoom() == -1)
            {
                return;
            }
            List<CharacterState> list2 = new List<CharacterState>();
            //Needed to make it only so units with OnRallyBetterCharTrigger get counted.
            if (__instance.HasEffectTrigger(CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum()))
            {
                //Next line also needed to make trigger only on the target floor.
                ProviderManager.CombatManager.GetMonsterManager().AddCharactersInRoomToList(list2, roomManager.GetSelectedRoom());
                
            }

            //Artifact that lets off-room spawns also trigger it. Need to disable it in preview mode.
            
            if (MycorrhizalNetwork.HasIt() && __instance.HasEffectTrigger(CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum()) && !ProviderManager.SaveManager.PreviewMode)
            {
                
                ProviderManager.CombatManager.GetMonsterManager().AddCharactersInTowerToList(list2);
                
            }

            foreach (CharacterState unit in list2) 
                    
                {
                //if statement makes it so the trigger no longer fires multiplicatively when there are multiple Culture units on the floor.
                if (unit != __instance)
                {
                    continue;
                }
                CustomTriggerManager.QueueTrigger(CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger, unit, true, true, null, 1);

                
            }
            
            
        }
    }

    /*[HarmonyPatch(typeof(RoomManager), "CreateMonsterState")]
    class OnBetterRallyTriggerPatch

    {
        static void Postfix(CharacterData monsterData, CardState spawnerCard, int selectedRoom, Action<CharacterState> afterCharacterCreated, SpawnMode spawnMode = SpawnMode.FrontSlot, SpawnPoint spawnLocation = null, Action<CharacterState> onCharacterStateCreated = null, bool recruitedUnit = false, CharacterData originalCharacterData = null, List<string> startingStatusEffects = null, bool isCardless = false)
        { 
        private GameObject defaultCharacterPrefab;
        private AssetLoadingManager assetLoadingManager;
        private CharacterData monsterData;
        private CharacterState lastSpawnedMonster;
        private CombatManager combatManager;
        private int creatingMonsterState;
        
        if (creatingMonsterState == 1 && monsterData.IsAlive) 
                        {
                            
                            List<CharacterState> list2 = new List<CharacterState>();
                            AddCharactersInRoomToList(list2, lastSpawnedMonster.GetCurrentRoomIndex());
                            foreach (CharacterState item2 in list2)
                            {
                                yield return combatManager.QueueAndRunTrigger(item2, CustomTriggerBetterRally.OnRallyBetterCharTrigger, fireTriggersData: new CharacterState.FireTriggersData);
                            }
                            lastSpawnedMonster = null;

                        }
    }*/
}

                   
                
            
        
        
    



