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
    internal class MassHallucinations
    {
        public static readonly string ID = Rats.CLANID + "_MassHallucinations";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Mass Hallucinations",
                //Description =,
                //Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                //TargetsRoom = true,
                //Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/MassHallucSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                     new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitUnplayable)
                   },
                },                
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_MassHallucinationsReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply [dazed] <b><nobr>[effect0.status0.power]</nobr></b> to all units on the floor where your turn ended.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Dazed,
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
