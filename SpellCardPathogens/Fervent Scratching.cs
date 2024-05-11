using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;

namespace SpellCardPathogens
{
    internal class Fervent_Scratching
    {
        public static readonly string ID = Rats.CLANID + "_FerventScratching";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Fervent Scratching",
                Description = "Deal <nobr>[effect0.power]</nobr> damage to a random enemy unit 3 times.",
                Cost = 1,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/FerventScratchingSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.RandomInRoom,
                TargetTeamType = Team.Type.Heroes,
                ParamInt = 3
            },
                    new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.RandomInRoom,
                TargetTeamType = Team.Type.Heroes,
                ParamInt = 3
            },
                    new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectDamage),
                TargetMode = TargetMode.RandomInRoom,
                TargetTeamType = Team.Type.Heroes,
                ParamInt = 3
            },
                },
                TraitBuilders =
               {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitIgnoreArmor)
                   }
               },

            }.BuildAndRegister();
        }
    }
}
