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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Another_WMI_app
{
    class FilldtSourse1 : Form
    {
        public static DataTable ProcdtSource = new DataTable();
        public static DataTable InsAppsdtSource = new DataTable();
        public static DataTable UsersdtSource = new DataTable();
        public static bool procFilled;
        public static bool appsFilled;
        public static bool usersFilled;

        //-----------------------------HardInfoTab-------------------------
        public async Task<TreeNode> ListToNode(string className)
        {
            Console.WriteLine("Searching...");
            var node = new TreeNode(className);
            Form1 form = new Form1();
            int count = 0;
            //tree.Nodes.Add(className);
            var prop = await AddPropToList(className);
            foreach (var nodeName in prop)
            {
                node.Nodes[count].Nodes.Add(nodeName);
            }
            Console.WriteLine(count + " classes found.");
            return node;
            //return Task.Run(() =>{return tree; });
        }

        public async Task<List<string>> AddPropToList(string Win32_Process)
        {
            List<string> result = new List<string>();
            int someshitCounter = 0;
            int propertyCount = 0;
            Console.WriteLine("Searching...");
            try
            {
                // Gets the propertys.
                ObjectGetOptions op = new ObjectGetOptions(null, new TimeSpan(1), true);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + Win32_Process);
                ManagementClass mc = new ManagementClass("root\\CIMV2", Win32_Process, op);
                mc.Options.UseAmendedQualifiers = true;
                foreach (PropertyData dataObject in mc.Properties)
                {
                    foreach (ManagementObject wmiObject in searcher.Get())
                    {
                        if (wmiObject.Properties[dataObject.Name].IsArray)
                        {
                            // Do nothing.
                        }
                        // Property is not an array.
                        else if (wmiObject.Properties[dataObject.Name].Type.ToString().Equals(null))
                        {
                            // property is null.
                            // Do nothing.
                        }
                        else if (wmiObject.Properties[dataObject.Name].Type.ToString().Equals("String"))
                        {
                            result.Add(dataObject.Name + " = " + wmiObject.GetPropertyValue(dataObject.Name).ToString().Trim());
                        }
                        //shithappend
                        else someshitCounter++;
                        propertyCount++;
                        //if (dataObject.Properties[property.ToString()].Type.ToString().Equals("String"))
                        //foreach (QualifierData q in property.Qualifiers) //Получаем описание
                        //{
                        //    if (q.Name.Equals("Description"))
                        //    {
                        //        LogBox.Items.Add((string)processClass.GetPropertyQualifierValue(property.Name, q.Name));
                        //    }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(someshitCounter + " shit happends; " + propertyCount + " prop found;");
            return result;
        }

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

        public void KillById(int processId)
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
        public static void Users()
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

        //-----------------------------SerializeShit--------------------------
        static byte[] GetBinaryFormatData(DataTable dt)
        {
            BinaryFormatter bFormat = new BinaryFormatter();
            byte[] outList = null;
            dt.RemotingFormat = SerializationFormat.Binary;
            using (MemoryStream ms = new MemoryStream())
            {
                bFormat.Serialize(ms, dt);
                outList = ms.ToArray();
            }
            return outList;
        }

        static DataTable GetDataTable(byte[] dtData)
        {
            DataTable dt = null;
            BinaryFormatter bFormat = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(dtData))
            {
                dt = (DataTable)bFormat.Deserialize(ms);
            }
            return dt;
        }
    }
}
