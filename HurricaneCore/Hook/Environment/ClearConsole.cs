using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Environment
{
    internal class ClearConsole
    {
        [HarmonyPatch(typeof(System.Console), nameof(System.Console.Clear), MethodType.Normal)]
        class CLSPatch
        {
            [STAThread]
            static bool Prefix()
            {
                try
                {
                    PatchLog($"Triggered Console.Clear");
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                Console.ResetColor();
                return false; // false = do not clear console   ----- true =  clear console
            }
        }
    }
}
