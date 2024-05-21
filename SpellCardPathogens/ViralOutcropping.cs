using HellPathogens.Clan;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using CustomEffectsPathogens;



namespace SpellCardPathogens 
{
    class ViralOutcroppingSpell
    {
        public static readonly string ID = Rats.GUID + "_ViralOutcropping";

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
                Name = "Viral Outcropping",
                Description = "Summon 3 Recombinant Virus to the front of this floor.",
                Cost = 2,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/ViralOutcroppingSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                    /*new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },*/
                    effect, effect, effect
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

