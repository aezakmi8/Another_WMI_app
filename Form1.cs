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



namespace Another_WMI_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tableLayoutPanel1.ColumnCount = 4;

        }

        private void AddClassesToList()
        {
            LogBox.Items.Add("Searching...");
            try
            {
                List<string> HardType = new List<string> { "Win32_Processor", "Win32_VideoController", "Win32_CDROMDrive", "Win32_DiskDrive" };
                int count = 0;
                foreach (string className in HardType)
                {
                        HardTreeinfo.Nodes.Add(className);
                        TreeNode obj = HardTreeinfo.Nodes[count];
                        Professional(AddPropertiesToList(className), ref obj);
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

        public void Professional(List<string> list, ref TreeNode node)
        {
            foreach (var i in list)
            {
                node.Nodes.Add(i);
            }
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
                            result.Add(dataObject.Name + " = " +  wmiObject.GetPropertyValue(dataObject.Name).ToString().Trim());
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

        private void button1_Click(object sender, EventArgs e)
        {
            //RemoteConnect.WMI_Conn();
            AddClassesToList();
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
                            Professional(AddPropertiesToList(className), ref obj); //первые 5
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

        private void ConstructWMIClassTree(System.Windows.Forms.TreeView item)
        {
            ManagementScope mgmtScope = new ManagementScope("root/cimv2");
            ManagementPath mgmtPath = new ManagementPath("__NAMESPACE");
            using (ManagementClass mgmtClass = new ManagementClass(mgmtScope, mgmtPath, null))
            {
                foreach (ManagementObject mgmtObject in mgmtClass.GetInstances())
                {
                    string name = (string)mgmtObject.Properties["Name"].Value;
                    LogBox.Items.Add((string)name);
                    if (!string.IsNullOrEmpty(name))
                    {
                        System.Windows.Forms.TreeView newTreeViewItem = new System.Windows.Forms.TreeView();
                        newTreeViewItem.Name = name;
                        LogBox.Items.Add((string)item.Tag);
                        StringBuilder sb = new StringBuilder(mgmtClass.Path.ToString());
                        sb.Replace(mgmtClass.Path.ClassName, string.Empty);
                        sb.Replace(":", string.Empty);
                        sb.Append(@"\");
                        sb.Append(name);
                        newTreeViewItem.Tag = sb.ToString();
                        //newTreeViewItem.AfterSelect += new RoutedEventHandler(WMIClassesItem_Selected);
                        LogBox.Items.Add(newTreeViewItem.Name);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddClassesToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myMethod();
        }

        private void classList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in Process.GetProcesses("."))
        }
    }
}
