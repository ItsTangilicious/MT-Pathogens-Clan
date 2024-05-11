using HellPathogens.Clan;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using CustomEffectsPathogens;

namespace SpellCardPathogens
{
    internal class RampantInfection 
    {
        public static readonly string ID = Rats.CLANID + "_RampantInfection";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Rampant Infection",
                Description = "Deal 2 damage to enemy units for each friendly unit spawned this battle.",
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/RampantInfectionSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingAddDamage,
                        ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 2,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Monsters

                    },                  

                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType =  typeof(CardEffectDamage),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Heroes,
                    }  
                }

            }.BuildAndRegister();
        }
    }
}
