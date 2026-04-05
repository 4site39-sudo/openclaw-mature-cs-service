using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace UltraSimple
{
    class Program
    {
        static void Main()
        {
            string cmd = @"C:\OpenClaw\SystemHelper\ultra_cmd.txt";
            string res = @"C:\OpenClaw\SystemHelper\ultra_result.txt";
            
            while (true)
            {
                try
                {
                    if (File.Exists(cmd))
                    {
                        string command = File.ReadAllText(cmd).Trim();
                        if (command != "")
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = "cmd.exe";
                            p.StartInfo.Arguments = "/c " + command;
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.RedirectStandardOutput = true;
                            p.StartInfo.RedirectStandardError = true;
                            p.StartInfo.CreateNoWindow = true;
                            p.Start();
                            string output = p.StandardOutput.ReadToEnd();
                            string error = p.StandardError.ReadToEnd();
                            p.WaitForExit();
                            File.WriteAllText(res, "EXIT:" + p.ExitCode + "\nOUT:" + output + "\nERR:" + error);
                            File.Delete(cmd);
                        }
                    }
                }
                catch {}
                
                Thread.Sleep(100);
            }
        }
    }
}
