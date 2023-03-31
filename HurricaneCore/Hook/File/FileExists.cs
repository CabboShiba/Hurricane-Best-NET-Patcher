using HarmonyLib;
using System;
using static HurricaneCore.Logger;
namespace HurricaneCore.Hook.File
{
    internal class FileExists
    {

        [HarmonyPatch(typeof(System.IO.File), nameof(System.IO.File.Exists), new[] { typeof(string) })]
        class PatchFileExists
        {
            [STAThread]
            static bool Prefix(ref string path, ref bool __result)
            {
                try
                {
                    Log("Triggered File.Exists with FilePath: " + path, "INFO", ConsoleColor.Yellow);
                    if (Config.Config.ConfigManager.FileExists)
                    {
                        Log($"Spoofing File.Exists result ({__result})...", "SPOOF", ConsoleColor.Yellow);
                        __result = true;
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
