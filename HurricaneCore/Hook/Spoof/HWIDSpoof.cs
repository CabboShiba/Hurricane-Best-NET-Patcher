using HarmonyLib;
using HurricaneCore.Hook.Config;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Spoof
{
    internal class HWIDSpoof
    {
        [HarmonyPatch(typeof(System.Security.Principal.SecurityIdentifier), nameof(System.Security.Principal.SecurityIdentifier.Value), MethodType.Getter)]
        class Spoof
        {
            [STAThread]
            static bool Prefix(ref string __result)
            {
                try
                {
                    PatchLog("Triggered SecurityIdentifier.Value [HardWare-ID].");
                    if(Config.Config.ConfigManager.CustomHWID != null)
                    {
                        Log("Spoofing HardWare-ID...", "HWID", ConsoleColor.Yellow);
                        string HWIDSpoofed = Config.Config.ConfigManager.CustomHWID;
                        __result = HWIDSpoofed;
                        Log($"Succesfully spoofed HardWare-ID [{__result}]", "HWID", ConsoleColor.Yellow);
                        return false;
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
