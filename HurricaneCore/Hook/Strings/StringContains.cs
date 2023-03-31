using HarmonyLib;
using System;
using static HurricaneCore.Logger;
using static HurricaneCore.Hook.Config.Config;
namespace HurricaneCore.Hook.Strings
{
    internal class StringContains
    {
        [HarmonyPatch(typeof(string), nameof(string.Contains))]
        class PatchStringContains
        {
            [STAThread]
            static bool Prefix(string value, ref bool __result)
            {
                try
                {
                    Log("Triggered String.Contains with string: " + value, "STRING", ConsoleColor.Yellow);
                    if (ConfigManager.XReactorBypass == true && value == "Welcome" && __result == false)
                    {
                        __result = true;
                        Log("XReactor Auth Bypassed.", "BYPASS", ConsoleColor.Green);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return true;
            }
        }
    }
}
