using HarmonyLib;
using HurricaneCore.Hook.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
namespace HurricaneCore.Hook
{
    internal class HashPatch
    {
   //     [HarmonyPatch(typeof(System.BitConverter), nameof(System.BitConverter.ToString), new[] { typeof(byte[]), typeof(int), typeof(int) })]
        class BitConverterPatch
        {
            static bool Prefix(ref byte[] value, ref int startIndex, ref int length, ref string __result)
            {
                if(__result != null)
                {
                    PatchLog($"Triggered BitConverter.ToString [Hash]: {__result}");
                }
                if (Config.Config.ConfigManager.CustomHash != null)
                {
                    try
                    {
                        PatchLog("Spoofing Hash...");
                        __result = Config.Config.ConfigManager.CustomHash;
                        PatchLog($"Succesfully spoofed HashString. New Hash: {__result}");
                    }
                    catch (System.Exception ex)
                    {
                        Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
