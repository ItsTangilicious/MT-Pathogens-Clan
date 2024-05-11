using CustomEffectsPathogens;
using HellPathogens.Clan;
using Test_Bounce;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;

namespace RelicsPathogens 
{
    class MitoticDivisionRelic
    {
        public static readonly string ID = Rats.GUID + "_MitoticDivisionRelic";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_MitoticDivisionRelic",
                Name = "Mitotic Division",
                Description = "<b>Rally</b> and <b>Culture</b> abilities trigger an additional time.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/MitoticDivisionArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
                {
                    new RelicEffectDataBuilder
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

                    }
                },
                Rarity = CollectableRarity.Common
            }.BuildAndRegister();
        }
    }
}
