using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;


namespace RelicsPathogens
{
    internal class ResearchNotebook
    {
        public static readonly string ID = Rats.GUID + "_ResearchNotebookRelic";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_ResearchNotebookRelic",
                Name = "Research Notebook",
                Description = "When you summon the second unit during a turn, draw 1 card and gain +1[ember]. ",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/ResearchNotebookArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
            {
                new RelicEffectDataBuilder
                {
                    RelicEffectClassType = typeof(RelicEffectEnergyAndCardDrawOnUnitSpawned),
                    ParamSourceTeam = Team.Type.Monsters,
                    ParamInt = 1,
                    EffectConditionBuilders =
                    {
                        new RelicEffectConditionBuilder
                        {
                            ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,
                            ParamCardType = CardStatistics.CardTypeTarget.Monster,
                            AllowMultipleTriggersPerDuration = false,
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
