﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;
using UnityEngine;

namespace QM_StealthInspect
{
    [HarmonyPatch(typeof(Player), nameof(Player.ChangeDirection))]
    public static class PlayerChangeDirectionPatch
    {
        /*
        The behavior which causes the player to have to stand up after inspecting a creature while sneaking is actually tied to changing view direction.
        Inspecting happens with right click, which also turns the player.

        The devs use player.anyactionprocessedflag for cases where they want this behavior. For example:
            1) when a sneaking player changes their facing direction
            2) when a sneaking player changes to another weapon

        It's clearly intentional that they want this, so keep in mind it may have balance implications. Maybe your unfair run will be slightly less so.
        I like to be able to recon without the tedium of standing up before inspecting every enemy in a room, but of course it's personal preference.

        This mod should only change what happens when the player is sneaking and changes direction/inspects a creature.        
        */

        public static void Postfix(Player __instance) => __instance.AnyActionProcessedFlag = false;

    }
}
