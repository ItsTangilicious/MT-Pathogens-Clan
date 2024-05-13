using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using MonsterCardPathogens;
using Trainworks.Managers;


namespace SpellCardPathogens
{
    internal class Virion
    {
        public static readonly string ID = Rats.GUID + "_Virion";
       
        public static void BuildAndRegister()
        {
            var effect = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectRecruitsShedding),
                TargetMode = TargetMode.Room,
                TargetTeamType = Team.Type.Monsters,
            };

            new CardDataBuilder
            {
                CardID = ID,
                Name = "Virion",
                Description = "Summon 1 Recombinant Virus to the front of this floor.",
                Cost = 1,
                Rarity = CollectableRarity.Starter,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/VirionSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
               
                {
                     new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },
                    effect
                },

                TraitBuilders =
               {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   }
               },

            }.BuildAndRegister();

        }
    }
}
