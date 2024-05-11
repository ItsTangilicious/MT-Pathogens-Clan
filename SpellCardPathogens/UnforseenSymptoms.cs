using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using HellPathogens.Clan;
using HellPathogens.CardPools;


namespace SpellCardPathogens
{
    internal class UnforseenSymptoms
    {
        public static readonly string ID = Rats.CLANID + "_UnforseenSymptoms";

        public static void BuildandRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Unforseen Symptoms",
                Description = "Apply [dazed] [effect1.status0.power] to a random enemy unit and +10[health] to a random friendly unit.",
                Cost = 2,
                Rarity = CollectableRarity.Uncommon,
                TargetsRoom = false,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "assets/nothornbreak.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                        TargetMode = TargetMode.RandomInRoom,
                        TargetTeamType = Team.Type.Monsters,
                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "UnforseenSymptomsMonsterUpgrade",
                            BonusDamage = 0,
                            BonusHP = 10,
                            

                        }.Build(),
                        
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddTempCardUpgradeToUnits),
                        TargetMode = TargetMode.RandomInRoom,
                        TargetTeamType = Team.Type.Heroes,
                        ParamCardUpgradeData = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "UnforseenSymptomsHeroUpgrade",
                            StatusEffectUpgrades = new List<StatusEffectStackData>
                            {
                                new StatusEffectStackData
                                {
                                    statusId = VanillaStatusEffectIDs.Dazed,
                                    count = 2
                                }
                            },
                            

                        }.Build(),

                    },
                },
            }.BuildAndRegister();
        }

    }
}
