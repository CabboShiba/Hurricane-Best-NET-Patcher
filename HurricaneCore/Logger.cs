
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HurricaneCore
{
    public class Logger
    {
        private static bool WinForm = false;
        public static void Log(string Data, string Type, ConsoleColor Color)
        {
            if (WinForm == true) 
            {
                MessageBox.Show(Data, Type, MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                Console.ForegroundColor = Color;
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} - {Type}] {Data}");
                Console.ResetColor();
            }
        }

        public static void PatchLog(string Data)
        {
            if(WinForm == true)
            {
                MessageBox.Show(Data, "Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} - Patch] {Data}");
                Console.ResetColor();
            }
        }
    }
}
