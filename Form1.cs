using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Management;
using System.Management.Instrumentation;
using System.Diagnostics;
using System.Threading;



namespace Another_WMI_app
{
    public partial class Form1 : Form
    {
        [STAThread]
        static public void Main() //main
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(FilldtSourse.Users);
            await Task.Run(FilldtSourse.InstalldApps);
            await Task.Run(FilldtSourse.Proc);
            ApplydtSourse();

            //UsersList.Items.AddRange(AppFilldtSourse.UsersList.ToArray());
        }

        private void ApplydtSourse()
        {
            //HardTab
            HardGrid.DataSource = null;
            HardGrid.DataSource = FilldtSourse.UsersdtSource;
            //ProcTab
            ProcGrid.DataSource = null;
            ProcGrid.DataSource = FilldtSourse.ProcdtSource;
            //AppTab
            InstalldAppsGrid.DataSource = null;
            InstalldAppsGrid.DataSource = FilldtSourse.InsAppsdtSource;
        }

        private void myMethod() //not used
        {
            int propertyCount = 0;
            int someshitCounter = 0;
            try
            {
                ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + "Win32_VideoController");
                ManagementClass mc = new ManagementClass("root\\CIMV2", "Win32_VideoController", op);
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
                            LogBox.Items.Add(dataObject.Name + " = " + wmiObject.GetPropertyValue(dataObject.Name).ToString());
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
                LogBox.Items.Add(propertyCount);
            }
            catch (Exception ex)
            {
                LogBox.Items.Add(ex.Message);
            }
        }

        private void GetAllWMIClasses() //not used
        {
            {
                LogBox.Items.Add("Searching...");
                try
                {
                    WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM meta_class WHERE __class LIKE 'Win32_%' ");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                    int count = 0;
                    foreach (ManagementObject wmiClass in searcher.Get())
                    {
                        if (count == 5)
                        {
                            break;
                        }
                        string className = wmiClass.Path.ClassName;
                        HardTreeinfo.Nodes.Add(className);
                        TreeNode obj = HardTreeinfo.Nodes[count];
                        //Professional(AddPropertiesToList(className), ref obj); //первые 5
                        count++;
                    }
                    LogBox.Items.Add(count + " classes found.");
                }
                catch (Exception ex)
                {
                    LogBox.Items.Add(ex.Message);
                }
            }
        }

        private async void KillProc_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = ProcGrid.CurrentCell.RowIndex;
                String CellValue = ProcGrid.Rows[rowindex].Cells[1].Value.ToString();
                foreach (DataGridViewRow row in ProcGrid.SelectedRows)
                {
                    ProcGrid.Rows[row.Index + 1].Selected = true;
                    ProcGrid.Rows.Remove(row);
                }
                FilldtSourse filldt = new FilldtSourse();
                filldt.KillById(Convert.ToInt32(CellValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HardGrid_DoubleClick(object sender, EventArgs e)
        {
            ApplydtSourse();
        }
 
        private void RunServ_Click(object sender, EventArgs e)
        {
            ServerObject server = new ServerObject(); // сервер
            Thread listenThread; // поток для прослушивания
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            ClientObject.server.BroadcastMessage("daijobu", ClientObject.ip);
        }

        private async void HardInfo_btn_Click(object sender, EventArgs e)
        {
            List<string> hardType = new List<string> { "Win32_Processor", "Win32_VideoController", "Win32_CDROMDrive", "Win32_DiskDrive" };
            //RemoteConnect.WMI_Conn();
            Console.WriteLine("Searching...");
            FilldtSourse filldt = new FilldtSourse();
            try
            {
                int count = 0;
                foreach (string className in hardType)
                {
                    HardTreeinfo.Nodes.Add(className);
                    TreeNode obj = HardTreeinfo.Nodes[count];
                    var prop = await filldt.AddPropToList(className);
                    Professional(prop, ref obj);
                    count++;
                }
                HardTreeinfo.ExpandAll();
                Console.WriteLine(count + " classes found.");
            }
            catch (Exception ex)
            {
                LogBox.Items.Add(ex.Message);
            }
        }

        public void Professional(List<string> list, ref TreeNode node)
        {
            foreach (var i in list)
            {
                node.Nodes.Add(i);
            }
        }
    }
}
