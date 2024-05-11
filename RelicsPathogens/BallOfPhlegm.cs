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
    internal class BallOfPhlegm
    {
        public static readonly string ID = Rats.GUID + "_BallOfPhlegm";

        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = ID,
                Name = "Ball Of Phlegm",
                Description = "Grant +4 stacks of <b>Contagion</b> each time it is applied.",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/BallOfPhlegmArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
                {
                    
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectAddStatusEffectOnStatusApplied),
                        ParamInt = 100,
                        ParamBool = true,
                        //ParamSourceTeam = Team.Type.Monsters,
                        ParamStatusEffects =
                        {
                           new StatusEffectStackData()
                           {
                            statusId = StatusEffectContagion.statusID,
                            count = 4
                           }
                        }

                    }
                    //currently not working Apr 10th 2024
                    /*
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectContagionStacksScaling),
                        ParamSourceTeam = Team.Type.Heroes,
                        ParamFloat = 1,
                        ParamTargetMode = TargetMode.Room,
                        ParamCharacterSubtype = "SubtypesData_None",
                        ParamTrigger = CharacterTriggerData.Trigger.OnRemoveHatch,
                        AppliedVfx = CustomCardManager.GetCardDataByID(VanillaCardIDs.BrambleLash).GetEffects()[0].GetAppliedVFX(),
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = StatusEffectContagion.statusID,
                                count = 1
                            }
                        }

                    }*/
                },
                Rarity = CollectableRarity.Common
            }.BuildAndRegister();

        }
    }
}
