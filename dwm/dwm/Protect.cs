using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dwm
{
    class Protect
    {
        public static void Check()
        {
            for (; ; )
            {
                foreach (Process process in Process.GetProcesses())
                {
                    bool flag =
                        process.ProcessName.Contains("smsniff") || process.ProcessName.Contains("HttpAnalyzer") || process.ProcessName.Contains("dnSpy") ||
                        process.ProcessName.Contains("IDA") || process.ProcessName.Contains("Olly") || process.ProcessName.Contains("Dumper") ||
                        process.ProcessName.Contains("Reflector") || process.ProcessName.Contains("Wireshark") || process.ProcessName.Contains("WPE") ||
                        process.ProcessName.Contains("HTTP Debugger Pro") || process.ProcessName.Contains("The Wireshark Network Analyzer") || process.ProcessName.Contains("WinDbg") ||
                        process.ProcessName.Contains("Colasoft Capsa") || process.ProcessName.Contains("OllyDbg") || process.ProcessName.Contains("WPE PRO") ||
                        process.ProcessName.Contains("Microsoft Network Monitor") || process.ProcessName.Contains("Fiddler") || process.ProcessName.Contains("SmartSniff") ||
                        process.ProcessName.Contains("Immunity Debugger") || process.ProcessName.Contains("Process Explorer") || process.ProcessName.Contains("PE Tools") ||
                        process.ProcessName.Contains("AQtime") || process.ProcessName.Contains("DS-5 Debug") || process.ProcessName.Contains("Dbxtool") ||
                        process.ProcessName.Contains("Topaz") || process.ProcessName.Contains("FusionDebug") || process.ProcessName.Contains("NetBeans") ||
                        process.ProcessName.Contains("Rational Purify") || process.ProcessName.Contains(".NET Reflector") || process.ProcessName.Contains("Cheat Engine") ||
                        process.ProcessName.Contains("Sigma Engine");


                    if (flag)
                    {
                        Environment.Exit(0);
                    }
                }
                Thread.Sleep(150);
            }
        }
    }
}
