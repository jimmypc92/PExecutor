using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo pStartInfo = new ProcessStartInfo(@"c:\Windows\notepad");
            pStartInfo.RedirectStandardInput = true;
            pStartInfo.UseShellExecute = false;
            Process proc = Process.Start(pStartInfo);

            string userInput = Console.ReadLine();
            while (userInput != "quit")
            {
                WriteToProc(proc, userInput);
                userInput = Console.ReadLine();
            }
            proc.CloseMainWindow();
        }

        static void WriteToProc(Process p, string data)
        {
            using (StreamWriter iStream = p.StandardInput)
            {
                iStream.Write(data);
            }
        }
    }
}
