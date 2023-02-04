using HarmonyLib;
using HurricaneCore.Hook.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Patch
{
    internal class ProcessStart
    {
        [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Start), new[] { typeof(string) })]
        class ProcessStartPatch
        {
            [STAThread]
            static bool Prefix(ref string fileName)
            {
                try
                {
                    PatchLog($"Triggered Process.Start with ProcessName: {fileName}");
                    //fileName = ""; //you can also patch filename / filepath
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return Config.ConfigManager.AllowProcessStart; //this will block Process.Start - use false
            }
        }
        [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Start), new[] { typeof(ProcessStartInfo) })]
        class ProcessStartPatchProcess
        {
            [STAThread]
            static bool Prefix(ref ProcessStartInfo startInfo)
            {
                try
                {
                    Log($"Triggered Process.Start with ProcessStartInfo: {startInfo.FileName}", "INFO", ConsoleColor.Yellow);
                    Log($"Arguments: {startInfo.Arguments}", "INFO", ConsoleColor.Yellow);
                    Log($"CreateNoWindow: {startInfo.CreateNoWindow}", "INFO", ConsoleColor.Yellow);
                    Log($"UseShellExecute: {startInfo.UseShellExecute}", "INFO", ConsoleColor.Yellow);
                    //fileName = ""; //you can also patch filename / filepath

                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return Config.ConfigManager.AllowProcessStart; //this will block Process.Start - use false
            }
        }
    }
}
