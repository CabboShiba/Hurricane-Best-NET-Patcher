using HarmonyLib;
using Hurricane.Injection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
using static HurricaneCore.Utils;
namespace Hurricane
{
    internal class Loader
    {
        public static bool LoadAssembly()
        {            
            try
            {
                object[] parameters = null;
                LoadedAssembly = Assembly.LoadFile(Path.GetFullPath(Utils.File));
                var paraminfo = LoadedAssembly.EntryPoint.GetParameters();
                parameters = new object[paraminfo.Length];
                //  Harmony patch = new Harmony("HurricanePatcher_https://github.com/CabboShiba");
                //  patch.PatchAll(Assembly.GetExecutingAssembly());
                HurricaneCore.MainClass.MainMethod(null);
                LoadedAssembly.EntryPoint.Invoke(null, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Log($"Could not load {Utils.File}\n{ex}", "ERROR", ConsoleColor.Red);
                if(HurricaneCore.Hook.Config.Config.ConfigManager.InjectDLLFail == true)
                {
                    DLLInjection.InjectDLL();
                }
            }
            return false;
        }
    }
}
