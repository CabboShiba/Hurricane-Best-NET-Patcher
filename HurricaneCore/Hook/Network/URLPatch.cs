using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HurricaneCore.Logger;

using static HurricaneCore.Hook.Config.Config;

namespace HurricaneCore.Hook.Network
{
    internal class URLPatch
    {
        [HarmonyPatch(typeof(System.Net.WebRequest), nameof(System.Net.WebRequest.Create), new[] { typeof(Uri), typeof(bool) })]
        class URLRequestPatch
        {
            [STAThread]
            static bool Prefix(ref Uri requestUri, ref bool useUriBase)
            {
                try
                {
                    Log("Triggered WebRequest.Create with URL: " + requestUri.ToString(), "URL", ConsoleColor.Yellow);
                    if (ConfigManager.HookURL == true)
                    {
                        Log("Fixing...", "URL", ConsoleColor.Yellow);
                        System.Uri Uri = new System.Uri(ConfigManager.NewUrl); 
                        requestUri = Uri;
                        Log("Fixed URL: " + requestUri, "URL", ConsoleColor.Yellow);
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
