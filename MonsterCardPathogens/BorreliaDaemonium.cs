using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.PathogenSubtype;
using CustomEffectsPathogens;
using HellPathogens.CardPools;
using HarmonyLib;


namespace MonsterCardPathogens
{
    class BorreliaDaemonium
    {
        public static readonly string ID = Rats.GUID + "_BorreliaDaemoniumCard";
        public static readonly string CharID = Rats.GUID + "_BorreliaDaemoniumCharacter";
        public static readonly string TriggerID = Rats.GUID + "_BorreliaDaemoniumSummon";
        public static readonly string SynthesisTriggerID = Rats.GUID + "_BorreliaDaemoniumEssenceSummon";
        public static readonly string CardPID = Rats.GUID + "_BorreliaDaemoniumCardPool";

        public static void BuildAndRegister()
        {
            CardPool cardPool = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            
            CardDataBuilder borreliaCard = new CardDataBuilder
            {
                CardID = ID,
                Name = "Borrelia Daemonium",
                Cost = 2,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/BorreliaCard.png",
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
                            Name = "Borrelia Daemonium",
                            Size = 2,
                            Health = 20,
                            AttackDamage = 20,
                            AssetPath = "AssetsAll/MonsterAssets/BorreliaCharacter.png",
                            PriorityDraw = true,
                            SubtypeKeys = { PathogenSubtype.Pathogen },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "Borrelia Daemonium",
                                UpgradeDescription = "+5[attack], +5[health] and '<b>Summon:</b> Draw a unit.'",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 5,
                                BonusHP = 5,
                                LinkedPactDuplicateRarity = CollectableRarity.Rare,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        TriggerID = TriggerID,
                                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                        EffectBuilders = new List<CardEffectDataBuilder>
                                        {
                                            new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectDrawType),
                                                TargetMode = TargetMode.DrawPile,
                                                TargetTeamType = Team.Type.None,
                                                TargetCardType = CardType.Monster,
                                                ParamInt = 1,
                                            },
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
                                    Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                    Description = "Add a copy of this card to your discard pile. Draw a unit.",
                                    EffectBuilders =
                                    {
                                        
                                        new CardEffectDataBuilder
                                        {
                                            
                                            EffectStateType = typeof(CardEffectAddBattleCard),
                                            CopyModifiersFromSource = true,
                                            ParamInt = ((int)CardPile.DiscardPile),
                                            AdditionalParamInt = 1,
                                            ParamCardPool = cardPool,


                                        },
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectDrawType),
                                            TargetMode = TargetMode.DrawPile,
                                            TargetTeamType = Team.Type.None,
                                            TargetCardType = CardType.Monster,
                                            ParamInt = 1,
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            };
            CardData forPool = borreliaCard.BuildAndRegister();

            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool);
            cardDataList.Add(forPool);
        }

    }
}
