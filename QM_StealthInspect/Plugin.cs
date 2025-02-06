using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace QM_StealthInspect
{
    public static class Plugin
    {
        // Thank you to NBK_Redspy for great examples on how to do this!
        public static string ModAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            new Harmony("Nilux_" + ModAssemblyName).PatchAll();
        }
    }
}
