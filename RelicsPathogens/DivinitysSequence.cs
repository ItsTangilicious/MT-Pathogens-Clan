using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Test_Bounce;

namespace RelicsPathogens
{
    internal class DivinitysSequence
    {
        public static readonly string ID = Rats.GUID + "_DivinitysGrace";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_DivinitysGrace",
                Name = "Divinity Sequence",
                Description = "All firendly units gain [multistrike] <b>1</b>. At the end of each combat, gain 10 <sprite name=\"PactShards\">.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/DivinitySequenceArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
            {
                new RelicEffectDataBuilder
                {
                    RelicEffectClassType = typeof(RelicEffectAddTempUpgrade),
                    ParamSourceTeam = Team.Type.Monsters,
                    ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                    {
                        UpgradeID = "DivinitySequenceUpgrade",
                        StatusEffectUpgrades = new List<StatusEffectStackData>
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Multistrike,
                                count = 1,
                            }
                        }
                    }

                },
                new RelicEffectDataBuilder
                {
                    RelicEffectClassType = typeof(RelicEffectGainShardsAfterBoss),
                    ParamInt = 10,

                },
                
            },
                Rarity = CollectableRarity.Common,
               
            }.BuildAndRegister();

        }
    }
}
