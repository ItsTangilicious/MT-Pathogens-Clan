using CustomEffectsPathogens;
using HellPathogens.Clan;
using HellPathogens.PathogenSubtype;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;

namespace MonsterCardPathogens 
{
    class RecombinantVirusMonster

    {
        public static readonly string ID = Rats.GUID + "_RecombinantVirus";
        public static readonly string CharID = Rats.GUID + "_RecombinantVirusCharacter";
        public static readonly string TriggerID = Rats.GUID + "_RecombinantVirus";
        public static readonly string CardPID = Rats.GUID + "_RecombinantVirusCardPool";
        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Recombinant Virus",
                Cost = 0,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Starter,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/VirionCard.png",
                ClanID = Clan.ID,
                CardPoolIDs = {  },
                TraitBuilders =
                {
                   /* I was using this scaling effect for damage, but for some reason the extinguish effect doesn't work with SummonEffectShedding???
                    new CardTraitDataBuilder
                   {
                        
                        TraitStateType = typeof(CardTraitScalingAddDamage),
                        ParamTrackedValue = CardStatistics.TrackedValueType.MonsterSubtypePlayed,
                        ParamSubtype = PathogenSubtype.Pathogen,
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 1,
                        ParamTeamType = Team.Type.Monsters
                    } 
                   */
                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectSpawnMonster),
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = CharID,
                            Name = "Recombinant Virus",
                            Size = 1,
                            Health = 1,
                            AttackDamage = 0,
                            AssetPath = "AssetsAll/MonsterAssets/VirionCharacter.png",
                            PriorityDraw = false,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "RecombinantVirusSynthesis",
                                UpgradeDescription = "Has science gone too far?!?",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 0,
                                BonusHP = 0,
                                LinkedPactDuplicateRarity = CollectableRarity.Rare,
                            },
                            TriggerBuilders =
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID,
                                    Trigger = CharacterTriggerData.Trigger.OnDeath,
                                    Description = "When this unit dies, apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b> to all enemy units.",
                                    EffectBuilders =
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Heroes,
                                            //Non-scaling ParamInt
                                            //ParamInt = 4
                                            ParamStatusEffects =
                                            {
                                                 new StatusEffectStackData
                                                 {
                                                      statusId = StatusEffectContagion.statusID,
                                                      count = 4
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

            var cardPool = new CardPoolBuilder
            {
                CardPoolID = CardPID,
                CardIDs = { RecombinantVirusMonster.ID }
            }.BuildAndRegister();
        }
    }
}
