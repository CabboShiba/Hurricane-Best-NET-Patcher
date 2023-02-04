using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurricaneCore
{
    public class Logger
    {
        public static void Log(string Data, string Type, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} - {Type}] {Data}");
            Console.ResetColor();
        }

        public static void PatchLog(string Data)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} - Patch] {Data}");
            Console.ResetColor();
        }
    }
}
