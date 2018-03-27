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



namespace Another_WMI_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            int propertyCount = 0;
            LogBox.Text = "Searching...";
            try
            {
                // Gets the property qualifiers.
                ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
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
                        else
                       // Property is not an array.
                       if (wmiObject.Properties[dataObject.Name].Type.ToString().Equals(null))
                        {

                        }
                        else
                       if (wmiObject.Properties[dataObject.Name].Type.ToString().Equals("String"))
                        {
                            result.Add(dataObject.Name + " = " +  wmiObject.GetPropertyValue(dataObject.Name).ToString().Trim());
                        }
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
            LogBox.Items.Add(propertyCount + " prop found.");
            return result;
        }

        private void myMethod()
        {
            int propertyCount = 0;
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
                        else
                        // Property is not an array.
                        if (wmiObject.Properties[dataObject.Name].Type.ToString().Equals(null))
                        {
                            // property is not a string.
                            // Do nothing.
                            //LogBox.Items.Add(wmiObject.GetPropertyValue(dataObject.Name).ToString());
                        }
                        else
                        //
                        if (wmiObject.Properties[dataObject.Name].Type.ToString().Equals("String"))
                        {
                            LogBox.Items.Add(wmiObject.GetPropertyValue(dataObject.Name).ToString() + "*");
                        }
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

        //private List<string> AddValuesToList(string Win32_Process)
        //{
        //    List<string> result = new List<string>();
        //    int valueCount = 0;
        //    LogBox.Text = "Searching...";
        //    try
        //    {
        //        // Performs WMI object query on the
        //        // selected class.
        //        string query = "select * from " + Win32_Process;
        //        ManagementObjectSearcher searcher =
        //            new ManagementObjectSearcher(query);
        //       //     new ManagementScope(NamespaceValue.Text), new WqlObjectQuery(query), null);
        //        foreach (ManagementObject wmiObject in
        //            searcher.Get())
        //        {
        //            foreach (object property in this.Property.SelectedItems)
        //            {
        //                if (wmiObject.Properties[property.ToString()].IsArray)
        //                {
        //                    // Do nothing.
        //                }
        //                else
        //                {
        //                    // Set buffer string used to separate instances in the list.
        //                    if (instanceCounter)
        //                    {
        //                        buffer = "";
        //                    }
        //                    else
        //                    {
        //                        buffer = "          ";
        //                    }

        //                    // Property is not an array.
        //                    if (wmiObject.Properties[property.ToString()].Type.ToString().Equals("String"))
        //                    {
        //                        // Property is a string.
        //                        this.ValueList.Items.Add(buffer + property.ToString() + " = '" +
        //                            wmiObject.GetPropertyValue(
        //                            property.ToString()) + "'");

        //                        valueCount++;
        //                    }
        //                    else
        //                    {
        //                        // Property is not a string.
        //                        this.ValueList.Items.Add(buffer + property.ToString() + " = " +
        //                            wmiObject.GetPropertyValue(
        //                            property.ToString()));
        //                        valueCount++;
        //                    }
        //                }
        //            }

        //            if (instanceCounter)
        //            {
        //                instanceCounter = false;
        //            }
        //            else
        //            {
        //                instanceCounter = true;
        //            }
        //        }
        //        this.ValueStatus.Text =
        //            valueCount + " values found. Properties with an array data type are not listed (can't be used in a query).";
        //    }
        //    catch (ManagementException ex)
        //    {
        //        this.ValueStatus.Text = ex.Message;
        //    }
        //}

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddClassesToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myMethod();
        }

        private void LogBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
