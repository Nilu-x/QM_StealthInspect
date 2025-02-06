using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using HarmonyLib;
using System.Reflection;

namespace QM_StealthInspect
{
    public static class Plugin
    {
        public static string ModAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            new Harmony("Nilux_" + ModAssemblyName).PatchAll();
        }
    }
}
