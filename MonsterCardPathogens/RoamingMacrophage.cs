using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.PathogenSubtype;
using CustomEffectsPathogens;
using Test_Bounce.CustomEffectsPathogens;


namespace MonsterCardPathogens
{
    internal class RoamingMacrophage
    {
        public static readonly string ID = Rats.GUID + "_RoamingMacrophageCard";
        public static readonly string CharID = Rats.GUID + "_RoamingMacrophageCharacter";
        public static readonly string TriggerID = Rats.GUID + "_RoamingMacrophageSlay";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Roaming Macrophage",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/MacrophageCard.png",
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
                            Name = "Roaming Macrophage",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 20,
                            AssetPath = "AssetsAll/MonsterAssets/MacrophageCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            StartingStatusEffects =
                                {   new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Quick,
                                        count = 1
                                    }
                                },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "RoamingMacrophageSynthesis",
                                UpgradeDescription = "<b>Quick</b> and '<b>Slay:</b> +2[attack]'.",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 0,
                                StatusEffectUpgrades =
                                {   new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Multistrike,
                                        count = 1
                                    }
                                },
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CharacterTriggerData.Trigger.OnKill,
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
                                                        UpgradeID = "RoamingMacrophageSlayUpgrade",
                                                        BonusDamage = 2,
                                                }.Build(),
                                            }
                                        }
                                    }
                                }

                            },
                            TriggerBuilders =
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID,
                                    Trigger = CharacterTriggerData.Trigger.OnKill,
                                    Description = "+3[attack] and [health].",
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
                                                UpgradeID = "RoamingMacrophageUpgrade",
                                                BonusDamage = 3,
                                                BonusHP = 3,
                                            }.Build(),
                                        }
                                    }
                                },
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = Rats.CLANID + "_RoamingMacrophageEnchant",
                                    Trigger = CharacterTriggerData.Trigger.AfterSpawnEnchant,
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectEnchant),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamStatusEffects =
                                            {
                                                new StatusEffectStackData
                                                {
                                                    statusId = StatusEffectMarkedForSacrificeDummyStacks.statusId,
                                                count = 1,
                                                }
                                            }
                                        }
                                    }

                                },
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = "RoamingMacrophageResolve",
                                    Trigger = CharacterTriggerData.Trigger.PostCombat,
                                    Description = "Destroy all other friendly units.",
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectKill),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            TargetModeStatusEffectsFilter = new[]
                                            {
                                                StatusEffectMarkedForSacrificeDummyStacks.statusId
                                            }

                                        },
                                    }
                                }
                            },
                            
                        },
                       
                    }
                    
                },
                


            }.BuildAndRegister();
        }
    }
}
