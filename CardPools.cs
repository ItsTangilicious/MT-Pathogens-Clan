using HarmonyLib;
using MonsterCardPathogens;
using SpellCardPathogens;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using Trainworks.ManagersV2;
using UnityEngine;
using BepInEx.Logging;
using JetBrains.Annotations;


namespace HellPathogens.CardPools
{
    class MyCardPools
    {
        public static CardPool BorreliaCardPool = ScriptableObject.CreateInstance<CardPool>(); 
        public static CardPool RecombinantCardPool = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool VirionCardPool = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool MagicPowerExcludePool = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool JuiceStoneExcludePool = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool Resistance2A = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool Resistance2B = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool Resistance3A = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool Resistance3B = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool Resistance3C = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool RefMegaPool = ScriptableObject.CreateInstance<CardPool>();
        public static CardPool RefAllBannersPool = ScriptableObject.CreateInstance<CardPool>();


        /*public static void MarkCardPoolForPreloading(CardPool cardPoolID, bool clan_assets = true, bool game_assets = false)
        {
            cardPoolID = RecombinantCardPool;
        }*/
        

        public static void DoCardPoolStuff()
       {

           VirionCardPool = new CardPoolBuilder
            {
                CardPoolID = Rats.GUID + "_VirionCardPool",
                CardIDs = new List<string>
                {
                    CustomCardManager.GetCardDataByID(Virion.ID).GetID()
                },

            }.BuildAndRegister();

            BorreliaCardPool = new CardPoolBuilder
            {
                CardPoolID = Rats.GUID + "_BorreliaCardPool",
                CardIDs = new List<string>
                {
                    CustomCardManager.GetCardDataByID(BorreliaDaemonium.ID).GetID()
                },
                
            }.BuildAndRegister();

           RecombinantCardPool = new CardPoolBuilder
            {
                CardPoolID ="_RecombinantCardPool",
                CardIDs = new List<string>
                {
                    CustomCardManager.GetCardDataByID(RecombinantVirusMonster.ID).GetID()
                },
               
            }.BuildAndRegister();

            {
                MagicPowerExcludePool = new CardPoolBuilder
                {
                    CardPoolID = Rats.GUID + "_MagicPowerExcludePool",
                    CardIDs = new List<string>
                    {
                        VanillaCardIDs.UnleashtheWildwood,
                        VanillaCardIDs.AdaptiveMutation,
                        MiraculousRecovery.ID
                    }
                }.BuildAndRegister();               
            }
            
            {
                Resistance2A = new CardPoolBuilder
                {
                    CardPoolID = Rats.GUID + "_Resistance2A",
                    CardIDs = new List<string>
                    {

                    }
                }.BuildAndRegister();
            }
            {
                Resistance2B = new CardPoolBuilder
                {
                    CardPoolID = Rats.GUID + "_Resistance2B",
                    CardIDs = new List<string>
                    {

                    }
                }.BuildAndRegister();
            }
            {
                Resistance3A = new CardPoolBuilder
                {
                    CardPoolID = Rats.GUID + "_Resistance3A",
                    CardIDs = new List<string>
                    {

                    }
                }.BuildAndRegister();
            }
            {
                Resistance3B = new CardPoolBuilder
                {
                    CardPoolID = Rats.GUID + "_Resistance3B",
                    CardIDs = new List<string>
                    {

                    }
                }.BuildAndRegister();
            }
            {
                Resistance3C = new CardPoolBuilder
                {
                    CardPoolID = Rats.GUID + "_Resistance3C",
                    CardIDs = new List<string>
                    {

                    }
                }.BuildAndRegister();
            }
       }
        






    }
}
