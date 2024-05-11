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
                Name = "Hellborn Pathogens Clan Banner",
                Description = "Offers units from the Hellborn Pathogens Clan",
                RequiredClassID = Clan.ID,
                ControllerSelectedOutline = "assets/TestClanBanner_ControllerSelectedOutline.png",
                FrozenSpritePath = "assets/TestClanBanner_Frozen.png",
                EnabledSpritePath = "assets/TestClanBanner_Enabled.png",
                EnabledVisitedSpritePath = "assets/TestClanBanner_Enabled_Visited.png",
                DisabledSpritePath = "assets/TestClanBanner_Disabled.png",
                DisabledVisitedSpritePath = "assets/TestClanBanner_Disabled_Visited.png",
                GlowSpritePath = "assets/TestClanBanner_Glow.png",
                MapIconPath = "assets/TestClanBanner_Enabled.png",
                MinimapIconPath = "assets/TestClanBanner_Minimap.png",
                SkipCheckInBattleMode = true,
                OverrideTooltipTitleBody = false,
                NodeSelectedSfxCue = "Node_Banner",
                RewardBuilders =
                {
                    new DraftRewardDataBuilder()
                    {
                        DraftRewardID = RewardID,
                        AssetPath = "assets/TestClanBanner_Enabled.png",
                        Name = "Test Clan Banner",
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

