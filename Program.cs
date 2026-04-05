using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace OpenClawMatureService
{
    public class Program
    {
        private static readonly string CommandFile = @"C:\OpenClaw\SystemHelper\mature_cmd.txt";
        private static readonly string ResultFile = @"C:\OpenClaw\SystemHelper\mature_result.txt";
        private static readonly string LogFile = @"C:\OpenClaw\SystemHelper\mature_log.txt";

        public static void Main()
        {
            Log("MAIN: OpenClaw Mature C# Service started");
            
            while (true)
            {
                try
                {
                    if (File.Exists(CommandFile))
                    {
                        string command = File.ReadAllText(CommandFile).Trim();
                        Log($"MAIN: Found command: {command}");
                        
                        if (!string.IsNullOrEmpty(command))
                        {
                            string result = ExecuteCommand(command);
                            File.WriteAllText(ResultFile, result);
                            File.Delete(CommandFile);
                            Log($"MAIN: Command executed, result saved");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log($"MAIN ERROR: {ex.Message}");
                }
                
                Thread.Sleep(100);
            }
        }

        private static string ExecuteCommand(string command)
        {
            try
            {
                Log($"EXECUTE: Starting process for: {command}");
                
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                
                Log($"EXECUTE: Process exited with code {process.ExitCode}");
                
                return $"EXIT CODE: {process.ExitCode}\n" +
                       $"OUTPUT:\n{output}\n" +
                       $"ERROR:\n{error}";
            }
            catch (Exception ex)
            {
                Log($"EXECUTE ERROR: {ex.Message}");
                return $"ERROR: {ex.Message}";
            }
        }

        private static void Log(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                File.AppendAllText(LogFile, logEntry + Environment.NewLine);
            }
            catch
            {
                // Silent fail for logging errors
            }
        }
    }
}
