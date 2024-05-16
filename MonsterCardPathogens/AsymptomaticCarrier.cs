using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.HostSubtype;
using CustomEffectsPathogens;


namespace MonsterCardPathogens
{
    class AsymptomaticCarrier
    {
        public static readonly string ID = Rats.GUID + "_AsymptomaticCarrierCard";
        public static readonly string CharID = Rats.GUID + "_AsymptomaticCarrierCharacter";
        public static readonly string TriggerID = Rats.GUID + "_AsymptomaticCarrierRally";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Asymptomatic Carrier",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/AsymptomaticCard.png",
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
                            Name = "Asymptomatic Carrier",
                            Size = 3,
                            Health = 40,
                            AttackDamage = 10,
                            AssetPath = "AssetsAll/MonsterAssets/AsymptomaticCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { HostSubtype.Host },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "AsymptomaticCarrierSynthesis",
                                UpgradeDescription = "+10[health] and '<b>Culture:</b> Apply <b>Contagion 10</b> to each enemy unit.",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 10,
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
                                                TargetMode = TargetMode.Room,
                                                TargetTeamType = Team.Type.Heroes,
                                                ParamStatusEffects =
                                                {
                                                    new StatusEffectStackData
                                                    {
                                                        statusId = StatusEffectContagion.statusID,
                                                        count = 10,
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
                                    Description = "Apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b> to each enemy unit.",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Heroes,
                                            ParamStatusEffects =
                                            {
                                                 new StatusEffectStackData
                                                 {
                                                      statusId = StatusEffectContagion.statusID,
                                                      count = 10
                                                 }
                                            }
                                        },
                                        
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
