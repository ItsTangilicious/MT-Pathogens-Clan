using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using HellPathogens.Clan;
using CustomEffectsPathogens;

namespace SpellCardPathogens
{
    internal class Nausea
    {
        public static readonly string ID = Rats.CLANID + "Nausea";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Nausea",
                Description = "Apply [dazed] <b><nobr>[effect0.status0.power]</nobr></b> and <b>Contagion <nobr>[effect1.status0.power]</nobr></b> to enemy units.",
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/NauseaSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
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
                                statusId = VanillaStatusEffectIDs.Dazed,
                                count =  1
                            }
                        }
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Heroes,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = StatusEffectContagion.statusID,
                                count =  6
                            }
                        }



                    },
                }
            }.BuildAndRegister();
        }
    }
}
