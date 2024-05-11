using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Test_Bounce;

namespace RelicsPathogens
{
    internal class HerzalsInsight
    {
        
        public static readonly string ID = Rats.GUID + "_HerzalsInsight";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_HerzalsInsight",
                Name = "Herzal's Anvil",
                Description = "Units with 3 or more [size] gain <b>Trample</b>.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/HerzalsAnvilArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
            {
                new RelicEffectDataBuilder
                {
                    RelicEffectClassType = typeof(RelicEffectAddTempUpgrade),
                    ParamSourceTeam = Team.Type.Monsters,
                    ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                    {
                        UpgradeID = "HerzalsInsightUpgrade",
                        StatusEffectUpgrades = new List<StatusEffectStackData>
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Trample,
                                count = 1,
                            }
                        },
                        Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = "HerzalsInsightFilter",
                                            CardType = CardType.Monster,
                                            ExcludedSizes = new List<int>
                                            {
                                                1, 2
                                            }
                                        }.Build()
                        }
                    }

                },
                

            },
                Rarity = CollectableRarity.Common,

            }.BuildAndRegister();

        }
    }
}

