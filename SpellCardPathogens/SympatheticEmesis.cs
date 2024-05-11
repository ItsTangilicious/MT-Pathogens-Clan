using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using HellPathogens.Clan;

namespace SpellCardPathogens
{
    internal class SympatheticEmesis
    {
        public static readonly string ID = Rats.CLANID + "_SympatheticEmesis";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Sympathetic Emesis",
                Description = "Apply [sap] <b><nobr>[effect0.status0.power]</nobr></b>.",
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/EmesisSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                     new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   },
                },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Sap,
                                count =  5
                            }
                        }
                    }, 
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_SympatheticEmesisReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [sap] <b><nobr>[effect0.status0.power]</nobr></b> to enemy units on the floor where your turn ended.",
                        CardEffectBuilders = 
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
                                        statusId = VanillaStatusEffectIDs.Sap,
                                        count =  1
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
