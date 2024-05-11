using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using HellPathogens.Clan;
using HellPathogens.CardPools;
using CustomEffectsPathogens;


namespace SpellCardPathogens
{
    internal class Spelleogenisis
    {
        public static readonly string ID = Rats.CLANID + "_Spelleogenisis";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Spelleogenisis",
                Description = "Apply <b>Attuned</b> to all non-healing damage spells in your hand. Apply +10 <b>Magic Power</b> to all healing spells in your hand.",
                Cost = 5,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = false,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/SpelleogenesisSpell.png",
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
                        EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHandAttuned),
                        TargetMode = TargetMode.Hand,
                        TargetTeamType = Team.Type.None,
                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "SpelleogenisisUpgradeAttuned",
                            TraitDataUpgradeBuilders =
                            {
                                new CardTraitDataBuilder
                                {
                                    TraitStateType = typeof(CardTraitStrongerMagicPower)
                                }
                            },

                            Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = "SpelleogenisisFilter1",
                                            CardType = CardType.Spell,
                                            RequiredCardEffectsOperator = CardUpgradeMaskDataBuilder.CompareOperator.Or,
                                            RequiredCardEffects =
                                            {
                                                "CardEffectDamage",
                                            },
                                            ExcludedCardEffects =
                                            {
                                                "CardEffectHeal", "CardEffectHealAndDamageRelative"
                                            },
                                            DisallowedCardPools =
                                            {
                                                MyCardPools.MagicPowerExcludePool
                                            },
                                            ExcludedCardTraits =
                                            {
                                                "CardTraitStrongerMagicPower"
                                            }
                                        }.Build()
                            }

                        }.Build(),
                    },
                    new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHand),
                                TargetMode = TargetMode.Hand,
                                TargetTeamType = Team.Type.None,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = "SpelleogenisisUpgradeSpellDamage",
                                    BonusDamage = 10,
                                    BonusHeal = 10,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = "SpelleogenisisFilter2",
                                            CardType = CardType.Spell,
                                            RequiredCardEffectsOperator = CardUpgradeMaskDataBuilder.CompareOperator.Or,
                                            RequiredCardEffects =
                                            {
                                                "CardEffectHeal", "CardEffectHealAndDamageRelative"
                                            },
                                            DisallowedCardPools =
                                            {
                                                MyCardPools.MagicPowerExcludePool
                                            }
                                        }.Build()
                                    }
                                }.Build(),
                    }
                },
                /*TriggerBuilders =
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_SpelleogenisisReserve",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Apply +3 <b>Magic Power</b> to spells in hand.",
                        CardEffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHand),
                                TargetMode = TargetMode.Hand,
                                TargetTeamType = Team.Type.None,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = "SpelleogenisisUpgradeSpellDamage",
                                    BonusDamage = 3,
                                    BonusHeal = 3,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = "SpelleogenisisFilter2",
                                            CardType = CardType.Spell,
                                            RequiredCardEffectsOperator = CardUpgradeMaskDataBuilder.CompareOperator.Or,
                                            RequiredCardEffects =
                                            {
                                                "CardEffectDamage", "CardEffectHeal", "CardEffectHealAndDamageRelative"
                                            },
                                            DisallowedCardPools =
                                            {
                                                MyCardPools.MagicPowerExcludePool
                                            }
                                        }.Build()
                            }
                                }.Build(),
                            }
                        }
                    }
                }*/
            }.BuildAndRegister();
        }
    }
}
