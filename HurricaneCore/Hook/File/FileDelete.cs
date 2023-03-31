using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.File
{
    internal class FileDelete
    {
        [HarmonyPatch(typeof(System.IO.File), nameof(System.IO.File.Delete), new[] { typeof(string) })]
        class FileDeletePatch
        {
            [STAThread]
            static bool Prefix(ref string path)
            {
                try
                {
                    PatchLog($"Triggered File.Delete with FilePath: {path}");
                }
                catch (Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return true; //leave true
            }
        }
    }
}
