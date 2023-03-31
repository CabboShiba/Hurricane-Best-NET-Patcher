using HarmonyLib;
using HurricaneCore.Hook.Config;
using System;
using static HurricaneCore.Logger;


namespace HurricaneCore.Registry
{
    internal class GetValue
    {
        [HarmonyPatch(typeof(Microsoft.Win32.Registry), nameof(Microsoft.Win32.Registry.GetValue))]
        class PatchGetValue
        {
            [STAThread]
            static bool Prefix(string keyName, string valueName, object defaultValue)
            {
                try
                {
                    Log("Triggered Registry.GetValue.", "INFO", ConsoleColor.Yellow);
                    Log("Registry Key Path: " + keyName, "INFO", ConsoleColor.Yellow);
                    Log("Registry Value Name: " + valueName, "INFO", ConsoleColor.Yellow);
                    //processName = ""; you can also change it
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
