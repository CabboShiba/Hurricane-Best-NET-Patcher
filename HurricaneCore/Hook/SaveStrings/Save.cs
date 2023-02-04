using System;
using System.IO;

namespace HurricaneCore.Hook.SaveStrings
{
    internal class Save
    {
        public static void SaveString(string String)
        {
            if (string.IsNullOrEmpty(String))
            {
                return;
            }
            try
            {
                File.AppendAllText(Environment.CurrentDirectory + @"\Strings.txt", String + "\n");
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
