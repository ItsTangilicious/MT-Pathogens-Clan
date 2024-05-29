using HellPathogens.Clan;
using HellPathogens.PathogenSubtype;
using System;
using System.Collections.Generic;
using System.Text;
using static CharacterTriggerData;
using static RimLight;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using CustomEffectsPathogens;

namespace MonsterCardPathogens 
{
    class SimplexvirusDiabolicusMonster
    {


        public static readonly string ID = Rats.GUID + "_SimplexVirusCard";
        public static readonly string CharID = Rats.GUID + "_SimplexVirusCharacter";
        public static readonly string TriggerID = Rats.GUID + "_SimplexVirusResolveRevenge";
        public static readonly string SynthesisTriggerID = Rats.GUID + "_SimplexVirusEssenceResolve";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Simplexvirus Diabolicus",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/SimplexvirusCard.png",
                ClanID = Clan.ID,
                CardPoolIDs = { VanillaCardPoolIDs.UnitsAllBanner },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectSpawnMonster),
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = CharID,
                            Name = "Simplexvirus Diabolicus",
                            Size = 3,
                            Health = 30,
                            AttackDamage = 0,
                            AssetPath = "AssetsAll/MonsterAssets/SimplexvirusCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "SimplexVirusSynthesis",
                                UpgradeDescription = "'<b>Resolve:</b> Summon 1 Recombinant Virus.'",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                LinkedPactDuplicateRarity = CollectableRarity.Rare,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        TriggerID = SynthesisTriggerID,
                                        Trigger = Trigger.PostCombat,
                                        EffectBuilders = new List<CardEffectDataBuilder>
                                        {
                                            new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },
                                            new CardEffectDataBuilder
                                                {
                                                     EffectStateType = typeof(CardEffectRecruitsShedding),
                                                     TargetMode = TargetMode.Room,
                                                     TargetTeamType = Team.Type.Monsters,
                                            }
                                        }
                                    }
                                }

                            },
                      // Note to self - this is follows SynthBuilder
                            TriggerBuilders =
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID,
                                    Trigger = Trigger.OnHit,
                                    Description = "Gain <b>Shard [effect0.status0.power]</b>. Then lose <b>Shard [effect2.power]</b> to summon 1 Recombinant Virus.",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.Self,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamStatusEffects =
                                            {
                                                 new StatusEffectStackData
                                                 {
                                                     statusId = VanillaStatusEffectIDs.Shard, 
                                                     //statusId = StatusEffectSheddingDummyStacks.statusId,
                                                      count = 1

                                                 },

                                            }
                                        },
                                        new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectSheddingSpawn),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 2,
                                            ParamBool = true,
                                        }

                                    }
                                }

                            }
                        }

                    }
                }
            }.BuildAndRegister();
        }

    }
}
