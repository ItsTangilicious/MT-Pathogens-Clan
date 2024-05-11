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
    internal class Plaguebringer
    {
        public static readonly string ID = Rats.GUID + "_Plaguebringer";
        public static readonly string CharID = Rats.GUID + "_Plaguebringer";
        public static readonly string TriggerID = Rats.GUID + "_PlaguebringerStrike";
        public static readonly string TriggerID2 = Rats.GUID + "_PlaguebringerResolve";
        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Plaguebringer",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/PlaguebringerCard.png",
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
                            Name = "Plaguebringer",
                            Size = 2,
                            Health = 20,
                            AttackDamage = 1,
                            AssetPath = "AssetsAll/MonsterAssets/PlaguebringerCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { HostSubtype.Host },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "PlaguebringerSynthesis",
                                UpgradeDescription = "+5[health] and '<b>Strike:</b> Apply <b>Contagion 6</b>.'",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 5,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                        EffectBuilders = new List<CardEffectDataBuilder>
                                        {
                                            new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                                TargetMode = TargetMode.LastAttackedCharacter,
                                                TargetTeamType = Team.Type.Heroes,
                                                ParamStatusEffects =
                                                {
                                                    new StatusEffectStackData
                                                    {
                                                        statusId = StatusEffectContagion.statusID,
                                                        count = 8,
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
                                    Trigger =  CharacterTriggerData.Trigger.OnAttacking,
                                    Description = "Apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b>.",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.LastAttackedCharacter,
                                            TargetTeamType = Team.Type.Heroes,
                                            ParamStatusEffects =
                                            {
                                                 new StatusEffectStackData
                                                 {
                                                      statusId = StatusEffectContagion.statusID,
                                                      count = 4
                                                 }
                                            }
                                        },
                                       
                                    }

                                },
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID2,
                                    Trigger =  CharacterTriggerData.Trigger.PostCombat,
                                    Description = "Double the amount of <b>Contagion</b> on enemy units",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectMultiplyStatusEffect),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Heroes,
                                            ParamStatusEffects =
                                            {
                                                new StatusEffectStackData 
                                                {
                                                    statusId = StatusEffectContagion.statusID,
                                                    count = 2
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            StartingStatusEffects =
                            {
                                new StatusEffectStackData
                                {
                                    statusId = VanillaStatusEffectIDs.Sweep,
                                    count = 1
                                }
                            }

                        }

                    }
                }
                
            }.BuildAndRegister();
        }

    }
}
