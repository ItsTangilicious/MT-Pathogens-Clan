using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;

namespace Champions
{
    internal class FrozenInIceIII
    {
        public static CardUpgradeDataBuilder Builder()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_FrozenInIceIII",
                UpgradeTitle = "Frozen in Ice III",
                BonusHP = 0,
                BonusDamage = 0,
                UpgradesToRemove = new List<CardUpgradeData> { FrozenInIceII.Make() },
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
                        TriggerID = Rats.CLANID + "_FrozenInIceReserveIII",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Give friendly units +6[attack], +6[health] on the floor where your turn ended.",
                        CardEffectBuilders = new List<CardEffectDataBuilder>

                        {
                            new CardEffectDataBuilder
                            {
                               EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                               TargetMode = TargetMode.Room,
                               TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_FrozenInIceScaleIII",
                                    BonusDamage = 6,
                                    BonusHP = 6,
                                }
                            },
                             }
                    },
                    new CardTriggerEffectDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_FrozenInIceReserveSelfIII",
                        Trigger = CardTriggerType.OnUnplayed,
                        Description = "Gain +6[attack], +6[health] permanently.",
                        CardTriggerEffects = new List<CardTriggerData>
                        {
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffCharacterDamage",
                                "None",
                                6
                            ),
                            new CardTriggerEffectDataBuilder{}.AddCardTrigger
                            (
                                PersistenceMode.SingleRun,
                                "CardTriggerEffectBuffCharacterMaxHP",
                                "None",
                                6
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
  