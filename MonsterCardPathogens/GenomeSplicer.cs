using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.PathogenSubtype;
using CustomEffectsPathogens;
using HellPathogens.HostSubtype;


namespace MonsterCardPathogens
{
    internal class GenomeSplicer
    {
        public static readonly string ID = Rats.GUID + "_GenomeSplicerCard";
        public static readonly string CharID = Rats.GUID + "_GenomeSplicerCharacter";
        public static readonly string TriggerID = Rats.GUID + "_GenomeSplicerRally";
        public static readonly string SynthesisTriggerID = Rats.GUID + "_GenomeSplicerEssenceRally";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Spliced Monstrosity",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/SplicedMonstrosityCard.png",
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
                            Name = "Spliced Monstrosity",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 10,
                            AssetPath = "AssetsAll/MonsterAssets/SplicedMonstrosityCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { HostSubtype.Host },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "GenomeSplicerSynthesis",
                                UpgradeDescription = "'<b>Culture:</b> Gain [spikes] <b>3</b>.'",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 0,
                                LinkedPactDuplicateRarity = CollectableRarity.Rare,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        TriggerID = SynthesisTriggerID,
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
                                                        statusId = VanillaStatusEffectIDs.Spikes,
                                                        count = 3,
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
                                    Description = "Gain <b>Shard <nobr>[effect0.status0.power]</nobr></b>.",
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
                                                      count = 1
                                                 }
                                            }
                                        },

                                    }
                                },
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = "GenomeSplicerResolveTrigger",
                                    Trigger = CharacterTriggerData.Trigger.OnTurnBegin,
                                    Description = "Gain [spikes] <b><nobr>[effect0.status0.power]</nobr></b> per <b>Shard</b>.",
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.Self,
                                            TargetTeamType = Team.Type.Monsters,
                                            UseStatusEffectStackMultiplier = true,
                                            StatusEffectStackMultiplier = VanillaStatusEffectIDs.Shard,
                                            ParamStatusEffects =
                                            {
                                                new StatusEffectStackData
                                                {
                                                    statusId = VanillaStatusEffectIDs.Spikes,
                                                    count = 1
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


