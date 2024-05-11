using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.HostSubtype;
using CustomEffectsPathogens;
using System.Collections;


namespace MonsterCardPathogens
{
    class Virodaemonologist
    {
        public static readonly string ID = Rats.GUID + "_VirodaemonologistCard";
        public static readonly string CharID = Rats.GUID + "_VirodaemonologistCharacter";
        public static readonly string TriggerID = Rats.GUID + "_VirodaemonologistRally";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Virodaemonologist",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/VibrodaemonologistCard.png",
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
                            Name = "Virodaemonologist",
                            Size = 2,
                            Health = 25,
                            AttackDamage = 5,
                            AssetPath = "AssetsAll/MonsterAssets/VibrodaemonologistCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { HostSubtype.Host },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "VirodaemonologistSynthesis",
                                UpgradeDescription = "<b>Culture:</b> Gain +2[attack] and [armor] <b>2</b>.",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 10,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                                        EffectBuilders = new List<CardEffectDataBuilder>
                                        {
                                            new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                                                TargetTeamType = Team.Type.Monsters,
                                                TargetMode = TargetMode.Self,
                                             
                                                ParamInt = 1,
                                              
                                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                                                                                  
                                                    {
                                                        UpgradeID = "VibrodaemonologistRallyFusionUpgrade",
                                                        BonusDamage = 2,
                                                        BonusHP = 0

                                                    }.Build(),
                                                

                                            },
                                            new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                                TargetMode = TargetMode.Self,
                                                TargetTeamType = Team.Type.None,
                                                ParamStatusEffects =
                                                {
                                                    new StatusEffectStackData
                                                    {
                                                        statusId = VanillaStatusEffectIDs.Armor,
                                                        count = 2,
                                                    }
                                                }

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
                                    Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                                    Description = "Gain +5[attack] and [armor] [effect1.status0.power].",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                                                TargetTeamType = Team.Type.Monsters,
                                                TargetMode = TargetMode.Self,
                                                ParamInt = 1,
                                                ParamCardUpgradeData = new CardUpgradeDataBuilder

                                                    {
                                                        //Use UpgradeID instead of UpgradeTitle
                                                        //UpgradeTitle = "VibrodaemonologistRallyUpgrade",
                                                        UpgradeID = "VibrodaemonologistRallyUpgrade",
                                                        BonusDamage = 5,
                                                    }.Build(),


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
                                                        statusId = VanillaStatusEffectIDs.Armor,
                                                        count = 5,
                                                    }
                                                }

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
