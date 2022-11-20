using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSu2.Args
{
    internal class Help
    {
        public static void ShowLogo()
        {
            string logo = @"
   _____ _                      _____       ___  
  / ____| |                    / ____|     |__ \ 
 | (___ | |__   __ _ _ __ _ __| (___  _   _   ) |
  \___ \| '_ \ / _` | '__| '_ \\___ \| | | | / / 
  ____) | | | | (_| | |  | |_) |___) | |_| |/ /_ 
 |_____/|_| |_|\__,_|_|  | .__/_____/ \__,_|____|
                         | |                     
                         |_|                     
                          
                   Switch User
                Author @nozerobit
";
            Console.WriteLine(logo);
        }
        public static void ShowUsage()
        {
            string usage = @"
The arguments listed below are required

    /user:  username
    /pass:  password
    /shell: cmd.exe or powershell.exe

Requirement: You need a shell that can spawn child processes (e.g cmd.exe or powershell.exe)

Note: If the password contains special characters use single quotes

Important: Use the exit command to close the shell or program

Example:
    SharpSu.exe /user:LazyUser /pass:'@$^ULKIr4nd0m##!3' /shell:powershell.exe
";
            Console.WriteLine(usage);
        }
    }
}
