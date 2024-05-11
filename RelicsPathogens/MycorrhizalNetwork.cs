using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;

namespace RelicsPathogens
{
    //this is a dummy relic. The actual effect for this is found in CustomTriggerBetterRally
    internal class MycorrhizalNetwork
    {

        public static CollectableRelicData Artifact;
        public static readonly string ID = Rats.GUID + "_MycorrhizalNetwork";
        public static bool HasIt()

        {
            if (Artifact != null)
            {
                return ProviderManager.SaveManager.GetHasRelic(Artifact);
            }
            return false;
        }

        public static CollectableRelicData BuildandRegister()
        {
           Artifact = new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_MycorrhizalNetwork",
                Name = "Mycorrhizal Network",
                Description = "<b>Culture</b> abilities trigger when a unit is played on any floor.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/NetworkArtifact.png",
                ClanID = Clan.ID,
               
                Rarity = CollectableRarity.Common
            }.BuildAndRegister();
            return Artifact;
        }
    }

}
