using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;

namespace Champions
{
    internal class FrozenInIceII
    {
        public static CardUpgradeDataBuilder Builder()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_FrozenInIceII",
                UpgradeTitle = "Frozen in Ice II",
                BonusHP = 0,
                BonusDamage = 0,
                BonusSize = -1,
                UpgradesToRemove = new List<CardUpgradeData> { FrozenInIceI.Make() },
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
                        TriggerID = Rats.CLANID + "_FrozenInIceReserveII",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Give friendly units +4[attack], +4[health] on the floor where your turn ended.",
                        CardEffectBuilders = new List<CardEffectDataBuilder>

                        {
                            new CardEffectDataBuilder
                            {
                               EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                               TargetMode = TargetMode.Room,
                               TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_FrozenInIceScaleII",
                                    BonusDamage = 4,
                                    BonusHP = 4,
                                }
                            },
                        }
                    },
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_FrozenInIceReserveSelfII",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Gain +4[attack], +4[health] permanently.",
                        CardTriggerEffects = new List<CardTriggerData>
                        {
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffCharacterDamage",
                                "None",
                                4
                            ),
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffCharacterMaxHP",
                                "None",
                                4
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
