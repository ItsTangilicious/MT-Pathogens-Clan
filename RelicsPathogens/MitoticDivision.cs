using CustomEffectsPathogens;
using HellPathogens.CardPools;
using HellPathogens.Clan;
using SpellCardPathogens;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using System.Collections.Generic;

namespace RelicsPathogens 
{
    class MitoticDivisionRelic
    {
        public static readonly string ID = Rats.GUID + "_MitoticDivisionRelic";

        public static void BuildandRegister()
        {
            var virionPool = new CardPoolBuilder
            {
                CardPoolID = Rats.GUID + "_MitoticPool",
                CardIDs =
                {
                   Virion.ID
                    
                }
            }.BuildAndRegister();

            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_MitoticDivisionRelic",
                Name = "Mitotic Division",
                //Description = "<b>Rally</b> and <b>Culture</b> abilities trigger an additional time.",
                Description = "When you summon your first unit each turn, add a <b>Virion</b> spell with <b>Purge</b> to your hand.",
                RelicActivatedKey = "RelicsPathogens_com.Tang.Rats.generic_MitoticDivisionRelic_Activated_Key",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/MitoticDivisionArtifact.png",
                ClanID = Clan.ID,

                EffectBuilders =
                {
                    /*new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectModifyTriggerCount),
                        ParamInt = 1,
                        ParamSourceTeam = Team.Type.Monsters,
                        ParamTrigger = CharacterTriggerData.Trigger.CardMonsterPlayed

                    },
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectModifyTriggerCount),
                        ParamInt = 1,
                        ParamSourceTeam = Team.Type.Monsters,
                        ParamTrigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum()

                    }*/
                    new RelicEffectDataBuilder
                    {
                        EffectConditionBuilders =
                        {
                            new RelicEffectConditionBuilder
                            {
                                ParamTrackedValue = CardStatistics.TrackedValueType.AnyMonsterSpawned,
                                ParamCardType = CardStatistics.CardTypeTarget.Monster,
                                ParamEntryDuration = CardStatistics.EntryDuration.ThisTurn,
                                AllowMultipleTriggersPerDuration = false,
                                ParamInt = 1,
                                                               
                            }
                        },                       
                        ParamCardPool = virionPool,
                        RelicEffectClassType = typeof(RelicEffectAddBattleCardToHandOnUnitTrigger),
                        ParamSourceTeam = Team.Type.Monsters,
                        ParamInt = 1,
                        ParamTrigger = CharacterTriggerData.Trigger.OnSpawn,
                        //ParamTrigger = CustomTriggerBetterRally.OnCustomTriggerBetterRallyCharTrigger.GetEnum(),
                        ParamTargetMode = TargetMode.FrontInRoom,
                        ParamCardType = CardType.Spell,
                        ParamCardUpgradeDataBuilder = new CardUpgradeDataBuilder
                        {
                            UpgradeID = "_MitoticUpgrade",
                            TraitDataUpgrades = new List<CardTraitData>
                            {
                                new CardTraitData
                                {
                                    traitStateName = "CardTraitSelfPurge"
                                }
                            }
                        }


                    }
                },
                
            Rarity = CollectableRarity.Common

            }.BuildAndRegister();
            CustomCardPoolManager.MarkCardPoolForPreloading(virionPool, clan_assets: true, game_assets: false);
        }
    }
}
