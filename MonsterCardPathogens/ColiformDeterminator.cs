using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.InstrumentSubtype;
using CustomEffectsPathogens;

namespace MonsterCardPathogens
{
    internal class ColiformDeterminator
    {
        public static readonly string ID = Rats.GUID + "_ColiformDeterminatorCard";
        public static readonly string CharID = Rats.GUID + "_ColiformDeterminatorCharacter";
        public static readonly string TriggerID = Rats.GUID + "_ColiformDeterminatorummon";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Coliform Determinator",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/ColiformCard.png",
                ClanID = Clan.ID,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectSpawnMonster),
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = CharID,
                            Name = "Coliform Determinator",
                            Size = 1,
                            Health = 5,
                            AttackDamage = 0,
                            AssetPath = "AssetsAll/MonsterAssets/ColiformCharacter.png",
                            PriorityDraw = false,
                            SubtypeKeys = { InstrumentSubtype.Instrument },

                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "ColiformDeterminatorSynthesis",
                                UpgradeDescription = "-5[attack], -5[health], and <b>Resolve:</b> 'Spawn a copy of a random unit from your deck to the back of this room. This ignores your discard pile.'",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = -5,
                                BonusHP = -5,
                                BonusSize = 0,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CharacterTriggerData.Trigger.PostCombat,
                                        EffectBuilders = new List<CardEffectDataBuilder>
                                        {
                                            new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectSpawnUnitFromDeck),
                                            //TargetMode = TargetMode.DrawPile,
                                            TargetTeamType = Team.Type.None,
                                            TargetCardType = CardType.Monster,
                                            ParamInt = 1,

                                            },
                                        }
                                    }
                                }

                            },

                            TriggerBuilders =
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TriggerID,
                                    Trigger = CharacterTriggerData.Trigger.PostCombat,
                                    Description = "Spawn a copy of a random unit from your deck to the back of this room. This ignores your discard pile.",
                                    EffectBuilders =
                                    {
                                        
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectSpawnUnitFromDeck),
                                            //TargetMode = TargetMode.DrawPile,
                                            TargetTeamType = Team.Type.None,
                                            TargetCardType = CardType.Monster,
                                            ParamInt = 1,
                                        }
                                    }
                                },

                            }

                        }
                    }
                }

            }.BuildAndRegister();
        }

    }
}
