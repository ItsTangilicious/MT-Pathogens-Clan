using HellPathogens.Clan;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using CustomEffectsPathogens;

namespace SpellCardPathogens
{
    internal class SpecimenCatalog
    {
        public static readonly string ID = Rats.CLANID + "_SpecimenCatalog";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Specimen Catalog",
                Description = "Gain +<nobr>{[trait1.power]}[ember]</nobr> for each unit summoned this battle.",
                Cost = 0,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/SpecimenSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   },
                    new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingAddEnergy,
                        ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 1,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Monsters

                    },

                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType =  typeof(CardEffectAdjustEnergy),
                        ParamInt = 0,
                    }
                }

            }.BuildAndRegister();
        }
    }
}
