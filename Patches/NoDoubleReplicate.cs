using CustomEffectsPathogens;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;

namespace Patches
{
    internal class NoDoubleReplicate
    {
        //from Beyonder DoNotDoubleStackMutations thanks ThreeFishies!

        public static bool done;
        public static void JustDont()
        {
            if (!done)
            {
                EnhancerData JuiceStone = ProviderManager.SaveManager.GetAllGameData().FindEnhancerData("72f61ae8-7e0f-4066-a3fb-a1273f3aa273");
                if (JuiceStone != null)
                {
                    CardUpgradeMaskData ExcludeNonstackableStatusEffectsfilter = JuiceStone.GetEffects()[0].GetParamCardUpgradeData().GetFilters()[3];
                    List<StatusEffectStackData> excludedStatusEffects = AccessTools.Field(typeof(CardUpgradeMaskData), "excludedStatusEffects").GetValue(ExcludeNonstackableStatusEffectsfilter) as List<StatusEffectStackData>;
                    excludedStatusEffects.Add(new StatusEffectStackData
                    {
                        statusId = StatusEffectReplicate.statusID,
                        count = 1
                    });
                    /*CardUpgradeMaskData OnlyStatusEffectSetting = JuiceStone.GetEffects()[0].GetParamCardUpgradeData().GetFilters()[0];
                    List<string> requiredCardEffects = AccessTools.Field(typeof(CardUpgradeMaskData), "requiredCardEffects").GetValue(OnlyStatusEffectSetting) as List<string>;
                    //requiredCardEffects.Add(typeof(CustomCardEffectAddPersistentStausEffectToUnits).Name);
                    //requiredCardEffects.Add(typeof(CustomCardEffectAddPersistentStausEffectToUnits).AssemblyQualifiedName);
                }
                else
                {
                    //Beyonder.LogError("Unable to find doublestack magic upgrade. What happened to it?");
                }*/
                    done = true;
                }
            }
        }
    }
}

