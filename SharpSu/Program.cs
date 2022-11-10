using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpSu.Args;
//using SharpSu.Commands;

namespace SharpSu
{
    class ProgramOptions
    {
        public string user;
        public string pass;
        public string shell;

        public ProgramOptions(string uUser = "", string uPass = "", string uShell = "")
        {
            user = uUser;
            pass = uPass;
            shell = uShell;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Program Options
            /// </summary>
            ProgramOptions options = new ProgramOptions();

            foreach (var arg in args)
            {
                if (arg.StartsWith("/user:"))
                {
                    string[] components = arg.Split(new string[] { "/user:" }, StringSplitOptions.None);
                    options.user = SanitizeInput(components[1]);
                }
                else if (arg.StartsWith("/pass:"))
                {
                    string[] components = arg.Split(new string[] { "/pass:" }, StringSplitOptions.None);
                    options.pass = SanitizeInput(components[1]);
                }
                else if (arg.StartsWith("/shell:"))
                {
                    string[] components = arg.Split(new string[] { "/shell:" }, StringSplitOptions.None);
                    options.shell = SanitizeInput(components[1]);
                }
                else
                {
                    Console.WriteLine($"[!] Invalid flag: {arg}");
                    return;
                }
            }

            if (options.user == "" & options.pass == "" & options.shell == "")
            {
                Help.ShowLogo();
                Help.ShowUsage();
                return;
            }
            else
            {
                // Verify if shell is valid
                if (options.shell == "powershell.exe")
                {
                    runAs(options.user, options.pass, options.shell);
                }
                else if (options.shell == "cmd.exe")
                {
                    runAs(options.user, options.pass, options.shell);
                }
                else
                {
                    Console.WriteLine($"[-] Invalid shell: {options.shell}");
                }
                
            }
        }
        // This code will remove quotes if exists. 
        public static string SanitizeInput(string input)
        {
            if (input == null)
                return "";

            string lastChar = input.Substring(input.Length - 1);
            string firstChar = input.Substring(0, 1);
            if (firstChar == lastChar)
            {
                if (lastChar == "'" || lastChar == '"'.ToString())
                    input = input.Trim(lastChar.ToCharArray());
            }
            return input;
        }

        static void runAs(string user, string password, string shell)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UserName = user;
                    myProcess.StartInfo.PasswordInClearText = password;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    //* This stream is used synchronously.
                    myProcess.StartInfo.RedirectStandardInput = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.StartInfo.RedirectStandardError = true;
                    //* Set your output and error (asynchronous) handlers
                    myProcess.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
                    myProcess.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
                    myProcess.StartInfo.FileName = shell;
                    myProcess.StartInfo.WorkingDirectory = "C:\\Windows\\System32\\";
                    //* Start process and handlers
                    myProcess.Start();
                    // Start asynchronous read
                    myProcess.BeginOutputReadLine();
                    myProcess.BeginErrorReadLine();

                    String inputText;
                    using (StreamWriter myStreamWriter = myProcess.StandardInput)
                    {
                        while (true)
                        {
                            //Console.Write("[+] Command > ");
                            inputText = Console.ReadLine();
                            if (!String.IsNullOrEmpty(inputText))
                            {
                                myStreamWriter.WriteLine(inputText);
                            }

                            if (inputText == "exit")
                            {
                                break;
                            }
                        }
                        myStreamWriter.Close();
                    }

                    myProcess.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!] Unhandled exception: {ex.Message}");
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
