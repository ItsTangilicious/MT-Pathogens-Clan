using System;
using System.Collections.Generic;
using System.Text;
using HellPathogens.Clan;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Test_Bounce;
using HellPathogens.InstrumentSubtype;
using CustomEffectsPathogens;
//using Trainworks.Constants;



namespace MonsterCardPathogens
{
    internal class CryogenicStorage
    {
        public static readonly string ID = Rats.GUID + "_CryogenicStorageCard";
        public static readonly string CharID = Rats.GUID + "_CryogenicStorageCharacter";
        public static readonly string TriggerID = Rats.GUID + "_CryogenicStorageSummon";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Cryogenic Storage",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                AssetPath = "AssetsAll/MonsterAssets/CryogenicCard.png",
                ClanID = Clan.ID,
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitFreeze)
                    },
                    
                },
                TriggerBuilders = new List<CardTriggerEffectDataBuilder>
                {                  
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = "CryogenicStorageReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Gain <b>Shard <nobr>[effect0.upgrade.count]</nobr></b>.",
                        CardEffectBuilders = new List<CardEffectDataBuilder>

                        {
                            new CardEffectDataBuilder
                            {
                               EffectStateType = typeof(CardEffectAddTempUpgrade),
                               TargetMode = TargetMode.Self,
                               //TargetTeamType = Team.Type.None,
                               ParamCardUpgradeData = new CardUpgradeDataBuilder
                               {
                                   UpgradeID = "CryogenicReserveUpgrade",
                                   StatusEffectUpgrades = new List<StatusEffectStackData>
                                   {
                                       new StatusEffectStackData
                                       {
                                       statusId = VanillaStatusEffectIDs.Shard,
                                       count = 1
                                       }
                                   }
                               
                                     
                               
                               }.Build(),
                            },
                        }
                    },
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
                            Name = "Cryogenic Storage",
                            Size = 1,
                            Health = 5,
                            AttackDamage = 0,
                            AssetPath = "AssetsAll/MonsterAssets/CryogenicCharacter.png",
                            PriorityDraw = false,
                            SubtypeKeys = { InstrumentSubtype.Instrument },
                            
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "CryogenicStorageSynthesis",
                                UpgradeDescription = "-10[attack], <b>Frozen</b>, and '<b>Resolve:</b> Return a random consumed spell to your hand.'",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = -10,
                                BonusHP = 0,
                                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                                {
                                    new CharacterTriggerDataBuilder
                                    {
                                        Trigger = CharacterTriggerData.Trigger.PostCombat,
                                        EffectBuilders = new List<CardEffectDataBuilder>
                                        {
                                            new CardEffectDataBuilder
                                            {
                                                EffectStateType = typeof(CardEffectRecursion),
                                                TargetMode = TargetMode.Exhaust,
                                                TargetTeamType = Team.Type.None,
                                                TargetCardSelectionMode = CardEffectData.CardSelectionMode.RandomToHand,
                                                ParamInt = 1,
                                                //ParamTimingDelays ?
                                                HideTooltip = true,
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
                                    Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                    Description = "Return a random consumed spell to your hand for each <b>Shard</b>.",
                                    EffectBuilders =
                                    {                                        
                                        new CardEffectDataBuilder
                                        {
                                            //EffectStateType = typeof(CardEffectRecursion),
                                            EffectStateType = typeof(CardEffectSheddingReturnConsumed),
                                            TargetMode = TargetMode.Exhaust,
                                            TargetTeamType = Team.Type.None,
                                            TargetCardSelectionMode = CardEffectData.CardSelectionMode.RandomToHand,
                                            //UseStatusEffectStackMultiplier = true,
                                            //StatusEffectStackMultiplier = VanillaStatusEffectIDs.Shard,
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
