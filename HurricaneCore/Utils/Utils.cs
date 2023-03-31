using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace HurricaneCore
{
    public class Utils
    {
        public static void Leave()
        {
            Logger.Log("Press enter to leave...", "Hurricane", ConsoleColor.Cyan);
            Console.ReadLine();
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
                Logger.Log($"File not found. Please load a valid executable [.EXE] file.", "ERROR", ConsoleColor.Red);
                Utils.Leave();
            }
        }

        public static Assembly LoadedAssembly = null;
    }
}