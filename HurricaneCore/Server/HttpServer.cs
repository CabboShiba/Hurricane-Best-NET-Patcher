using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;

using System.Threading.Tasks;
using static HurricaneCore.Logger;
namespace HurricaneCore.Server
{
    public class HttpServer
    {
        public static HttpListener ServerListener;
        public static string Payload = string.Empty;
        private const int StatusCode = 200;
        public static void StartServerListener()
        {
            while (true)
            {
                HttpListenerContext ctx = ServerListener.GetContext();

                HttpListenerRequest Request = ctx.Request;

                HttpListenerResponse Response = ctx.Response;

                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Log($"Accepted request from: {Request.Url}", "SERVER", ConsoleColor.Green);
                Log($"Request Host: {Request.UserHostName}", "SERVER", ConsoleColor.Green);
                Log($"Request Method: {Request.HttpMethod}", "SERVER", ConsoleColor.Green);
                Log($"Request KeepAlive: {Request.KeepAlive}", "SERVER", ConsoleColor.Green);
                if (Request.ContentType != null)
                {
                    Log($"Request ContentType: {Request.ContentType}", "SERVER", ConsoleColor.Green);
                }
                if (Request.UserAgent != null)
                {
                    Log($"Request UserAgent: {Request.UserAgent}", "SERVER", ConsoleColor.Green);
                }
                if (Request.HttpMethod == "POST" || Request.HttpMethod == "PUT")
                {
                    string Data = GetData(Request);
                    Log($"Request Content: {Data.Substring(0, 30)}.....", "SERVER", ConsoleColor.Magenta);
                    Log("Building response...", "BYPASS", ConsoleColor.Yellow);
                    Log("Response obtained.", "SUCCESS", ConsoleColor.Yellow);
                }
                if (HurricaneCore.Hook.Config.Config.ConfigManager.HttpServerResponse != null)
                {
                    Payload = HurricaneCore.Hook.Config.Config.ConfigManager.HttpServerResponse;
                }
                else
                {
                    Payload = $"[{DateTime.Now}] Tampered by Hurricane - Best .NET Patcher & Analyzer - https://github.com/CabboShiba";
                }
                try
                {

                    byte[] ResponsePayload = Encoding.UTF8.GetBytes(Payload);
                    Response.ContentType = "text/html";
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentLength64 = ResponsePayload.LongLength;
                    Response.StatusCode = StatusCode;
                    Response.OutputStream.WriteAsync(ResponsePayload, 0, ResponsePayload.Length);
                    Response.Close();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Log("Could not send Payload: ", "SERVER", ConsoleColor.Red);
                    Console.ResetColor();
                    Log(ex.Message, "SERVER", ConsoleColor.Red);
                }
            }
        }


        public static string GetData(HttpListenerRequest Request)
        {
            using (System.IO.Stream body = Request.InputStream)
            {
                using (var reader = new System.IO.StreamReader(body, Request.ContentEncoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
