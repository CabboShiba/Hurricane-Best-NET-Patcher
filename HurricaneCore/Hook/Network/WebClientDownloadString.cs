using HarmonyLib;
using System;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Network
{
    internal class WebClientDownloadString
    {
        [HarmonyPatch(typeof(System.Net.WebClient), nameof(System.Net.WebClient.DownloadString), new[] { typeof(string)})]
        class DownloadString
        {
            [STAThread]
            static bool Prefix(string address)
            {
                try
                {
                    Log("Triggered WebClient.DownloadString with URL: " + address, "URL", ConsoleColor.Yellow);
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
