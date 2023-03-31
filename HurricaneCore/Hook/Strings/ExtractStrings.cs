using HarmonyLib;
using HurricaneCore.Hook.SaveStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Strings
{
    internal class ExtractStrings
    {
        [HarmonyPatch(typeof(System.Text.Encoding), nameof(System.Text.Encoding.Default.GetBytes), new[] { typeof(string) })]
        class GetStrings
        {
            [STAThread]
            static bool Prefix(ref string s)
            {
                try
                {
                    PatchLog($"Triggered Encoding.Default.GetBytes: {s}");
                    if (Hook.Config.Config.ConfigManager.SaveStrings == true)
                    {
                        Save.SaveString(s);
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
