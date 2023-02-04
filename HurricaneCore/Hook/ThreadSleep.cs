using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Patch
{
    internal class ThreadSleep
    {
        [HarmonyPatch(typeof(System.Threading.Thread), nameof(System.Threading.Thread.Sleep), new[] {typeof(int)})]
        class ThreadSleepPatch
        {
            [STAThread]
            static bool Prefix(ref int millisecondsTimeout)
            {
                try
                {
                    PatchLog($"Triggered Thread.Sleep with MS: {millisecondsTimeout}");
                    //millisecondsTimeout = 1000; //edit your value and return true;
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return false; // false = 0 ms     --- true = custom ms
            }
        }
    }
}
