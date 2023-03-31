using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
namespace HurricaneCore.Hook.File
{
    internal class FileReadAllText
    {
        [HarmonyPatch(typeof(System.IO.File), nameof(System.IO.File.ReadAllText), new[] { typeof(string)})]
        class PatchReadAllText
        {
            [STAThread]
            static bool Prefix(string path)
            {

                try
                {
                    PatchLog($"Triggered File.ReadAllText with FilePath: {path}");
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
