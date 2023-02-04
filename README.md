# Hurricane-Best-NET-Patcher
Hurricane - The best .NET Patcher &amp; Analyzer. Made by Cabbo.

Hurricane is a tool that allow you to analyze most important method in a program. Please read Config Docs before using it.

# Why is it important

Thanks to Hurricane, you will be able to prevent malicious code execution, and analyze the HTTP/HTTPS Traffic.

Drag&Drop your file into Hurricane, and it will load your patched assembly.

Hurricane:

![image](https://user-images.githubusercontent.com/92642446/216778443-f27ba51c-97e4-4267-b96f-7c3ac4426d77.png)

# Patches List

- Console.Clear();

- Environment.Exit();

- Encoding.Default.GetBytes();

- File.Delete();

- Hash Calculator.

- HWID Reader [You can also spoof your HWID].

- Marshal.Copy [Used to prevent and block some checks - See [DNSpy](https://github.com/CabboShiba/AntiDNSpyDetector)].

- Process.Kill() [Really unstable. It doesn't work for now].

- Process.Start() [Block process from being started].

- StreamReader.ReadToEnd();

- Assembly.GetEntryAssembly() [Can spoof the Assembly].

- Assembly.GetCallingAssembly() [Can spoof the Assembly].

- String.Equals();

- Thread.Sleep();

- WebRequest.Create() [Can intercept HTTP/HTTPS URL].

# HttpServer

If needed, it will patch the WebRequest.Create() URL with a LocalHost URL [http://127.0.0.1/], and you will be able to choose your custom response.

# Native Layer

But, what if the file I'm trying to analyze, is protected by a Native Layer?

No problem!

Hurricane supports .DLL Injection, and it will inject all the patches in your file.

NOTE: Please put your file in the same Hurricane Folder, otherwise it will not work.

# Config Usage

How to use Config Manager:

- HookURl : bool - Set it to true if you want to modify the URL of WebRequest.Create();

- NewUrl: string - Put the new WebRequest.Create() URL.

- UseHttpServer: bool - Set it to true if you want to start the HttpServer.

- HttpServerResponse: string - Put the response for the HttpServer.

- CustomHash: string - If you want, you can choose a custom hash to use. Hurricane will automatically spoof it.

- AllowProcessStart: bool - Set it to true if you want to start unknown process from your application. I recommend to keep it false.

- ShowStringEquals: bool - Show all String.Equals(), and their strings. I recommend to keep it false.

- InjectDLLFail: bool - Set it to true if you want to inject Hurricane .DLL, instead of loading it. This will work only if the normal loading method did not work. Set it to true if you are working on Native Layer.

- SaveStrings: bool - Set it to true if you want to save all dumped strings.

- CustomHWID: string - You can set your new HWID. Hurricane will automatically spoof it.

- DelayBeforeStart: int - Set the delay before loading the assembly.


# Do you want to contact me?

Discord: FreeCabbo11#9191 - New Account. Please do not contact me anymore on FreeCabbo10, it got termed.

Telegram: https://t.me/cabboshiba
