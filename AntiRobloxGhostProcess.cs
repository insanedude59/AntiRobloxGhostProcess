using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace AntiRobloxGhostProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            int processes = 0;

            while (true)
            {
                Process[] arrProcess = Process.GetProcesses(); // get all processes

                Thread.Sleep(10); // prevent too much resource usage
                foreach (Process process in arrProcess) // loop through all the processes
                {
                    if (string.IsNullOrEmpty(process.MainWindowTitle)) // if they dont have a window name
                    {
                        if (process.ProcessName.Contains("Roblox")) // might kill other programs, idk
                        {
                            processes = processes + 1;

                            if (processes > 1) // if this wasn't here it would kill the roblox process when you open roblox, so..
                            {
                                Console.WriteLine("Killed ghost roblox process");
                                process.Kill();
                            }
                            continue;
                        }
                    }
                }
                processes = 0;
            }
        }
    }
}
