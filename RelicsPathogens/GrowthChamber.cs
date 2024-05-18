using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Test_Bounce;

namespace RelicsPathogens
{
    internal class GrowthChamber
    {
        public static readonly string ID = Rats.GUID + "_GrowthChamberRelic";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_GrowthChamberRelic",
                Name = "Bottled Terrarium",
                Description = "Every 2 units you play this battle, all cards gain +1 Magic Power for the rest of this battle.",
                RelicActivatedKey = "RelicsPathogens_com.Tang.Rats.generic_GrowthChamberRelic_Activated_Key",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/GrowthChamberArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
            {
                new RelicEffectDataBuilder
                {
                    RelicEffectClassType = typeof(RelicEffectModifyCardMagicPowerOnCardPlayed),
                    ParamSourceTeam = Team.Type.Monsters,
                    ParamInt = 1,
                    EffectConditionBuilders =
                    {
                        new RelicEffectConditionBuilder
                        {
                            ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,
                            ParamCardType = CardStatistics.CardTypeTarget.Monster,
                            ParamEntryDuration = CardStatistics.EntryDuration.ThisBattle,
                            AllowMultipleTriggersPerDuration = true,
                            ParamInt = 2,
                        }
                    }

                }
            
                
                },
                Rarity = CollectableRarity.Common
            }.BuildAndRegister();

        }
    }
}
