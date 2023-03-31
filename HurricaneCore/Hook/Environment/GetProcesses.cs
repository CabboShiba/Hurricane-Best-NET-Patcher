using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Environment
{
    internal class GetProcesses
    {
        [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.GetProcesses), new[] {typeof(string)})]
        class PatchGetProcesses
        {
            [STAThread]
            static bool Prefix(string machineName)
            {
                try
                {
                    Log("Triggered Process.GetProcesses", "INFO", ConsoleColor.Yellow);
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
