using HarmonyLib;
using HurricaneCore.Hook.SaveStrings;
using System;
using static HurricaneCore.Logger;
namespace HurricaneCore.Hook.Strings
{
    internal class GetStringsFromBytes
    {
        [HarmonyPatch(typeof(System.Text.Encoding), nameof(System.Text.Encoding.GetString), new[] { typeof(byte[]) })]
        class GetStrings
        {
            [STAThread]
            static void Postfix(ref string __result)
            {
                try
                {
                    if(__result != "?")
                    {               
                        PatchLog($"Triggered Encoding.GetString.");
                        Log("Output: " + __result, "INFO", ConsoleColor.Yellow);
                    }
                    if (Hook.Config.Config.ConfigManager.SaveStrings == true)
                    {
                        Save.SaveString(__result);
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
               // return true;
            }
        }
    }
}
