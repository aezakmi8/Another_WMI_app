using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Management.Instrumentation;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Another_WMI_app;

namespace Another_WMI_app
{
    class FilldtSourse:Form
    {
        public static DataTable dtSource = new DataTable();
        public static bool status;

        public static void GetProcess()
        {
            Process[] processes = Process.GetProcesses();
            //foreach (Process p in Process.GetProcesses("."))
            //add the control
            int count = 1;
            dtSource.Columns.Add("Process Name", typeof(string));
            dtSource.Columns.Add("Process ID", typeof(string));
            dtSource.Columns.Add("Process Owner", typeof(string));
            foreach (Process proc in processes)
            {
                count++;
                if (proc.MainWindowTitle != "")
                {
                    dtSource.Rows.Add((proc.ProcessName + " - " + proc.MainWindowTitle), proc.Id, GetProcessOwnerByProcessId(proc.Id));
                }
                else
                {
                    dtSource.Rows.Add(proc.ProcessName, proc.Id, GetProcessOwnerByProcessId(proc.Id));
                }
                //if (count == 5) {
                //    break; }
            }
            status = true;
        }

        public static string GetProcessOwnerByProcessId(int processId)
        {
            string user = "???";
            string domain = "???";

            var sq = new ObjectQuery("Select * from Win32_Process Where ProcessID = '" + processId + "'");
            var searcher = new ManagementObjectSearcher(sq);
            if (searcher.Get().Count != 1)
            {
                return user + "\\" + domain;
            }
            var process = searcher.Get().Cast<ManagementObject>().First();
            var ownerInfo = new string[2];
            process.InvokeMethod("GetOwner", ownerInfo);

            if (user != null)
            {
                user = ownerInfo[0];
            }
            if (domain != null)
            {
                domain = ownerInfo[1];
            }
            return user + "\\" + domain;
        }
    }
}
