using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;

namespace SpellCardPathogens
{
    internal class BoosterShot
    {
        public static readonly string ID = Rats.CLANID + "_BoosterShot";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Booster Shot",
                Description = "Give a friendly unit +<nobr>4[attack]</nobr>.",
                Cost = 1,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/BoosterSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },               
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType =  VanillaCardEffectTypes.CardEffectAddTempCardUpgradeToUnits,
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters,
                        ShouldTest = true,

                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "BoosterShotUpgrade",
                            BonusDamage = 4,
                            BonusHP = 0,
                        }.Build(),
                    }
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BoosterShotReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Draw +1 card next turn.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectDrawAdditionalNextTurn),
                                //TargetMode = TargetMode.,
                                TargetTeamType = Team.Type.None,
                                ParamInt = 1                                
                            }
                        }

                    }
                }

            }.BuildAndRegister();
        }
    }
}
    
