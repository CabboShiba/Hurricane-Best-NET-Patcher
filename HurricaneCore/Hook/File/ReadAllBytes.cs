using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;
namespace HurricaneCore.Hook.File
{
    internal class ReadAllBytes
    {
        [HarmonyPatch(typeof(System.IO.File), nameof(System.IO.File.ReadAllBytes), new[] { typeof(string) })]
        class PatchReadAllBytes
        {
            [STAThread]
            static bool Prefix(string path)
            {

                try
                {
                    PatchLog($"Triggered File.ReadAllBytes with FilePath: {path}");
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
