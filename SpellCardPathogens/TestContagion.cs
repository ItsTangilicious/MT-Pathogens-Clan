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
    internal class TestContagion
    {

        public static readonly string ID = Rats.CLANID + "_Flea";
        public static CardData Card;

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Flea",
                Description = "Apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b> to an enemy unit.",
                Cost = 1,
                Rarity = CollectableRarity.Starter,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/FleaSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                //CardPoolIDs = new List<string> { },
                EffectBuilders =
            {
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

