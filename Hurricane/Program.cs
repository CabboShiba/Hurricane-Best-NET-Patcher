using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static HurricaneCore.Logger;
using System.IO;

namespace Hurricane
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"[{DateTime.Now}] Hurricane - Best .NET Patcher & Analyzer. Made by https://github.com/CabboShiba";
            Update.CheckUpdates.UpdateAvailable();
            HurricaneCore.Hook.Config.Config.ProcessConfig();
            HurricaneCore.MainClass.Init = true;
            try
            {
                Utils.File = args[0];
                FileInfo info = new FileInfo(Utils.File);
                if (info.Extension != ".exe")
                {
                    Log("Please load a valid executable file [.EXE]", "ERROR", ConsoleColor.Red);
                    Utils.Leave();
                }
            }
            catch (Exception ex)
            {
                Log("Please use Drag&Drop.", "ERROR", ConsoleColor.Red);
                Utils.Leave();
            }
            Utils.CheckFile();
            int Delay = HurricaneCore.Hook.Config.Config.ConfigManager.DelayBeforeStart;
            if(Delay < 0)
            {
                Delay = 3;
            }
            for (int i = Delay; i >= 0; i--)
            {
                Log($"Starting in {i} seconds...", "LOADING", ConsoleColor.Cyan);
                Thread.Sleep(1000);
            }
            Console.Clear();
            Loader.LoadAssembly();
            Utils.Leave();
        }
    }
}
