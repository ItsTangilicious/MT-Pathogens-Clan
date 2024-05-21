using CustomEffectsPathogens;
using HellPathogens.Clan;
using System.Collections.Generic;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using SpellCardPathogens;



namespace Champions
{
    class CarrierChampion
    {
        public static readonly string ID = Rats.GUID + "_Champion";
        public static readonly string CharID = Rats.GUID + "_ChampionCharacter";
        public static readonly string MaskID = Rats.GUID + "_ChampionMask";

        public static void BuildAndRegister()
        {
            var championCharacterBuilder = new CharacterDataBuilder
            {
                CharacterID = CharID,
                Name = "Carrier",
                Size = 2,
                Health = 10,
                AttackDamage = 5,
                AssetPath = "AssetsAll/MonsterAssets/CarrierChampionCharacter.png"
            };

            new ChampionCardDataBuilder()
            {
                Champion = championCharacterBuilder,
                ChampionIconPath = "AssetsAll/MonsterAssets/CarrierChampionIcon.png",
                //StarterCardID = VanillaCardIDs.Torch,
                StarterCardID = Virion.ID,
                CardID = ID,
                Name = "Carrier",
                ClanID = Clan.ID,
                UpgradeTree = FormUpgradeTree(),
                AssetPath = "AssetsAll/MonsterAssets/CarrierChampionCard.png"
            }.BuildAndRegister(0);
        }

        public static CardUpgradeTreeDataBuilder FormUpgradeTree()
        {
            return new CardUpgradeTreeDataBuilder
            {
                UpgradeTrees =
                {
                    new List<CardUpgradeDataBuilder> { ImmuneI(), ImmuneII(), ImmuneIII() },
                    new List<CardUpgradeDataBuilder> { ZeroI(), ZeroII(), ZeroIII() },
                    new List<CardUpgradeDataBuilder> { BioengineerI(), BioengineerII(), BioengineerIII() },
                }
            };
        }

        public static CardUpgradeDataBuilder ImmuneI()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_ImmuneI",
                UpgradeTitle = "Immunologist I",
                BonusHP = 0,
                BonusDamage = 0,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {

                        TriggerID = Rats.CLANID + "_ImmuneTriggerI",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Give all friendly units +2[attack], +2[health].",
                        EffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamInt = 1,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {

                                    UpgradeID = "ImmuneIUpgrade",
                                    BonusDamage = 2,
                                    BonusHP = 2,
                                }.Build(),

                            },
                        }
                    }
                }
            };
        }

        public static CardUpgradeDataBuilder ImmuneII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_ImmuneII",
                UpgradeTitle = "Immunologist II",
                BonusHP = 5,
                BonusDamage = 5,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {

                        TriggerID = Rats.CLANID + "_ImmuneTriggerII",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Give all friendly units +4[attack], +4[health].",
                        EffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamInt = 1,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = "ImmuneIIUpgrade",
                                    BonusDamage = 4,
                                    BonusHP = 4,
                                }.Build(),

                            },

                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectBuffMaxHealth),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamInt = 5
                            }*/
                        }
                    }
                }
            };
        }

        public static CardUpgradeDataBuilder ImmuneIII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_ImmuneIII",
                UpgradeTitle = "Immunologist III",
                BonusHP = 10,
                BonusDamage = 10,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {

                        TriggerID = Rats.CLANID + "_ImmuneTriggerIII",
                        Trigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        Description = "Give all friendly units +8[attack], +8[health].",
                        EffectBuilders =
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                                ParamInt = 1,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = "ImmuneIIIUpgrade",
                                    BonusDamage = 8,
                                    BonusHP = 8,
                                }.Build(),

                            },
                        }
                    }
                }
            };
        }

        public static CardUpgradeDataBuilder ZeroI()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_ZeroI",
                UpgradeTitle = "Patient Zero I",
                BonusHP = 15,
                BonusDamage = 10,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_ZeroTriggerI",
                        Description = "Summon 1 Recombinant Virus.",
                        Trigger = CharacterTriggerData.Trigger.OnHit,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            /*new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },*/
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectRecruitsShedding),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            }
                        }
                    }
                }

            };

        }

        public static CardUpgradeDataBuilder ZeroII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_ZeroII",
                UpgradeTitle = "Patient Zero II",
                BonusHP = 30,
                BonusDamage = 20,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_ZeroTriggerII",
                        Description = "Summon 2 Recombinant Virus.",
                        Trigger = CharacterTriggerData.Trigger.OnHit,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
/*new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },*/
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectRecruitsShedding),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectRecruitsShedding),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            }
                        }
                    },

                }

            };

        }

        public static CardUpgradeDataBuilder ZeroIII()

        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_ZeroIII",
                UpgradeTitle = "Patient Zero III",
                BonusHP = 70,
                BonusDamage = 40,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_ZeroTriggerIII",
                        Description = "Summon 3 Recombinant Virus.",
                        Trigger = CharacterTriggerData.Trigger.OnHit,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                           /*new CardEffectDataBuilder
                     {
                         EffectStateType = typeof(CardEffectLoadRecombinantArt)
                     },*/
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectRecruitsShedding),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            },
                             new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectRecruitsShedding),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            },
                              new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectRecruitsShedding),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            }
                        }
                    },

                }

            };

        }

        public static CardUpgradeDataBuilder BioengineerI()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_BioengineerI",
                UpgradeTitle = "Bioengineer I",
                BonusHP = 0,
                BonusDamage = 5,
                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BioengineerTriggerI",
                        Description = "Draw a unit and apply +10[attack], +5[health] to all units in hand.",
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectDrawType),
                                TargetMode = TargetMode.DrawPile,
                                TargetTeamType = Team.Type.None,
                                TargetCardType = CardType.Monster,
                                ParamInt = 1,
                            },

                            //This doesn't work since CardEffectAddTempCardUpgradeToCardsInHand references a parent card but was triggered by a character. Or so I was told by people that can actually code.
                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHand),
                                TargetTeamType = Team.Type.None,
                                TargetMode = TargetMode.Hand,
                                TargetCardType = CardType.Monster,
                                ShouldTest = false,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_BioengineerTriggerHandI",
                                    BonusDamage = 5,
                                    BonusHP = 5,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = MaskID,
                                            CardType = CardType.Monster
                                        }.Build(),

                                    }

                                }.Build(),
                            }*/

                        }


                    },

                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BioengineerTriggerHandII",
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        //Description = "Apply +5[attack], +5[health] to all units in hand.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHandFromCharacter),
                                TargetTeamType = Team.Type.None,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_BionengineerUpgradeHandI",
                                    BonusDamage = 10,
                                    BonusHP = 5,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = MaskID,
                                            CardType = CardType.Monster
                                        }.Build()
                                    }
                                }.Build(),
                            }
                        }
                    },
                },
            };
        }

        public static CardUpgradeDataBuilder BioengineerII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_BioengineerII",
                UpgradeTitle = "Bioengineer II",
                BonusHP = 5,
                BonusDamage = 10,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BioengineerTriggerII",
                        Description = "Draw a unit and apply +20[attack], +10[health] to all units in hand.",
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectDrawType),
                                TargetMode = TargetMode.DrawPile,
                                TargetTeamType = Team.Type.None,
                                TargetCardType = CardType.Monster,
                                ParamInt = 1,
                            },

                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHand),
                                TargetTeamType = Team.Type.None,
                                ShouldTest = false,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    BonusDamage = 15,
                                    BonusHP = 15,
                                    BonusSize = -1,
                                    /*Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardType = CardType.Monster
                                        }.Build(),

                                    }

                                }.Build(),
                            }*/
                        }




                    },

                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BioengineerTriggerHandII",
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHandFromCharacter),
                                TargetTeamType = Team.Type.None,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_BionengineerUpgradeHandII",
                                    BonusDamage = 20,
                                    BonusHP = 10,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = MaskID,
                                            CardType = CardType.Monster
                                        }.Build()
                                    }
                                }.Build(),
                            }
                        }
                    },
                },
            };
        }

        public static CardUpgradeDataBuilder BioengineerIII()
        {
            return new CardUpgradeDataBuilder
            {
                UpgradeID = Rats.CLANID + "_BioengineerIII",
                UpgradeTitle = "Bioengineer III",
                BonusHP = 10,
                BonusDamage = 15,
                TriggerUpgradeBuilders =
                {
                    new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BioengineerTriggerIII",
                        Description = "Draw two units and apply +40[attack], +20[health], and -1[size] to all units in hand.",
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectDrawType),
                                TargetMode = TargetMode.DrawPile,
                                TargetTeamType = Team.Type.None,
                                TargetCardType = CardType.Monster,
                                ParamInt = 2,
                            },

                            /*new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHand),
                                TargetTeamType = Team.Type.None,
                                ShouldTest = false,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    BonusDamage = 25,
                                    BonusHP = 25,
                                    BonusSize = -1,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardType = CardType.Monster
                                        }.Build(),

                                    }

                                }.Build(),
                            }*/
                        }




                    },

                     new CharacterTriggerDataBuilder
                    {
                        TriggerID = Rats.CLANID + "_BioengineerTriggerHandIII",
                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectAddTempCardUpgradeToCardsInHandFromCharacter),
                                TargetTeamType = Team.Type.None,
                                ParamCardUpgradeData = new CardUpgradeDataBuilder
                                {
                                    UpgradeID = Rats.CLANID + "_BionengineerUpgradeHandI",
                                    BonusDamage = 40,
                                    BonusHP = 20,
                                    BonusSize = -1,
                                    Filters = new List<CardUpgradeMaskData>
                                    {
                                        new CardUpgradeMaskDataBuilder
                                        {
                                            CardUpgradeMaskID = MaskID,
                                            CardType = CardType.Monster
                                        }.Build()
                                    }
                                }.Build(),
                            }
                        }
                    },
                }
            };
        }
    }
};



