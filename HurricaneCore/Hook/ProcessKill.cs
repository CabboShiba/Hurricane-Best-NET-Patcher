using HarmonyLib;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
namespace HurricaneCore.Patch
{
    internal class ProcessKill
    {
       // [HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Kill), MethodType.Normal)]
        class ProcessKillPatch
        {
            [STAThread]
            static bool Prefix()
            {
                try
                {
                    PatchLog("Triggered Process.Kill");
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return false;
            }
        }
    }
}
