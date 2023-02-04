using HurricaneCore.Hook.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Hurricane.Injection.Native.Native;
using static HurricaneCore.Logger;

// thx https://www.unknowncheats.me/forum/c-/82629-basic-dll-injector.html
namespace Hurricane.Injection
{
    internal class DLLInjection
    {
        public static bool DLLInjected = false;
        public static void InjectDLL()
        {
            try
            {
                Utils.CheckFile();
                Process.Start(Utils.File);
            }
            catch (Exception ex)
            {
                Log($"Could not start Process: {Utils.File}\n{ex.Message}", "INJECTION-ERROR", ConsoleColor.Red);
            }
            try
            {
                uint ProcessID = 0;
                Process targetProcess = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Utils.File))[0];
                ProcessID = (uint)targetProcess.Id;
                Log($"Obtained ProcessID: {ProcessID}", "INJECTION", ConsoleColor.Cyan);
                DLLInjected = Do(ProcessID, Environment.CurrentDirectory + $"\\Injection{Config.ConfigManager.FileArchitecture}.dll");
                if(DLLInjected == true)
                {
                    Log(".DLL Succesfully injected. Harmony Patches should start running.", "SUCCESS", ConsoleColor.Green);
                }
                else
                {
                    Log(".DLL could not be injected.", "ERROR", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Log($"Could not inject .DLL\n{ex.Message}", "INJECTION-ERROR", ConsoleColor.Red);
            }
        }
        private static bool Do(uint pToBeInjected, string sDllPath)
        {
            IntPtr hndProc = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, pToBeInjected);
            if (hndProc == INTPTR_ZERO)
            {
                return false;
            }
            IntPtr lpLLAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (lpLLAddress == INTPTR_ZERO)
            {
                return false;
            }
            IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)sDllPath.Length, (0x1000 | 0x2000), 0X40);
            if (lpAddress == INTPTR_ZERO)
            {
                return false;
            }
            byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
            if (WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
            {
                return false;
            }
            if (CreateRemoteThread(hndProc, (IntPtr)null, INTPTR_ZERO, lpLLAddress, lpAddress, 0, (IntPtr)null) == INTPTR_ZERO)
            {
                return false;
            }
            CloseHandle(hndProc);
            return true;
        }
    }
}
