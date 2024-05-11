using CustomEffectsPathogens;
using HarmonyLib;
using HellPathogens.Clan;
using System.Collections.Generic;
using Test_Bounce;
using Test_Bounce.CustomEffectsPathogens;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;

namespace RelicsPathogens
{
    internal class FibroticLungs
    {
        public static readonly string ID = Rats.GUID + "_FibroticLungs";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_FibroticLungs",
                Name = "Fibrotic Lungs",
                Description = "Enemies enter with Sap 3.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/FibroticLungsArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
                {
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectAddStatusEffectOnSpawn),
                        ParamSourceTeam = Team.Type.Heroes,
                        ParamStatusEffects = 
                        {
                            new StatusEffectStackData
                            {
                                statusId = VanillaStatusEffectIDs.Sap,
                                count = 3
                            }
                        }


                    },
                
                },
                Rarity = CollectableRarity.Common,

            }.BuildAndRegister();

        }
    }
}
