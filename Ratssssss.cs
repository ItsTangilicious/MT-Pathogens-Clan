using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using BepInEx;
using HarmonyLib;
using Steamworks;
using Trainworks.Interfaces;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using System.Reflection;
using Trainworks.ManagersV2;
using UnityEngine;
using StateMechanic;
using Trainworks.AssetConstructors;
using System.Text.RegularExpressions;
using HellPathogens.PathogenSubtype;
using Hellpathogens.Misc;
using HellbornPathogens.Champions;
using HellPathogens.Clan;
using MonsterTrainModdingTemplate.MonsterCards;
using CustomEffectsPathogens;
using MonsterCardPathogens;
using RelicsPathogens;
using SpellCardPathogens;
using Test_Bounce.CustomEffectsPathogens;
using HellPathogens.HostSubtype;
using HellPathogens.CardPools;
using HellPathogens.InstrumentSubtype;
using Patches;
using Trainworks.Managers;



namespace Test_Bounce
{

    [BepInPlugin(GUID, NAME, VERSION)]
        [BepInProcess("MonsterTrain.exe")]
        [BepInProcess("MtLinkHandler.exe")]
        [BepInDependency("tools.modding.trainworks")]
        public class Rats : BaseUnityPlugin, IInitializable
        {
            public const string GUID = "com.Tang.Rats.generic";
            public const string NAME = "Rat Bounce";
            public const string VERSION = "0.1.0";
            public const string CLANID = "RatPathogens";
            public static ClassData HellPathogensClanData;
            public static Rats Instance { get; private set; }
            

            public void Initialize()
            {
                CustomLocalizationManager.ImportCSV("Localization/PathogensLocal.csv");
                //Clan
                Clan.BuildClan();
                //Starter Cards
                TestContagion.BuildAndRegister();
                Virion.BuildAndRegister();
                //Champions
                CarrierChampion.BuildAndRegister();
                SuperVirusExiledChampion.BuildAndRegister();
                //Subtypes
                HostSubtype.BuildAndRegister();
                PathogenSubtype.BuildAndRegister();
                InstrumentSubtype.BuildAndRegister();

                //StatusEffects
                StatusEffectSheddingDummyStacks.Build();
                StatusEffectReplicate.Build();
                StatusEffectContagion.Build();
                StatusEffectMarkedForSacrificeDummyStacks.Build();

                //Cards - Spells               
                BacterialGrowth.BuildAndRegister();   
                BigBadonkas.BuildAndRegister();
                BoosterShot.BuildandRegister();
            ColiformDeterminatorSpell.BuildAndRegister();
                EvolvingResistance.BuildandRegister();
            //EvolvingResistance2A.BuildandRegister();
            //EvolvingResistance2B.BuildandRegister();
            //EvolvingResistance3A.BuildandRegister();
            //EvolvingResistance3B.BuildandRegister();
            //EvolvingResistance3C.BuildandRegister();
                Fervent_Scratching.BuildAndRegister();
                FeverishResponse.BuildAndRegister();
                HurriedExit.BuildAndRegister();
                IntestinalRupture.BuildAndRegister();
                IntroToBiology.BuildandRegister(); 
                LifeElixir.BuildAndRegister();
                MassHallucinations.BuildandRegister();
                MiraculousRecovery.BuildAndRegister();
                MultistrandedRNA.BuildAndRegister();
                Nausea.BuildAndRegister();
                Pandemic.BuildAndRegister();
                ParentheogenicSpike.BuildAndRegister();
                ProlongedLife.BuildAndRegister();
                QueueTime.BuildandRegister();
                RampantInfection.BuildandRegister();
                RoomForGrowth.BuildAndRegister();
                SpecimenCatalog.BuildandRegister();
                Spelleogenisis.BuildandRegister();
                SurvivalOfTheProlific.BuildAndRegister();
                Swarm_Tactics.BuildandRegister();
                SympatheticEmesis.BuildandRegister();
                //UnforseenSymptoms.BuildandRegister(); //possibly remove, extra uncommon
                ViralOutcroppingSpell.BuildAndRegister();
                
                //Cards - Units
                AntigenResponderMonster.BuildAndRegister();
                AsymptomaticCarrier.BuildAndRegister();
                BorreliaDaemonium.BuildAndRegister();
                //ColiformDeterminator.BuildAndRegister();
                CryogenicStorage.BuildAndRegister();
                GenomeSplicer.BuildAndRegister();
                Plaguebringer.BuildAndRegister();
                RecombinantVirusMonster.BuildAndRegister();
                RoamingMacrophage.BuildAndRegister();
                SimplexvirusDiabolicusMonster.BuildAndRegister();         
                VibrioInfernum.BuildAndRegister();
                Virodaemonologist.BuildAndRegister();

                //Card Pools
                MyCardPools.DoCardPoolStuff();
                
                //Relics
                AerosolizerRelic.BuildandRegister();
                BallOfPhlegm.BuildandRegister();           
                DivinitysSequence.BuildandRegister();
                FibroticLungs.BuildandRegister();
                GrantReapplication.BuildandRegister();
                GrowthChamber.BuildandRegister();
                HerzalsInsight.BuildandRegister();
                IceCore.BuildandRegister();
                MitoticDivisionRelic.BuildandRegister();
                MycorrhizalNetwork.BuildandRegister();
                ResearchNotebook.BuildandRegister();
                
                //Enhancers
                
                //Banner
                BannerDraftsHellPathogens.BuildAndRegister();

                //Patches
                NoDoubleReplicate.JustDont();

                //Custom Trait Tooltips
                //Custom RoomModifier TooltipTitle
            }
        private void Awake()
        {
            Rats.Instance = this;
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }

    }

    }


