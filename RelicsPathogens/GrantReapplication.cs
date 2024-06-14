using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;

namespace RelicsPathogens
{
    internal class GrantReapplication
    {
        public static readonly string ID = Rats.GUID + "_GrantReapplicationRelic";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_GrantReapplicationRelic",
                Name = "Grant Reapplication",
                Description = "Earn 25% more [coin]. (Rounded down to the nearest 5[coin].)",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/GrantREapplicationArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
            {
                new RelicEffectDataBuilder
                {
                    RelicEffectClassType = typeof(RelicEffectChangeGoldReward),
                    ParamFloat = 1.25f,
                   
                }
            },
                Rarity = CollectableRarity.Common
            }.BuildAndRegister();

        }
    }
}
