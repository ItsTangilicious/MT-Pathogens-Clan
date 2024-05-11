using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;

namespace SpellCardPathogens
{
    internal class IntroToBiology
    {
        public static readonly string ID = Rats.CLANID + "_IntroToBiology";
        public static readonly string MaskID = Rats.GUID + "_IntroToBiologyMask";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Intro To Biology",
                Description = "Draw a unit and reduce its cost by 1[ember]. -1 draw next turn.",
                Cost = 0,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/IntroToBioSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                   new CardTraitDataBuilder
                   {
                       TraitStateType = typeof(CardTraitExhaustState)
                   },                    
                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddTempCardUpgradeToNextDrawnCard),
                        TargetTeamType = Team.Type.None,
                        ShouldTest = false,                        
                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_IntroToBiologyUpgrade",
                                    CostReduction = 1,                                    
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = MaskID,
                                            CardType = CardType.Monster
                                        }.Build()
                                    }
                                }.Build(),
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectDrawType),
                        TargetMode = TargetMode.DrawPile,
                        TargetTeamType = Team.Type.None,
                        TargetCardType = CardType.Monster,
                        ParamInt = 1,
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType =  typeof(CardEffectDrawAdditionalNextTurn),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamInt = -1,
                    }
                }

            }.BuildAndRegister();
        }
    }
}
