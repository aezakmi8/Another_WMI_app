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
    class FilldtSourse : Form
    {
        public static DataTable ProcdtSource = new DataTable();
        public static DataTable InsAppsdtSource = new DataTable();
        public static DataTable UsersdtSource = new DataTable();
        public static bool procFilled;
        public static bool appsFilled;
        public static bool usersFilled;
 
        //-----------------------------ProcTab-----------------------------
        public static async Task Proc()
        {
            if (!procFilled) //если таблица уже была создана
            {
                ProcdtSource.Columns.Add("Process Name", typeof(string));
                ProcdtSource.Columns.Add("Process ID", typeof(string));
                ProcdtSource.Columns.Add("Process Owner", typeof(string));
            }
            procFilled = true;
            ProcdtSource.Rows.Clear();
            //заполнить
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                var ownerByProcessResult = await GetProcessOwnerByProcessId(proc.Id);
                if (proc.MainWindowTitle != "")
                {
                    ProcdtSource.Rows.Add((proc.ProcessName + " - " + proc.MainWindowTitle), proc.Id, ownerByProcessResult);
                }
                else
                {
                    ProcdtSource.Rows.Add(proc.ProcessName, proc.Id, ownerByProcessResult);
                }
            }
        }

        public static Task<string> GetProcessOwnerByProcessId(int processId)
        {
            string user = "???";
            string domain = "???";
            {
                var objectQuery = new ObjectQuery("Select * from Win32_Process Where ProcessID = '" + processId + "'");
                var searcher = new ManagementObjectSearcher(objectQuery);
                if (searcher.Get().Count != 1)
                {
                    return Task.Run(() =>
                    {
                        return user + "\\" + domain;
                    });
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
            }
            return Task.Run(() =>
            {
                return user + "\\" + domain;
            });
        }
        public static async Task KillById(int processId)
        {
            Process process = Process.GetProcessById(processId);
            try
            {
                process.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-----------------------------InstAppsTab-----------------------------
        public static async Task InstalldApps()
        {
            if (!appsFilled) //если таблица не была создана
            {
                InsAppsdtSource.Columns.Add("App Name", typeof(string));
                InsAppsdtSource.Columns.Add("App Version", typeof(string));
            }
            InsAppsdtSource.Rows.Clear();
            appsFilled = true;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                InsAppsdtSource.Rows.Add(queryObj["Name"], queryObj["Version"]);
            }
        }

        //-----------------------------UsersTab-----------------------------
        public static async Task Users()
        {
            if (!usersFilled) //если таблица не была создана
            {
                UsersdtSource.Columns.Add("usName", typeof(string));
                UsersdtSource.Columns.Add("Status", typeof(string));
                UsersdtSource.Columns.Add("Domain", typeof(string));
            }
            UsersdtSource.Rows.Clear();
            usersFilled = true;
            ManagementObjectSearcher usersSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");
            foreach (ManagementObject users in usersSearcher.Get())
            {
                UsersdtSource.Rows.Add(users["Name"], users["Status"], users["Domain"]);
            }
        }
    }
}
