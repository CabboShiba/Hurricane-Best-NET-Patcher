using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using static HurricaneCore.Logger;

namespace Hurricane.Update
{
    internal class CheckUpdates
    {
        private const string CurrentVersion = "1.1\n";
        private static string DownloadedVersion = null;
        private const string Link = "https://raw.githubusercontent.com/CabboShiba/Hurricane-Best-NET-Patcher/main/CurrentVersion";
        private static WebClient WC;
        public static void UpdateAvailable()
        {
            try
            {
                WC = new WebClient();
                DownloadedVersion = WC.DownloadString(Link);
                if (DownloadedVersion != CurrentVersion)
                {
                    Log($"Update Available. Please, download latest version from GitHub. Current version: {CurrentVersion}", "UPDATE", ConsoleColor.Yellow);
                }
                else
                {
                    Log($"You are using the latest Hurricane version. Current Version: {CurrentVersion}", "SUCCESS", ConsoleColor.Green);
                }
            }
            catch(Exception ex)
            {
                Log($"Error during Update Check:\n{ex.Message}\n\nPlease, check on GitHub for latest version:\nhttps://github.com/CabboShiba/Hurricane-Best-NET-Patcher", "ERROR", ConsoleColor.Red);
                //Utils.Leave();
            }
        }
    }
}
