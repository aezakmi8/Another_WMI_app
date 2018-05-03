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
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await ApplydtSourse();
            await Task.Run(FilldtSourse.Users);
            await Task.Run(FilldtSourse.InstalldApps);
            //UsersList.Items.AddRange(AppFilldtSourse.UsersList.ToArray());
        }

        private async Task ApplydtSourse()
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

        private async Task AddClassesToList()
        {
            LogBox.Items.Add("Searching...");
            try
            {
                List<string> HardType = new List<string> { "Win32_Processor", "Win32_VideoController", "Win32_CDROMDrive", "Win32_DiskDrive" };
                int count = 0;
                foreach (string className in HardType)
                {
                    var prop = AddPropertiesToList(className);
                    var node = await TreeNodeAddRange(prop, className);
                    ///HardTreeinfo.Nodes.Add(className);
                    //TreeNode obj = HardTreeinfo.Nodes[count];
                    HardTreeinfo.Nodes.Add(node);
                    //Professional(AddPropertiesToList(className), ref obj);
                    count++;
                }
                HardTreeinfo.ExpandAll();
                LogBox.Items.Add(count + " classes found.");
            }
            catch (Exception ex)
            {
                LogBox.Items.Add(ex.Message);
            }
        }

        public async Task<TreeNode> TreeNodeAddRange(List<string> list, string className)
        {
                //TreeNode[] tree = new TreeNode[] { new TreeNode(i)};
                TreeNode tree = new TreeNode(className);
                foreach (var i in list)
                {
                    tree.Nodes.Add(i);
                }
                return tree;
        }

        public List<string> AddPropertiesToList(string Win32_Process)
        {
            List<string> result = new List<string>();
            int someshitCounter = 0;
            int propertyCount = 0;
            LogBox.Text = "Searching...";
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
                LogBox.Items.Add(ex.Message);
            }
            LogBox.Items.Add(someshitCounter + " shit happends.");
            LogBox.Items.Add(propertyCount + " prop found.");
            return result;
        }

        private void myMethod()
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

        private async void button1_Click(object sender, EventArgs e)
        {
            //RemoteConnect.WMI_Conn();
            await AddClassesToList();
        }

        private void GetAllWMIClasses()
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
                await FilldtSourse.KillById(Convert.ToInt32(CellValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void HardGrid_DoubleClick(object sender, EventArgs e)
        {
            ApplydtSourse();
        }
    }
}
