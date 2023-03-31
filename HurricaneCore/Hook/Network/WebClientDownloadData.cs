using HarmonyLib;
using System;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Network
{
    internal class WebClientDownloadData
    {
        // it gives stack overflow exception 
        //[HarmonyPatch(typeof(System.Net.WebClient), nameof(System.Net.WebClient.DownloadData), new[] { typeof(string) })]
        class DownloadData
        {
            [STAThread]
            static bool Prefix(string address)
            {
                try
                {
                    Log("Triggered WebClient.DownloadData with URL: " + address, "URL", ConsoleColor.Yellow);
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
