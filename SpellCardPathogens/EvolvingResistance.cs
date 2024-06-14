using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;
using HellPathogens.CardPools;
using HarmonyLib;
using Trainworks.Managers;
using System.Collections.Generic;

namespace SpellCardPathogens
{
    internal class EvolvingResistance
    {
        public static readonly string ID = Rats.CLANID + "_EvolvingResistance";

        public static void BuildandRegister()
        {
            CardPool cardPool1 = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            CardPool cardPool2A = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            CardPool cardPool2B = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            CardPool cardPool3A = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            CardPool cardPool3B = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            CardPool cardPool3C = UnityEngine.ScriptableObject.CreateInstance<CardPool>();

            CardDataBuilder evolvingResistanceCard = new CardDataBuilder
            {
                CardID = ID,
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to friendly units. Upgrade this play effect.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EvolvingSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },                
                TraitBuilders =
                {
                     new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitSelfPurge)
                   },
                      new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CustomCardTraitReserveAndPurge)
                   },
                },
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
                                statusId = VanillaStatusEffectIDs.Armor,
                                count =  5
                            }
                        }
                     },
                     new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectAddRunCard),
                         CopyModifiersFromSource = true,
                         TargetTeamType = Team.Type.Monsters,
                         ParamInt = ((int)CardPile.DiscardPile),
                         AdditionalParamInt = 1,
                         ParamCardPool = cardPool2A

                     }
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistanceReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to the front friendly unit. Upgrade this <b>Reserve</b> effect and trigger <b>Purge</b>.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count =  5
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddRunCard),
                                CopyModifiersFromSource = true,
                                //TargetTeamType = Team.Type.None,
                                ParamInt = ((int)CardPile.DiscardPile),
                                AdditionalParamInt = 1,
                                ParamCardPool = cardPool2B

                            }
                        }

                    }
                }

            };
            CardData forPool1 = evolvingResistanceCard.BuildAndRegister();

            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool1);
            cardDataList.Add(forPool1);

            CardDataBuilder evolvingResistanceCard2A = new CardDataBuilder
            {
                CardID = Rats.CLANID + "_EvolvingResistance2A",
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> and [rage] <b><nobr>[effect1.status0.power]</nobr></b> to friendly units. Upgrade this play effect.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EvolvingSpell.png",
                CardPoolIDs = { },
                IgnoreWhenCountingMastery = true,
                LinkedMasteryCard = CustomCardManager.GetCardDataByID(evolvingResistanceCard.CardID),
                TraitBuilders =
                {
                     new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitSelfPurge)
                   },
                      new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CustomCardTraitReserveAndPurge)
                   },
                },
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
                                statusId = VanillaStatusEffectIDs.Armor,
                                count =  5
                            }
                        }
                     },
                     new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Rage,
                                count = 3
                            }
                        }
                     },
                     new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectAddRunCard),
                         CopyModifiersFromSource = true,
                         TargetTeamType = Team.Type.None,
                         ParamInt = ((int)CardPile.DiscardPile),
                         AdditionalParamInt = 1,
                         ParamCardPool = cardPool3A

                     }
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistanceReserve2A",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to the front friendly unit. Upgrade this <b>Reserve</b> effect and trigger <b>Purge</b>.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count =  5
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddRunCard),
                                CopyModifiersFromSource = true,
                                TargetTeamType = Team.Type.None,
                                ParamInt = ((int)CardPile.DiscardPile),
                                AdditionalParamInt = 1,
                                ParamCardPool = cardPool3B

                            }
                        }

                    }
                }

            };
            CardData forPool2A = evolvingResistanceCard2A.BuildAndRegister();

            var cardDataList2A = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool2A);
            cardDataList2A.Add(forPool2A);

            CardDataBuilder evolvingResistanceCard2B = new CardDataBuilder
            {
                CardID = Rats.CLANID + "_EvolvingResistance2B",
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to friendly units. Upgrade this play effect.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EvolvingSpell.png",
                CardPoolIDs = { },
                IgnoreWhenCountingMastery = true,
                LinkedMasteryCard = CustomCardManager.GetCardDataByID(evolvingResistanceCard.CardID),
                TraitBuilders =
                {
                     new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitSelfPurge)
                   },
                    new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CustomCardTraitReserveAndPurge)
                   },
                },
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
                                statusId = VanillaStatusEffectIDs.Armor,
                                count =  5
                            }
                        }
                     },
                     new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectAddRunCard),
                         CopyModifiersFromSource = true,
                         TargetTeamType = Team.Type.None,
                         ParamInt = ((int)CardPile.DiscardPile),
                         AdditionalParamInt = 1,
                         ParamCardPool = cardPool3B

                     }
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistance2BReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> and [rage] <b><nobr>[effect1.status0.power]</nobr></b> to the front friendly unit. Upgrade this <b>Reserve</b> effect and trigger <b>Purge</b>.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count =  5
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Rage,
                                        count =  2
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddRunCard),
                                CopyModifiersFromSource = true,
                                TargetTeamType = Team.Type.None,
                                ParamInt = ((int)CardPile.DiscardPile),
                                AdditionalParamInt = 1,
                                ParamCardPool = cardPool3C

                            },

                        }

                    }
                }
            };
            CardData forPool2B = evolvingResistanceCard2B.BuildAndRegister();

            var cardDataList2B = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool2B);
            cardDataList2B.Add(forPool2B);

            CardDataBuilder evolvingResistanceCard3A = new CardDataBuilder
            {
                CardID = Rats.CLANID + "_EvolvingResistance3A",
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b>, [rage] <b><nobr>[effect1.status0.power]</nobr></b>, and [lifesteal] <b><nobr>[effect2.status0.power]</nobr></b> to friendly units.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EvolvingSpell.png",
                CardPoolIDs = { },
                IgnoreWhenCountingMastery = true,
                LinkedMasteryCard = CustomCardManager.GetCardDataByID(evolvingResistanceCard.CardID),
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
                                statusId = VanillaStatusEffectIDs.Armor,
                                count = 5
                            }
                        }
                     },
                     new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Rage,
                                count = 3
                            }
                        }
                     },
                      new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Lifesteal,
                                        count = 1
                                    }
                                }
                      }
                },

                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistance3AReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to the front friendly unit.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count = 5
                                    }
                                }
                            },

                        }

                    }
                }
            };
            CardData forPool3A = evolvingResistanceCard3A.BuildAndRegister();

            var cardDataList3A = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool3A);
            cardDataList3A.Add(forPool3A);

            CardDataBuilder evolvingResistanceCard3B = new CardDataBuilder
            {
                CardID = Rats.CLANID + "_EvolvingResistance3B",
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> and [rage] <b><nobr>[effect1.status0.power]</nobr></b> to friendly units.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EvolvingSpell.png",
                CardPoolIDs = { },
                IgnoreWhenCountingMastery = true,
                LinkedMasteryCard = CustomCardManager.GetCardDataByID(evolvingResistanceCard.CardID),
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
                                statusId = VanillaStatusEffectIDs.Armor,
                                count = 6
                            }
                        }
                     },
                     new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Rage,
                                        count = 3
                                    }
                                }
                            }
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistance3BReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> and [rage] <b><nobr>[effect1.status0.power]</nobr></b> to the front friendly unit.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count = 6
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Rage,
                                        count = 3
                                    }
                                }
                            },
                        }

                    }
                }
            };
            CardData forPool3B = evolvingResistanceCard3B.BuildAndRegister();

            var cardDataList3B = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool3B);
            cardDataList3B.Add(forPool3B);

            CardDataBuilder evolvingResistanceCard3C = new CardDataBuilder
            {
                CardID = Rats.CLANID + "_EvolvingResistance3C",
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to friendly units.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EvolvingSpell.png",
                CardPoolIDs = { },
                IgnoreWhenCountingMastery = true,
                LinkedMasteryCard = CustomCardManager.GetCardDataByID(evolvingResistanceCard.CardID),
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
                                statusId = VanillaStatusEffectIDs.Armor,
                                count =  5
                            }
                        }
                     },
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_EvolvingResistance3CReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b>, [rage] <b><nobr>[effect1.status0.power]</nobr></b>, and [lifesteal] <b><nobr>[effect2.status0.power]</nobr></b> to the front friendly unit.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Armor,
                                        count =  5
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Rage,
                                        count =  2
                                    }
                                }
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.FrontInRoom,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Lifesteal,
                                        count =  1
                                    }
                                }
                            },

                        }

                    }
                }
            };
            CardData forPool3C = evolvingResistanceCard3C.BuildAndRegister();

            var cardDataList3C = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool3C);
            cardDataList3C.Add(forPool3C);


        }
    }
}