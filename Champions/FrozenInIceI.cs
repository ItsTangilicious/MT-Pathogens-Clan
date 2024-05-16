using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;

namespace Champions
{
    internal class FrozenInIceI
    {
        public static CardUpgradeDataBuilder Builder()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_FrozenInIceI",
                UpgradeTitle = "Frozen in Ice I",
                BonusHP = 0,
                BonusDamage = 0,
                BonusSize = -1,
                TraitDataUpgradeBuilders =
                {
                  new CardTraitDataBuilder
                    {
                      TraitStateType = typeof(CardTraitPermafrost)
                    },

                },
                CardTriggerUpgradeBuilders = new List<CardTriggerEffectDataBuilder>
                {
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_FrozenInIceReserveI",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Give friendly units +2[attack], +2[health] on the floor where your turn ended.",
                        CardEffectBuilders = new List<CardEffectDataBuilder>

                        {
                            new CardEffectDataBuilder
                            {
                               EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                               TargetMode = TargetMode.Room,
                               TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_FrozenInIceScaleI",
                                    BonusDamage = 2,
                                    BonusHP = 2,
                                }
                            },
                            /* new CardEffectDataBuilder
                            {
                               EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHand),
                               TargetMode = TargetMode.Self,
                               TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_FrozenInIceScaleSelfI",
                                    BonusDamage = 6,
                                    BonusHP = 6,

                                }
                             } */
                        }
                    },
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_FrozenInIceReserveSelfI",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Gain +2[attack], +2[health] permanently.",
                        CardTriggerEffects = new List<CardTriggerData>
                        {
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffCharacterDamage",
                                "None",
                                2
                            ),
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffCharacterMaxHP",
                                "None",
                                2
                            )
                        }
                    }
                },

            };
        }
        public static CardUpgradeData Make()
        {
            return Builder().Build();
        }
    }    
}
