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
using Trainworks.Constants;
using VanillaCardPoolIDs = Trainworks.ConstantsV2.VanillaCardPoolIDs;
using VanillaStatusEffectIDs = Trainworks.ConstantsV2.VanillaStatusEffectIDs;


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
                /*TraitBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingUpgradeUnitAttack,
                        ParamTrackedValue = CardStatistics.TrackedValueType.StatusEffectCountInTargetRoom,
                        ParamStatusEffects = new List<StatusEffectStackData>
                        {
                                new StatusEffectStackData
                                {
                                    statusId = StatusEffectContagion.statusID,
                                    count = 1
                                }
                        },
                        
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisTurn,
                        ParamInt = 1,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Heroes

                    }, 
                },*/
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
                            Health = 20,
                            AttackDamage = 0,
                            AssetPath = "AssetsAll/MonsterAssets/MacrophageCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            /*StartingStatusEffects =
                                {   new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Quick,
                                        count = 1
                                    }
                                },*/
                            RoomModifierBuilders =
                            {
                                new RoomModifierDataBuilder
                                {
                                    RoomModifierID = "_MacrophageRoom",
                                    RoomModifierClassType = typeof(CustomRoomStateAttackForContagion),                                    
                                    Description = "Has [attack] equal to the amount of <b>Contagion</b> on this floor.",
                                    DescriptionInPlay = "Has [attack] equal to the amount of <b>Contagion</b> on this floor.",
                                    ParamInt = 1,
                                }
                            },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "RoamingMacrophageSynthesis",
                                //UpgradeDescription = "<b>Quick</b> and '<b>Slay:</b> +2[attack].'",
                                UpgradeDescription = "Has [attack] equal to the amount of <b>Contagion</b> on this floor.",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 0,
                                LinkedPactDuplicateRarity = CollectableRarity.Rare,
                                RoomModifierUpgradeBuilders =
                                {
                                    new RoomModifierDataBuilder
                                    {
                                    RoomModifierID = "_MacrophageSynthesisRoom",
                                    RoomModifierClassType = typeof(CustomRoomStateAttackForContagion),
                                    Description = "Has [attack] equal to the amount of <b>Contagion</b> on this floor.",
                                    DescriptionInPlay = "Has [attack] equal to the amount of <b>Contagion</b> on this floor.",
                                    ParamInt = 1,
                                    }
                                },
                                /*StatusEffectUpgrades =
                                {   new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Quick,
                                        count = 1
                                    }
                                },*/
                                /*TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CharacterTriggerData.Trigger.OnKill,
                                        Description = "+2[attack].",
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
                                }*/

                            },
                            /*TriggerBuilders =
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
                                },*/
                                /*new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID,
                                    Trigger = CharacterTriggerData.Trigger.OnAnyHeroDeathOnFloor,
                                    Description = "Whenever a unit with <b>Contagion</b> dies, gain [attack] equal to its <b>Contagion</b> stacks.",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                                            TargetTeamType = Team.Type.Monsters,
                                            TargetMode = TargetMode.Self,
                                            //ParamInt = 1,
                                            ShouldTest = true,
                                            ParamCardUpgradeData = new CardUpgradeDataBuilder
                                            {
                                                UpgradeID = "RoamingMacrophageUpgrade",                                                
                                                //BonusHP = 0,
                                                BonusDamage = 0,
                                            }.Build(),
                                        }
                                    }
                                },*/
                            },

                        },

                    }

            }.BuildAndRegister();



        }
    }
}

