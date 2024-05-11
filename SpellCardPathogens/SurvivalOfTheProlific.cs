using CustomEffectsPathogens;
using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Trainworks.Managers;

namespace SpellCardPathogens
{
    internal class SurvivalOfTheProlific
    {
        public static readonly string ID = Rats.CLANID + "_SurvivalOfTheProlific";


        public static void BuildAndRegister()
        {
            new CardDataBuilder
            {
                CardID = "_SurvivalOfTheProlific",
                Name = "Survival of the Prolific",
                Description = "Apply <b>Replicate</b> to the front friendly unit. Then trigger each unit's Culture trigger on this floor.",
                Cost = 2,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = true,
                ClanID = Clan.ID,
                AssetPath = "AssetsAll/SpellAssets/ProlificSpell.png",
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
                        EffectStateType = typeof(CardEffectAddStatusEffect),
                        TargetMode = TargetMode.FrontInRoom,
                        TargetTeamType = Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = StatusEffectReplicate.statusID,
                                count =  1
                            }
                        }
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectPlayUnitTrigger),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamTrigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum()
                    }

                },
            }.BuildAndRegister();
        }
    }
}
