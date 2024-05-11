using HellPathogens.Clan;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using CustomEffectsPathogens;

namespace SpellCardPathogens
{
    internal class RoomForGrowth
    {
        public static readonly string ID = Rats.GUID + "_RoomForGrowth";

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
                Name = "Room for Growth",
                Description = "+2[size] and summon 1 Recombinant Virus to the front of this floor.",
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/RoomForGrowthSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAdjustRoomCapacity),
                        TargetTeamType = Team.Type.None,
                        TargetMode = TargetMode.Room,
                        ParamInt = 2
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