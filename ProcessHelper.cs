using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Data;

namespace InstanceManager
{
    public class ProcessHelper
    {
        public static string FocusedProcessName { get; set; }
        public static int FocusedProcessPID { get; set; }

        public static bool IsSelectingProcess;

        public static List<string> AllRunningProcesses = new List<string>();
        public static List<string> FocusedProcessesList = new List<string>();

        public static void GetAllRunningProcesses()
        {
            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                AllRunningProcesses.Add(process.ProcessName);
            }
        }

        public static void GetAllRunningInstancesOfFocusedProcess(string FocusedProcessName)
        {
            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (!process.ProcessName.Contains(FocusedProcessName))
                {
                    continue;
                }
                else if (process.ProcessName.Contains(FocusedProcessName))
                {
                    FocusedProcessesList.Add(process.ProcessName);
                }
            }
        }

        public static int GetProcessPID(string ProcessName)
        {
            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (!process.ProcessName.Contains(ProcessName))
                {
                    continue;
                }
                else if (process.ProcessName.Contains(ProcessName))
                {
                    return process.Id;
                }
            }

            return 0;
        }
    }
}
