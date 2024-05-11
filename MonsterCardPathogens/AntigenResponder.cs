using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.PathogenSubtype;
using CustomEffectsPathogens;


namespace MonsterCardPathogens 
{
    class AntigenResponderMonster
    {
        public static readonly string ID = Rats.GUID + "_AntigenResponderCard";
        public static readonly string CharID = Rats.GUID + "_AntigenResponderCharacter";
        public static readonly string TriggerID = Rats.GUID + "_AntigenResponderRally";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Antigen Mimic",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/AntigenMimicCard.png",
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
                            Name = "Antigen Mimic",
                            Size = 2,
                            Health = 30,
                            AttackDamage = 20,
                            AssetPath = "AssetsAll/MonsterAssets/AntigenMimicCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "AntigenResponderSynthesis",
                                UpgradeDescription = "+10[health] and '<b>Culture:</b> Apply [regen] <b>2</b> to all friendly units.'",
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
                                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                                TargetMode = TargetMode.Room,
                                                TargetTeamType = Team.Type.Monsters,
                                                ParamStatusEffects =
                                                {
                                                    new StatusEffectStackData
                                                    {
                                                        statusId = VanillaStatusEffectIDs.Regen,
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
                                    Description = "Restore [effect1.power] health to all friendly units and apply <nobr>[regen] [effect0.status0.power]</nobr>",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamStatusEffects =
                                            {
                                                 new StatusEffectStackData
                                                 {
                                                      statusId = VanillaStatusEffectIDs.Regen,
                                                      count = 2
                                                 }
                                            }
                                        },
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectHeal),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 5
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
