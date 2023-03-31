using HarmonyLib;
using HurricaneCore.Hook.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
using static HurricaneCore.Hook.Config.Config;
namespace HurricaneCore.Hook.Strings
{
    internal class StringEquals
    {
        [HarmonyPatch(typeof(string), nameof(string.Equals), new[] { typeof(string), typeof(string) })]
        class StringEqualsPatch
        {
            [STAThread]
            static bool Prefix(ref string a, ref string b)
            {
                
                if (ConfigManager.ShowStringEquals == false || MainClass.DLLInjection == true)
                {
                    return true;
                }
                try
                {
                    PatchLog("Triggered String.Equals:");
                    PatchLog($"First string: {a}");
                    PatchLog($"Second string: {b}");
                    // a = "";
                    //b = "";  //you can modify also the strings
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
