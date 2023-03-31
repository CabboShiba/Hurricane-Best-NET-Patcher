using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static HurricaneCore.Logger;

namespace Hurricane
{
    internal class Utils
    {
        public static void Leave()
        {
            Log("Press enter to leave...", "HURRICANE", ConsoleColor.Cyan);
            Console.ReadLine();
            //Process.GetCurrentProcess().Kill();
        }

        private static Random Random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "qwertyuioplkjhgfdsazxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string File = null;

        public static void CheckFile()
        {
            if (!System.IO.File.Exists(File))
            {
                Log($"File not found. Please load a valid executable [.EXE] file.", "ERROR", ConsoleColor.Red);
                Utils.Leave();
            }
        }
    }
}