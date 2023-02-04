using HarmonyLib;
using HurricaneCore.Hook.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
namespace HurricaneCore.Patch
{
    internal class SpoofAssembly
    {
        [HarmonyPatch(typeof(Assembly), "GetEntryAssembly")]
        class GetEntryAssemblyPatch
        {
            static bool Prefix(ref Assembly __result)
            {
                if(MainClass.DLLInjection == true)
                {
                    return true;
                }
                try
                {
                    PatchLog("Triggered Assembly.GetEntryAssembly");
                    if(Config.ConfigManager.SpoofAssembly == true)
                    {
                        __result = Utils.LoadedAssembly;
                        Log("Assembly spoofed.", "INFO", ConsoleColor.Yellow);
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
        [HarmonyPatch(typeof(Assembly), "GetCallingAssembly")]
        class GetCallingAssemblyHook
        {
            static bool Prefix(ref Assembly __result)
            {
                if (MainClass.DLLInjection == true)
                {
                    return true;
                }
                try
                {
                    PatchLog("Triggered Assembly.GetCallingAssembly");
                    if (Config.ConfigManager.SpoofAssembly == true)
                    {
                        __result = Utils.LoadedAssembly;
                        Log("Assembly spoofed.", "INFO", ConsoleColor.Yellow);
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
