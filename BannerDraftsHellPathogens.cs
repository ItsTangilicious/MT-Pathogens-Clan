using HellPathogens.Clan;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using MonsterCardPathogens;


namespace Hellpathogens.Misc
{
    class BannerDraftsHellPathogens
    {
        public static readonly string ID = Rats.GUID + "_Banner";
        public static readonly string RewardID = Rats.GUID + "_BannerReward";
        public static readonly string CardPoolID = Rats.GUID + "_BannerUnits";

        public static void BuildAndRegister()
        {
            CardPool cardPool = new CardPoolBuilder
            {
                CardPoolID = CardPoolID,
                CardIDs =
                {
                    AntigenResponderMonster.ID,
                    AsymptomaticCarrier.ID,
                    BorreliaDaemonium.ID,
                    GenomeSplicer.ID,
                    Plaguebringer.ID,
                    RoamingMacrophage.ID,
                    SimplexvirusDiabolicusMonster.ID,
                    VibrioInfernum.ID,
                    Virodaemonologist.ID,
                    

                },
            }.BuildAndRegister();

            new RewardNodeDataBuilder()
            {
                RewardNodeID = ID,
                MapNodePoolIDs =
                {
                    VanillaMapNodePoolIDs.RandomChosenMainClassUnit,
                    VanillaMapNodePoolIDs.RandomChosenSubClassUnit
                },
                Name = "Hellborne Pathogens",
                Description = "Gain a Hellborne Pathogens unit.",
                RequiredClassID = Clan.ID,
                ControllerSelectedOutline = "AssetsAll/ClanAssets/TestClanBanner_ControllerSelectedOutline.png",
                FrozenSpritePath = "AssetsAll/ClanAssets/PathogensBanner_Frozen.png",
                EnabledSpritePath = "AssetsAll/ClanAssets/PathogensBanner_Enabled.png",
                EnabledVisitedSpritePath = "AssetsAll/ClanAssets/TestClanBanner_Enabled_Visited.png",
                DisabledSpritePath = "AssetsAll/ClanAssets/PathogensBanner_Disabled.png",
                DisabledVisitedSpritePath = "AssetsAll/ClanAssets/TestClanBanner_Disabled_Visited.png",
                GlowSpritePath = "AssetsAll/ClanAssets/Pathogens_Glow.png",
                MapIconPath = "AssetsAll/ClanAssets/PathogensBanner_Enabled.png",
                MinimapIconPath = "AssetsAll/ClanAssets/TestClanBanner_Minimap.png",
                SkipCheckInBattleMode = true,
                OverrideTooltipTitleBody = false,
                NodeSelectedSfxCue = "Node_Banner",
                RewardBuilders =
                {
                    new DraftRewardDataBuilder()
                    {
                        DraftRewardID = RewardID,
                        AssetPath = "AssetsAll/ClanAssets/PathogensBanner_Enabled.png",
                        Name = "Hellborne Pathogens Banner",
                        Description = "Choose a card!",
                        Costs = new int[] { 100 },
                        IsServiceMerchantReward = false,
                        DraftPool = cardPool,
                        ClassType = RunState.ClassType.MainClass | RunState.ClassType.SubClass | RunState.ClassType.NonClass,
                        DraftOptionsCount = 2,
                        RarityFloorOverride = CollectableRarity.Uncommon
                    }
                }

            }.BuildAndRegister();
        }
        }
    }

