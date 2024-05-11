using HarmonyLib;
using I2.Loc;
using System.Collections.Generic;
using HarmonyLib;
using Trainworks.Managers;

//from RisingDusk Unofficial Balance Patch (is this the best way to do so?)
[HarmonyPatch(typeof(LocalizationManager), "GetTranslation")]
internal class ShardStatusEffect_UpdateCardText
{
    private static void Postfix(ref string __result, string Term)
    {
        if (__result.Contains("Powers <b>Solgard the Martyr</b>'s abilities."))
        {
            __result = "Powers the unit's abilities.";
        }
    }
} 
