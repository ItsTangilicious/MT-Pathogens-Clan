﻿using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;
using HellPathogens.CardPools;

namespace SpellCardPathogens
    //deleted from the actual mod as it was unused
{
    internal class EvolvingResistance3C
    {
        public static readonly string ID = Rats.CLANID + "_EvolvingResistance3C";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Evolving Resistance",
                Description = "Apply [armor] <b><nobr>[effect0.status0.power]</nobr></b> to friendly units.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "assets/nothornbreak.png",
                CardPoolIDs = { },                             
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
                                count =  10
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

            }.BuildAndRegister();
        }
    }
}
