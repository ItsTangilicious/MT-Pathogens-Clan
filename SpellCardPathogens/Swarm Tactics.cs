using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using HellPathogens.Clan;

namespace SpellCardPathogens
{
    internal class Swarm_Tactics
    {
        public static readonly string ID = Rats.CLANID + "_SwarmTactics";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Swarm Tactics",
                Description = "Give friendly units +<nobr>{[trait0.power]}[attack]</nobr> and [health] for each friendly unit spawned during this battle.",
                Cost = 2,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/SwarmTacticsSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
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

                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType =  VanillaCardEffectTypes.CardEffectAddTempCardUpgradeToUnits,
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ShouldTest = true,

                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "SwarmTacticsUpgrade",
                            BonusDamage = 0,
                            BonusHP = 0,
                        }.Build(),
                    }
                }

            }.BuildAndRegister();
        }
    }
}
