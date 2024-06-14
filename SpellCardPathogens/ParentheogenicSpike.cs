using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;


namespace SpellCardPathogens
{
    internal class ParentheogenicSpike
    {
        public static readonly string ID = Rats.GUID + "_ParentheogenicSpike";

        public static void BuildAndRegister()
        {
           
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Hyperlasic Spike",
                Description = "Give a friendly unit  +<nobr>{[trait3.power]}[x][attack]</nobr> and [health], and an additional +<nobr>{[trait1.power]}[attack]</nobr> and [health] for each friendly unit spawned during this battle.",
                Cost = 0,
                CostType = CardData.CostType.ConsumeRemainingEnergy,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/REplicatorSpikeSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
               {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   },
                   new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingUpgradeUnitAttack,
                        ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,                       
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 1,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Monsters

                    },
                     new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingUpgradeUnitHealth,
                        ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 1,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Monsters

                    },
                   
                   new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingUpgradeUnitAttack,
                        ParamTrackedValue = CardStatistics.TrackedValueType.PlayedCost,
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 3,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Monsters

                    },
                     new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitScalingUpgradeUnitHealth,
                        ParamTrackedValue = CardStatistics.TrackedValueType.PlayedCost,
                        ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                        ParamInt = 3,
                        ParamFloat = 1.0f,
                        ParamUseScalingParams = true,
                        ParamTeamType = Team.Type.Monsters

                    },
               },

                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType =  VanillaCardEffectTypes.CardEffectAddTempCardUpgradeToUnits,
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters,
                        ShouldTest = true,

                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "SpikeUpgrade",
                            BonusDamage = 0,
                            BonusHP = 0,
                        }.Build(),
                    }
                }

            }.BuildAndRegister();

        }
    }
}
