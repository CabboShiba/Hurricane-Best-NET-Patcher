using HurricaneCore.Server;
using System;
using System.Net;
using System.Threading;
using static HurricaneCore.Logger;
using System.IO;
using Newtonsoft.Json;

namespace HurricaneCore.Hook.Config
{
    public class Config
    {
        private static string ConfigPath;
        public static void ProcessConfig()
        {
            ConfigPath = Environment.CurrentDirectory + @"\Config.json";
            if (!File.Exists(ConfigPath))
            {
                var Patch = new PatchConfig
                {
                    AllowProcessStart = false,
                    FileArchitecture = "32",
                    SpoofAssembly = true,
                    SaveStrings = true,
                    DelayBeforeStart = 3,
                };
                string JsonSerialized = JsonConvert.SerializeObject(Patch, Formatting.Indented);
                File.WriteAllText(ConfigPath, JsonSerialized);
            }

            ConfigManager = JsonConvert.DeserializeObject<PatchConfig>(File.ReadAllText(ConfigPath));

            if (ConfigManager.UseHttpServer == true)
            {
                if (HttpListener.IsSupported == false)
                {
                    Log("HTTPListener is not supported on your PC/OS.", "SERVER", ConsoleColor.Red);
                    Utils.Leave();
                }
                try
                {
                    Log("Starting server on http://127.0.0.1/...", "SERVER", ConsoleColor.Cyan);
                    HttpServer.ServerListener = new HttpListener();
                    HttpServer.ServerListener.Prefixes.Add("http://*:80/");
                    HttpServer.ServerListener.Start();
                    Log("Server succesfully started...", "SUCCESS", ConsoleColor.Cyan);
                    Thread Server = new Thread(new ThreadStart(HttpServer.StartServerListener));
                    Server.Start();
                }
                catch (System.Exception ex)
                {
                    Log($"Error detected: {ex.Message}", "ERROR", ConsoleColor.Red);
                    Thread.Sleep(5000);
                }
            }
        }


        public static PatchConfig ConfigManager;
        public static void ReadConfig()
        {
            return;
        }

        public class PatchConfig
        {
            public bool HookURL { get; set; }
            public string NewUrl { get; set; }
            public bool UseHttpServer { get; set; }
            public string HttpServerResponse { get; set; }
            public string CustomHash { get; set; }
            public bool AllowProcessStart { get; set; }
            public bool SpoofAssembly { get; set; }
            public bool ShowStringEquals { get; set; }
            public bool InjectDLLFail { get; set; }
            public bool SaveStrings { get; set; }
            public string CustomHWID { get; set; }
            public int DelayBeforeStart { get; set; }

            public string FileArchitecture { get; set;}
        }

        public class Url
        {
            public string NewUrl;
        }
    }
}
