using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Test_Bounce;
using Trainworks.Managers;
using HarmonyLib;
using System.Linq;

namespace RelicsPathogens
{
    internal class DivinitysSequence
    {
        public static CollectableRelicData Artifact;

        public static readonly string ID = Rats.GUID + "_DivinitysGrace";

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
                CollectableRelicID = Rats.GUID + "_DivinitysGrace",
                Name = "Divinity Sequence",
                //Description = "All friendly units gain [multistrike] <b>1</b>. At the end of each combat, gain 10 <sprite name=\"PactShards\">.",
                Description = "Your Champion can be upgraded, but all units have one fewer upgrade slots.",
                //Impossible without John's Upgrade Champion mod, thank you!
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/DivinitySequenceArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
                {
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectRemoveUnitUpgradeSlot),
                        ParamSourceTeam = Team.Type.None,
                        
                        }
                    },
            
                /*{
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

                },*/
                Rarity = CollectableRarity.Common,

            }.BuildAndRegister();

            return Artifact;

        }
    }


    [HarmonyPatch(typeof(DeckScreen))]
    [HarmonyPatch("GetCards")]
    internal class AddChampionsToScreen
    {
        private static void Postfix(SaveManager ___saveManager, DeckScreen.Mode ___mode, GrantableRewardData.Source ___rewardSource, AllGameData ___allGameData, RelicManager ___relicManager, CardUpgradeData ___cardUpgradeData, ref List<CardState> __result)
        {
            if (DivinitysSequence.HasIt())
            {
                List<CardState> source = new List<CardState>(___saveManager.GetDeckState());
                source = source.Where((CardState x) => x.IsChampionCard()).ToList();
                if (source.IsNullOrEmpty())
                {
                    return;
                }

                if (___mode != DeckScreen.Mode.ApplyUpgrade)
                {
                    return;
                }
                if (___rewardSource != GrantableRewardData.Source.Event)
                {
                    for (int num2 = source.Count - 1; num2 >= 0; num2--)
                    {
                        CardState cardState = source[num2];
                        int visibleUpgradeCount = cardState.GetVisibleUpgradeCount();
                        BalanceData balanceData = ___allGameData.GetBalanceData();
                        CardType cardType = cardState.GetCardType();
                        if (visibleUpgradeCount >= balanceData.GetUpgradeSlots(cardType, (___relicManager != null) ? ___relicManager.GetRelicEffects<IModifyCardUpgradeSlotCountRelicEffect>() : null))
                        {
                            cardState.CurrentDisabledReason = CardState.UpgradeDisabledReason.NoSlots;
                            break;
                        }
                    }
                }
                List<CardUpgradeMaskData> list = new List<CardUpgradeMaskData>();
                if (___cardUpgradeData != null)
                {
                    if (___cardUpgradeData.name == "TraitRetain" || ___cardUpgradeData.name == "MassiveBuffAnnhilate")
                    {
                        return;
                    }
                    list.AddRange(___cardUpgradeData.GetFilters());
                }
                if (!list.IsNullOrEmpty())
                {
                    for (int num3 = source.Count - 1; num3 >= 0; num3--)
                    {
                        foreach (CardUpgradeMaskData item in list)
                        {
                            CardState cardState2 = source[num3];
                            if (item.FilterCard(cardState2, ___relicManager))
                            {
                                continue;
                            }
                            CardState.UpgradeDisabledReason upgradeDisabledReason = item.GetUpgradeDisabledReason();
                            if (upgradeDisabledReason == CardState.UpgradeDisabledReason.NONE)
                            {
                                if (item.GetName() == "ExcludeQuick" || item.GetName() == "ExcludeEndless" || item.GetName() == "ExcludeSmallest")
                                {
                                    if (!cardState2.IsCurrentlyDisabled())
                                    {
                                        cardState2.CurrentDisabledReason = CardState.UpgradeDisabledReason.NotEligible;
                                    }
                                }
                                else
                                {
                                    source.RemoveAt(num3);
                                }
                            }
                            else if (!cardState2.IsCurrentlyDisabled())
                            {
                                cardState2.CurrentDisabledReason = upgradeDisabledReason;
                            }
                            break;
                        }
                    }
                }
                if (!source.IsNullOrEmpty())
                {
                    __result.AddRange(source);
                }
            }
        }
    }
}
