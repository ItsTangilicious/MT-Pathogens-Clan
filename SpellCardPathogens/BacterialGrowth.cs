using Trainworks.BuildersV2;
using Trainworks.Constants;
using Test_Bounce;
using HellPathogens.Clan;
using CustomEffectsPathogens;
using System.Collections.Generic;

namespace SpellCardPathogens
{
    internal class BacterialGrowth
    {
        public static readonly string ID = Rats.CLANID + "_BacterialGrowth";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Bacterial Growth",
                Description = "Deal <nobr>[effect0.power]</nobr> damage.",
                Cost = 1,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = false,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/BacterialGrowthSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                     new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectDamage),
                         TargetMode = TargetMode.DropTargetCharacter,
                         TargetTeamType = Team.Type.Heroes | Team.Type.Monsters,
                         ParamInt = 5
                     },
                },
                TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BacterialGrowthReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Increase damage by 2 permanently.",
                        CardTriggerEffects = new List<CardTriggerData>
                        {
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffSpellDamage",
                                "None",
                                2
                            ),
                          
                        }
                        /*CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardTriggerEffectBuffSpellDamage),
                                //ParamInt = 2
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = "BacterialGrowthUpgrade",
                                    BonusDamage = 2,
                                   
                                }.Build(),
                            }
                        }*/

                    }
                }

            }.BuildAndRegister();
        }
    }
}
