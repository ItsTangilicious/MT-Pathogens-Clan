using CustomEffectsPathogens;
using HellPathogens.Clan;
using HellPathogens.PathogenSubtype;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Test_Bounce;

namespace 
    MonsterCardPathogens
{
    internal class VibrioInfernum
    {
        public static readonly string ID = Rats.GUID + "_VibrioInfernum";
        public static readonly string CharID = Rats.GUID + "_VibrioInfernumCharacter";
        public static readonly string TriggerID = Rats.GUID + "_VibrioInfernumRally";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Vibrio Infernum",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/VibrioCard.png",
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
                            Name = "Vibrio Infernum",
                            Size = 2,
                            Health = 30,
                            AttackDamage = 10,
                            AssetPath = "AssetsAll/MonsterAssets/VibrioCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "VibrioInfernumSynthesis",
                                UpgradeDescription = "+1[size], <b>Multistrike 1</b>, and <b>Culture:</b> Gain <b>Rage 3</b>.",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 0,
                                BonusSize = 1,
                                LinkedPactDuplicateRarity = CollectableRarity.Rare,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                                        EffectBuilders = new List<CardEffectDataBuilder>
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
                                                        statusId = VanillaStatusEffectIDs.Rage,
                                                        count = 3,
                                                    }
                                                }

                                            }
                                        }

                                    }                                                                                                     
                                },
                               
                                StatusEffectUpgrades =
                                {   new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Multistrike,
                                        count = 1
                                    }
                                }
                            },
                      // Note to self - this is follows SynthBuilder
                            TriggerBuilders =
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID,
                                    Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                                    Description = "Gain <nobr>[rage] [effect0.status0.power]</nobr> and <b>Shard [effect1.status0.power]</b>. Then lose <b>Shard <nobr>[effect2.power]</nobr></b> and gain <nobr>[multistrike] 1</nobr>.  ",
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
                                                      statusId = VanillaStatusEffectIDs.Rage,
                                                      count = 3
                                                 }
                                            }
                                        },
                                       
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.Self,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamStatusEffects =
                                            {
                                                 new StatusEffectStackData
                                                 {
                                                      statusId= VanillaStatusEffectIDs.Shard,
                                                     //statusId = StatusEffectSheddingDummyStacks.statusId,
                                                      count = 1

                                                 },

                                            }
                                        },

                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectSheddingMultistrike),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 3,
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
