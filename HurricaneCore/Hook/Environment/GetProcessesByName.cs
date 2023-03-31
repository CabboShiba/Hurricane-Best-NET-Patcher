using HarmonyLib;
using System;
using static HurricaneCore.Logger;
namespace HurricaneCore.Hook.Environment
{
    internal class GetProcessesByName
    {
        internal class GetProcesses
        {
            [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.GetProcessesByName), new[] { typeof(string) })]
            class PatchGetProcessesByName
            {
                [STAThread]
                static bool Prefix(ref string processName)
                {
                    try
                    {
                        Log("Triggered Process.GetProcessesByName with Name: " + processName, "INFO", ConsoleColor.Yellow);
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
}
