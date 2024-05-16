using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;

namespace SpellCardPathogens
{
    internal class MultistrandedRNA
    {
            public static readonly string ID = Rats.CLANID + "_MultistrandRNA";

            public static void BuildAndRegister()
            {
                new CardDataBuilder
                {
                    CardID = ID,
                    Name = "Multistrand DNA",
                    Description = "Apply <b>Replicate</b>, <b>Melee Weakness <nobr>[effect2.status0.power]</nobr></b>, and <nobr>[multistrike] [effect0.status0.power]</nobr> to a friendly unit.",
                    Cost = 3,
                    Rarity = CollectableRarity.Rare,
                    TargetsRoom = true,
                    Targetless = false,
                    ClanID = Clan.ID,
                    AssetPath = "AssetsAll/SpellAssets/MultistrandedSpell.png",
                    CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                    EffectBuilders =
                    {
                        new CardEffectDataBuilder
                        {
                            EffectStateType = typeof(CardEffectAddStatusEffect),
                            TargetMode = TargetMode.DropTargetCharacter,
                            TargetTeamType = Team.Type.Monsters,
                            ParamStatusEffects =
                            {
                                new StatusEffectStackData
                                {
                                    statusId = VanillaStatusEffectIDs.Multistrike,
                                    count =  1
                                }
                            }

                        },

                        new CardEffectDataBuilder
                        {
                            EffectStateType = typeof(CardEffectAddStatusEffect),
                            TargetMode = TargetMode.DropTargetCharacter,
                            TargetTeamType = Team.Type.Monsters,
                            ParamStatusEffects =
                            {
                                new StatusEffectStackData
                                {
                                    statusId = StatusEffectReplicate.statusID,
                                    count =  1
                                }
                            }


                        },

                                               
                        new CardEffectDataBuilder
                        {
                            EffectStateType = typeof(CardEffectAddStatusEffect),
                            TargetMode = TargetMode.DropTargetCharacter,
                            TargetTeamType = Team.Type.Monsters,
                            ParamStatusEffects =
                            {
                                new StatusEffectStackData
                                {
                                    statusId = VanillaStatusEffectIDs.MeleeWeakness,
                                    count =  2
                                }
                            }

                        },

                    },
                    TraitBuilders =
                    {
                        new CardTraitDataBuilder
                        {
                            TraitStateType = typeof(CardTraitExhaustState)
                        }
                    }
                }.BuildAndRegister();
            }
    }
}

