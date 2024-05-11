using HellPathogens.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Test_Bounce;
using CustomEffectsPathogens;
using Test_Bounce.CustomEffectsPathogens;

namespace RelicsPathogens
{
    internal class IceCore
    {
        public static readonly string ID = Rats.GUID + "_IceCore";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = ID,
                Name = "Ice Core",
                Description = "Gain +1 <b>Shard</b> each time it is applied to a friendly unit.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/IceCoreArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
                {
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectAddStatusEffectOnStatusApplied),
                        ParamInt = 100,
                        ParamBool = true,
                        ParamSourceTeam = Team.Type.Monsters,
                        ParamStatusEffects = 
                        {
                           new StatusEffectStackData()
                           {
                            statusId = VanillaStatusEffectIDs.Shard,
                            count = 1
                           }
                        }

                    }
                },
                Rarity = CollectableRarity.Common
            }.BuildAndRegister();

        }
    }
}
