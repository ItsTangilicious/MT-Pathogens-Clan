using CustomEffectsPathogens;
using HellPathogens.Clan;
using HellPathogens.PathogenSubtype;
using SpellCardPathogens;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Test_Bounce.CustomEffectsPathogens;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using Champions;



namespace Champions
{
    class SuperVirusExiledChampion
    {
        public static readonly string ID = Rats.GUID + "_ExiledChampion";
        public static readonly string CharID = Rats.GUID + "_ExiledChampionCharacter";
        public static readonly string MaskID = Rats.GUID + "_ExiledChampionMask";
        public static readonly string excludedTypes = VanillaSubtypeIDs.Champion;

        public static void BuildAndRegister()
        {
            var championCharacterBuilder = new CharacterDataBuilder
            {
                CharacterID = CharID,
                Name = "Super Virus",
                Size = 2,
                Health = 5,
                AttackDamage = 5,
                AssetPath = "AssetsAll/MonsterAssets/SuperVirusCharacter.png"
            };

            new ChampionCardDataBuilder()
            {
                Champion = championCharacterBuilder,
                ChampionIconPath = "AssetsAll/MonsterAssets/SuperVirusCharacter.png",
                StarterCardID = TestContagion.ID,
                //StarterCardData = CustomCardManager.GetCardDataByID(TestContagion.ID),
                //StarterCardID = VanillaCardIDs.Torch,
                CardID = ID,
                Name = "Super Virus",
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/MonsterAssets/SuperVirusCard.png",
                UpgradeTree = FormUpgradeTree()
            }.BuildAndRegister(1);
        }

        public static CardUpgradeTreeDataBuilder FormUpgradeTree()
        {
            return new CardUpgradeTreeDataBuilder
            {
                UpgradeTrees =
                {
                    new List<CardUpgradeDataBuilder> { HemorrhagicI(), HemorrhagicII(), HemorrhagicIII() },
                    new List<CardUpgradeDataBuilder> { FrozenInIceI.Builder(), FrozenInIceII.Builder(), FrozenInIceIII.Builder() },
                    new List<CardUpgradeDataBuilder> { SuperSpreaderI(), SuperSpreaderII(), SuperSpreaderIII() },
                }
            };
        }

        public static CardUpgradeDataBuilder HemorrhagicI()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_HemorrhagicI",
                UpgradeTitle = "Hemorrhagic I",
                BonusHP = 5,
                BonusDamage = 5,

                TriggerUpgradeBuilders =
                {
                    /*new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_HemorrhagicEnchantI",
                        Trigger = CharacterTriggerData.Trigger.AfterSpawnEnchant,
                         EffectBuilders = new List<CardEffectDataBuilder>
                         {
                              new CardEffectDataBuilder
                              {
                                EffectStateType = typeof(CardEffectEnchant),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                      new StatusEffectStackData
                                     {
                                      statusId = StatusEffectMarkedForSacrificeDummyStacks.statusId,
                                      count = 1,
                                      }
                                }
                              }
                         }

                    },*/

                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_HemorrhagicI",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Gain <b>Shard [effect0.status0.power]</b>. Then gain +1[attack], +1[health] for each <b>Shard</b>.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                     new StatusEffectStackData
                                     {
                                        statusId = VanillaStatusEffectIDs.Shard,
                                        count = 1
                                     }
                                }
                            },

                            new CardEffectDataBuilder
                            {

                                EffectStateType = typeof(CardEffectScaleOnShards),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_HemorrhagicScaleI",
                                    BonusDamage = 1,
                                    BonusHP = 1,
                                }
                            },

                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectKill),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                TargetModeStatusEffectsFilter = new[]
                                {
                                    StatusEffectMarkedForSacrificeDummyStacks.statusId
                                }

                            },*/
                              
                              
                        }
                    }
                }
            };
        }

        public static CardUpgradeDataBuilder HemorrhagicII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_HemorrhagicII",
                UpgradeTitle = "Hemorrhagic II",
                BonusHP = 10,
                BonusDamage = 10,
                StatusEffectUpgrades =
                {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Trample,
                        count = 1,
                    }
                },
                TriggerUpgradeBuilders =
                {
                    /*new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_HemorrhagicEnchantII",
                        Trigger = CharacterTriggerData.Trigger.AfterSpawnEnchant,
                         EffectBuilders = new List<CardEffectDataBuilder>
                         {
                              new CardEffectDataBuilder
                              {
                                EffectStateType = typeof(CardEffectEnchant),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                      new StatusEffectStackData
                                     {
                                      statusId = StatusEffectMarkedForSacrificeDummyStacks.statusId,
                                      count = 1,
                                      }
                                }
                              }
                         }

                    },*/

                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_HemorrhagicII",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Gain <b>Shard [effect0.status0.power]</b>. Then gain +3[attack], +3[health] for each <b>Shard</b>.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                     new StatusEffectStackData
                                     {
                                        statusId = VanillaStatusEffectIDs.Shard,
                                        count = 1
                                     }
                                }
                            },

                            new CardEffectDataBuilder
                            {

                                EffectStateType = typeof(CardEffectScaleOnShards),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_HemorrhagicScaleII",
                                    BonusDamage = 3,
                                    BonusHP = 3,
                                }
                            },

                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectKill),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                TargetModeStatusEffectsFilter = new[]
                                {
                                    StatusEffectMarkedForSacrificeDummyStacks.statusId
                                }

                            },*/
                            
                        }
                    }
                }
            };
        }

        public static CardUpgradeDataBuilder HemorrhagicIII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_HemorrhagicIII",
                UpgradeTitle = "Hemorrhagic III",
                BonusHP = 20,
                BonusDamage = 20,

                StatusEffectUpgrades =
                {

                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Trample,
                        count = 1,
                    }
                },

                TriggerUpgradeBuilders =
                {
                    /*new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_HemorrhagicEnchantIII",
                        Trigger = CharacterTriggerData.Trigger.AfterSpawnEnchant,
                         EffectBuilders = new List<CardEffectDataBuilder>
                         {
                              new CardEffectDataBuilder
                              {
                                EffectStateType = typeof(CardEffectEnchant),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                      new StatusEffectStackData
                                      {
                                      statusId = StatusEffectMarkedForSacrificeDummyStacks.statusId,
                                      count = 1,
                                      }
                                }
                              },
                              
                         }

                    },*/

                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_HemorrhagicIII",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Gain <b>Shard [effect0.status0.power]</b>. Then gain +3[attack], +3[health] for each <b>Shard</b>.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                     new StatusEffectStackData
                                     {
                                        statusId = VanillaStatusEffectIDs.Shard,
                                        count = 2
                                     }
                                }
                            },

                            new CardEffectDataBuilder
                            {

                                EffectStateType = typeof(CardEffectScaleOnShards),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_HemorrhagicScaleIII",
                                    BonusDamage = 3,
                                    BonusHP = 3,
                                }
                            },

                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectKill),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                TargetModeStatusEffectsFilter = new[]
                                {
                                    StatusEffectMarkedForSacrificeDummyStacks.statusId
                                }

                            }*/
                        }
                    },
                }
            };

        }

       /* public static CardUpgradeDataBuilder FrozenInIceI()
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
                            },*/
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
                        /*}
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

        public static CardUpgradeDataBuilder FrozenInIceII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_FrozenInIceII",
                UpgradeTitle = "Frozen in Ice II",
                BonusHP = 0,
                BonusDamage = 0,
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
                                    BonusDamage = 2,
                                    BonusHP = 2,
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

        public static CardUpgradeDataBuilder FrozenInIceIII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_FrozenInIceIII",
                UpgradeTitle = "Frozen in Ice III",
                BonusHP = 0,
                BonusDamage = 0,
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
        }*/

        public static CardUpgradeDataBuilder SuperSpreaderI()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_SuperSpreaderI",
                UpgradeTitle = "Super Spreader I",
                BonusHP = 25,
                BonusDamage = 0,
                TriggerUpgradeBuilders =
                {
                     new CharacterTriggerDataBuilder
                     {
                        TriggerID = Rats.CLANID + "_SuperSpreaderI",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Gain <b><nobr>Shard [effect0.status0.power]</nobr></b>.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                     new StatusEffectStackData
                                     {
                                        statusId = VanillaStatusEffectIDs.Shard,
                                        count = 1
                                     }
                                }
                            },
                        }
                     },
                     new CharacterTriggerDataBuilder
                     {
                         TriggerID = Rats.CLANID + "_SuperSpreaderContagionI",
                         Trigger = CharacterTriggerData.Trigger.OnHit,
                         Description = "Apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b> per <b>Shard</b> to enemy units.",
                         EffectBuilders = new List<CardEffectDataBuilder>
                         {
                             new CardEffectDataBuilder
                             {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes,
                                UseStatusEffectStackMultiplier = true,
                                StatusEffectStackMultiplier = VanillaStatusEffectIDs.Shard,
                                ParamStatusEffects =
                                 {
                                     new StatusEffectStackData
                                     {
                                        statusId = StatusEffectContagion.statusID,
                                        count = 4
                                     }
                                 }
                             }
                         }


                     }

                }
            };
        }

        public static CardUpgradeDataBuilder SuperSpreaderII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_SuperSpreaderII",
                UpgradeTitle = "Super Spreader II",
                BonusHP = 55,
                BonusDamage = 0,
                TriggerUpgradeBuilders =
                {
                     new CharacterTriggerDataBuilder
                     {
                        TriggerID = Rats.CLANID + "_SuperSpreaderII",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Gain <b><nobr>Shard [effect0.status0.power]</nobr></b>.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                     new StatusEffectStackData
                                     {
                                        statusId = VanillaStatusEffectIDs.Shard,
                                        count = 1
                                     }
                                }
                            },
                        }
                     },
                     new CharacterTriggerDataBuilder
                     {
                         TriggerID = Rats.CLANID + "_SuperSpreaderContagionII",
                         Trigger = CharacterTriggerData.Trigger.OnHit,
                         Description = "Apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b> per <b>Shard</b> to enemy units.",
                         EffectBuilders = new List<CardEffectDataBuilder>
                         {
                             new CardEffectDataBuilder
                             {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes,
                                UseStatusEffectStackMultiplier = true,
                                StatusEffectStackMultiplier = VanillaStatusEffectIDs.Shard,
                                ParamStatusEffects =
                                 {
                                     new StatusEffectStackData
                                     {
                                        statusId = StatusEffectContagion.statusID,
                                        count = 8
                                     }
                                 }
                             }
                         }


                     }

                }
            };
        }

        public static CardUpgradeDataBuilder SuperSpreaderIII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_SuperSpreaderIII",
                UpgradeTitle = "Super Spreader III",
                BonusHP = 115,
                BonusDamage = 0,
                TriggerUpgradeBuilders =
                {
                     new CharacterTriggerDataBuilder
                     {
                        TriggerID = Rats.CLANID + "_SuperSpreaderIII",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Gain <b><nobr>Shard [effect0.status0.power]</nobr></b>.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Self,
                                TargetTeamType = Team.Type.Monsters,
                                ParamStatusEffects =
                                {
                                     new StatusEffectStackData
                                     {
                                        statusId = VanillaStatusEffectIDs.Shard,
                                        count = 1
                                     }
                                }
                            },
                        }
                     },
                     new CharacterTriggerDataBuilder
                     {
                         TriggerID = Rats.CLANID + "_SuperSpreaderContagionIII",
                         Trigger = CharacterTriggerData.Trigger.OnHit,
                         Description = "Apply <b>Contagion <nobr>[effect0.status0.power]</nobr></b> per <b>Shard</b> to enemy units.",
                         EffectBuilders = new List<CardEffectDataBuilder>
                         {
                             new CardEffectDataBuilder
                             {
                                EffectStateType = typeof(CardEffectAddStatusEffect),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes,
                                UseStatusEffectStackMultiplier = true,
                                StatusEffectStackMultiplier = VanillaStatusEffectIDs.Shard,
                                ParamStatusEffects =
                                 {
                                     new StatusEffectStackData
                                     {
                                        statusId = StatusEffectContagion.statusID,
                                        count = 12
                                     }
                                 }
                             }
                         }


                     }

                }
            };
        }
    }
};
