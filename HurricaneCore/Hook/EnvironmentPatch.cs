using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using static HurricaneCore.Logger;

namespace HurricaneCore.Patch
{
    internal class EnvironmentPatch
    {
        [HarmonyPatch(typeof(System.Environment), nameof(System.Environment.Exit), new[] { typeof(int) })]
        class FixEnvironmentExit
        {
            [STAThread]
            static bool Prefix(int exitCode)
            {
                try
                {
                    PatchLog($"Triggered Environment.Exit with code: {exitCode}");
                    return false;
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
