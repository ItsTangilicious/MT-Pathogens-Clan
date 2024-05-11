using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using HellPathogens.Clan;
using CustomEffectsPathogens;
using PubNubAPI;


namespace SpellCardPathogens
{
    internal class Pandemic
    {
        public static readonly string ID = Rats.CLANID + "Pandemic";

        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = ID,
                Name = "Pandemic",
                Description = "Apply <b>Contagion</b> <b><nobr>[effect0.status0.power]</nobr></b> to enemy units and then deal damage to enemy units equal to the amount of <b>Contagion</b> on all units.",
                Cost = 3,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/PandemicSpell.png",
                CardPoolIDs = { VanillaCardPoolIDs.MegaPool },
                TraitBuilders =
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitScalingAddDamage),
                        ParamTrackedValue = CardStatistics.TrackedValueType.StatusEffectCountInTargetRoom,
                        ParamInt = 1,
                        ParamUseScalingParams = true,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                            statusId = StatusEffectContagion.statusID,
                            count = 0
                            }
                        }
                    },
                },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Heroes,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = StatusEffectContagion.statusID,
                                count =  20,
                            }
                        }
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectDamage),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Heroes,
                    }
                }

            }.BuildAndRegister();
        }
    }
}
