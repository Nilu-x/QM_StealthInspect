using System;
using System.Collections.Generic;
using System.Linq;
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

        The devs use player.anyactionprocessedflag for cases where they want this behavior, so far it was observed in 2 places.
            1) when a sneaking player turns their camera
            2) when a sneaking player changes to a weapon that has a different field of view than their current

        It's clearly intentional that they want this, so keep in mind it may have balance implications. Maybe your unfair run will be slightly less so.
        I like to be able to recon without the tedium of standing up before inspecting every enemy in a room, but of course it's personal preference.
        */

        static void Postfix(ref bool __anyactionprocessedflag)
        {
            if (__anyactionprocessedflag)
                __anyactionprocessedflag = false;
        }


    }
}
