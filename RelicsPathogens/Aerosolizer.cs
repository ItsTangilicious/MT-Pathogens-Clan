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
    class AerosolizerRelic
    {
        
        public static readonly string ID = Rats.GUID + "_AerosolizerRelic";
        
        public static void BuildandRegister()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = Rats.GUID + "_AerosolizerRelic",
                //Name = "Aerosolizer",
                NameKey = "RelicsPathogens_com.Tang.Rats.generic_AerosolizerRelic_Name_Key",
                //Description = "When an unit with Contagion dies, it deals damage equal to one half its Contagion stacks to the front enemy unit.",
                DescriptionKey = "RelicsPathogens_com.Tang.Rats.generic_AerosolizerRelic_Description_Key",
                RelicActivatedKey = "RelicsPathogens_com.Tang.Rats.generic_AerosolizerRelic_Activated_Key",
                RelicPoolIDs = { VanillaRelicPoolIDs.MegaRelicPool },
                IconPath = "AssetsAll/ArtifactAssets/AerosolizerArtifact.png",
                ClanID = Clan.ID,
                EffectBuilders =
                {
                    new RelicEffectDataBuilder
                    {
                        RelicEffectClassType = typeof(RelicEffectContagionScalingDamage),
                        ParamSourceTeam = Team.Type.Heroes,

                        ParamInt = 1,
                        //ParamFloat = 0.5f,
                        ParamTargetMode = TargetMode.FrontInRoom,
                        ParamCharacterSubtype = "SubtypesData_None",
                        ParamTrigger = CharacterTriggerData.Trigger.OnDeath,
                        AppliedVfx = CustomCardManager.GetCardDataByID(VanillaCardIDs.BrambleLash).GetEffects()[0].GetAppliedVFX(),
                        ParamStatusEffects =
                        {
                            new StatusEffectStackData
                            {
                                statusId = StatusEffectContagion.statusID,
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
