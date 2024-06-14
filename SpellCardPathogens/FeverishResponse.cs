using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;

namespace SpellCardPathogens
{
    internal class FeverishResponse
    {
        public static readonly string ID = Rats.CLANID + "_FeverishResponse";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Feverish Response",
                Description = "Deal <nobr>[effect0.power]</nobr> damage to the front enemy unit. Then deal <nobr>[effect0.power]</nobr> damage to the front friendly unit.",
                Cost = 1,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/FeverishSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitStrongerMagicPower),
                        ParamInt = 5,
                    }
                },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CardEffectDamage),
                        TargetMode = TargetMode.FrontInRoom,
                        TargetTeamType = Team.Type.Heroes,
                        ParamInt = 50
                     },
                      new CardEffectDataBuilder
                     {
                        EffectStateType = typeof(CardEffectDamage),
                        TargetMode = TargetMode.FrontInRoom,
                        TargetTeamType = Team.Type.Monsters,
                        ParamInt = 50
                     },
                }
            }.BuildAndRegister();
        }
    } 
}
