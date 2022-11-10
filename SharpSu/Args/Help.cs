using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSu.Args
{
    internal class Help
    {
        public static void ShowLogo()
        {
            string logo = @"

███████╗██╗  ██╗ █████╗ ██████╗ ██████╗ ███████╗██╗   ██╗
██╔════╝██║  ██║██╔══██╗██╔══██╗██╔══██╗██╔════╝██║   ██║
███████╗███████║███████║██████╔╝██████╔╝███████╗██║   ██║
╚════██║██╔══██║██╔══██║██╔══██╗██╔═══╝ ╚════██║██║   ██║
███████║██║  ██║██║  ██║██║  ██║██║     ███████║╚██████╔╝
╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝ ╚═════╝ 
                          
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

Note: If the password contains special characters use single quotes

Important: Use the exit command to close the shell or program

Example:
    SharpSu.exe /user:LazyUser /pass:'@$^ULKIr4nd0m##!3' /shell:powershell.exe
";
            Console.WriteLine(usage);
        }
    }
}
