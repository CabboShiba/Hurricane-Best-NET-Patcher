using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore
{
    public class MainClass
    {
        public static bool DLLInjection = false;
        public static bool Init = false;
        public static int MainMethod(string Arg)
        {
            if(Init == false)
            {
                HurricaneCore.Hook.Config.Config.ProcessConfig();
                Init = true;
            }
            if (Arg != null)
            {
                DLLInjection = true;
            }
            if(!File.Exists(Environment.CurrentDirectory + @"\Strings.txt"))
            {
                File.Create(Environment.CurrentDirectory + @"\Strings.txt");
            }
            try
            {
                Harmony patch = new Harmony("HurricaneCoreDLLPatcher_https://github.com/CabboShiba");
                patch.PatchAll(Assembly.GetExecutingAssembly());
                Logger.Log("Harmony Patches are ready!", "SUCCESS", ConsoleColor.Green);
            }
            catch(Exception ex)
            {
                Log($"Could not apply Harmony Patches. Please report this error to the developer.\n{ex.Message}", "ERROR", ConsoleColor.Red);
                return 1;
            }          
            return 0;
        }
    }
}
