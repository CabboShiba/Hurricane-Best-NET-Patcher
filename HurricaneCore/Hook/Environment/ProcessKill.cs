using HarmonyLib;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Environment
{
    internal class ProcessKill
    {
        //it gives stack overflow exception
        //[HarmonyPatch(typeof(System.Diagnostics.Process), nameof(System.Diagnostics.Process.Kill), MethodType.Normal)]
        class ProcessKillPatch
        {
            [STAThread]
            static bool Prefix(Process __instance)
            {
                try
                {
                    PatchLog("Triggered Process.Kill:");
                    Log("Process Name: " + __instance.ProcessName, "INFO", ConsoleColor.Yellow);
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
