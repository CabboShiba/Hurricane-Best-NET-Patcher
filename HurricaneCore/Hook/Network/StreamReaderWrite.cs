using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook.Network
{
    internal class StreamReaderWrite
    {
        //Not working idk why lmfao
        [HarmonyPatch(typeof(System.IO.TextWriter), nameof(System.IO.TextWriter.Write), new[] { typeof(string)})]
        class StreamReaderPatch
        {
            [STAThread]
            static bool Prefix(string value)
            {
                try
                {
                    Log("Triggered TextWriter.Write with content: " + value, "INFO", ConsoleColor.Yellow);
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
