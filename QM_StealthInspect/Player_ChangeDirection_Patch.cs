using System;
using HarmonyLib;
using MGSC;
using UnityEngine;

namespace QM_StealthInspect
{
    [HarmonyPatch(typeof(Player), nameof(Player.ChangeDirection))]
    public static class PlayerChangeDirectionPatch
    {
        public static void Prefix(Player __instance, ref bool markActionFlag)
        {
            // If we don't want to trigger AP penalties, force markActionFlag to false
            if (__instance.FreeInventoryUse)
            {
                //Debug.Log("[QM_StealthInspect] Preventing AP penalty by forcing markActionFlag to false.");
                markActionFlag = false;  // This prevents the game from setting AnyActionProcessedFlag to true
            }
        }
    }
}



