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
using HarmonyLib;


namespace SpellCardPathogens
{
    internal class Virion
    {
        public static readonly string ID = Rats.GUID + "_Virion";
       
        public static void BuildAndRegister()
        {
            /*var effect = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectRecruitsShedding),
                TargetMode = TargetMode.Room,
                TargetTeamType = Team.Type.Monsters,
                ParamCharacterData = CustomCharacterManager.GetCharacterDataByID(RecombinantVirusMonster.CharID),
            };*/

           var virionData = new CardDataBuilder
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
                CardPoolIDs = { },
                LinkedMasteryCard = CustomCardManager.GetCardDataByID(RecombinantVirusMonster.ID),             
                SharedMasteryCards = new List<CardData> { CustomCardManager.GetCardDataByID(RecombinantVirusMonster.ID), },
                EffectBuilders =

                {
                     /*new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },*/
                    //effect
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectRecruitsShedding),
                        ParamCharacterData = CustomCharacterManager.GetCharacterDataByID(RecombinantVirusMonster.CharID),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamAdditionalCharacterData = CustomCharacterManager.GetCharacterDataByID(RecombinantVirusMonster.CharID),

                    }
                },
           

                TraitBuilders =
               {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   }
               },

            }.BuildAndRegister();
            
		AccessTools.Field(typeof(CardData), "sharedDiscoveryCards").SetValue(virionData, new List<CardData> { CustomCardManager.GetCardDataByID(RecombinantVirusMonster.ID) });
		CustomCardManager.RegisterCustomCard(virionData, new List<string>());
        }
    }
}
