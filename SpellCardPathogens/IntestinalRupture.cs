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
    internal class IntestinalRupture
    {

        public static readonly string ID = Rats.CLANID + "_IntestinalRupture";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = "_IntestinalRupture",
                Name = "Intestinal Rupture",
                Description = "Deal <nobr>[effect0.power]</nobr> damage and apply <b>Contagion <nobr>[effect1.status0.power]</nobr></b> to an enemy unit.",
                Cost = 1,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/IntestinalSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
            {
            new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.DropTargetCharacter,
                TargetTeamType = Team.Type.Heroes,
                ParamInt = 2
            },
            new CardEffectDataBuilder
                {
                    EffectStateType = typeof(CardEffectAddStatusEffect),
                    TargetMode = TargetMode.DropTargetCharacter,
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

