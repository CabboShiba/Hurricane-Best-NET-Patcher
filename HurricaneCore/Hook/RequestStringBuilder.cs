using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Patch
{
    internal class RequestStringBuilder
    {
        [HarmonyPatch(typeof(System.IO.StreamReader), nameof(System.IO.StreamReader.ReadToEnd), MethodType.Normal)] //used to download strings from webclient
        class StringBuilder
        {
            [STAThread]
            static bool Prefix(ref string __result)
            {
                try
                {
                    PatchLog($"Triggered StreamReader.ReadToEnd: {__result}");
                    //__result = ""; here you can choose your custom response
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
