using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HurricaneCore.Logger;

namespace HurricaneCore.Hook
{
    internal class MarshalCopy
    {
        public static Type HookedClass = typeof(System.Runtime.InteropServices.Marshal);

        private const string HookedMethod = nameof(System.Runtime.InteropServices.Marshal.Copy);

        private static string GetMethod = $"{HookedClass.FullName}.{HookedMethod}";

        [HarmonyPatch(typeof(System.Runtime.InteropServices.Marshal), HookedMethod, new[] { typeof(IntPtr), typeof(byte[]), typeof(int), typeof(int) })]
        class HookMarshal
        {
            static bool Prefix(IntPtr source, byte[] destination, int startIndex, int length)
            {
                try
                {
                    PatchLog($"Triggered Method: {GetMethod}");
                    Log($"IntPtr: {source}", "PARAMS", ConsoleColor.Cyan);
                    Log($"StartIndex: {startIndex}", "PARAMS", ConsoleColor.Cyan);
                    Log($"Length: {length}", "PARAMS", ConsoleColor.Cyan);
                    return false;

                }
                catch(System.Exception ex)
                {
                    Log($"Error during Patch:\n {ex}", "ERROR", ConsoleColor.Red);
                }
                return true;
            }
        }
    }
}
