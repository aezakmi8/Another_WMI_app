using System;
using System.Windows;
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
            this.LogBox.Text = "Searching...";
            try
            {
                //List<string> HardType = new List<string> { "Win32_Processor", "Win32_VideoController" };
                WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM meta_class WHERE __class LIKE 'Win32_%' ");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                int count = 0;
                foreach (ManagementObject wmiClass in searcher.Get())
                {
                    if (count == 74)
                    {
                        break;
                    }
                    string className = wmiClass.Path.ClassName;
                    HardTreeinfo.Nodes.Add(className);
                    //Get_WMI_Class(wmiClass.Path.ClassName, count);
                    //HardTreeinfo.Nodes[count].Nodes.Add(ListToNodeItem(GetWMIClass(wmiClass.Path.ClassName, count)));
                    //HardTreeinfo.Nodes[count].Nodes.AddRange(ListToNodeItem(GetWMIClass(wmiClass.Path.ClassName, count)));\ working
                    TreeNode obj = HardTreeinfo.Nodes[count];
                    Professional(GetWMIClass(wmiClass.Path.ClassName, count), ref obj);
                    // classList.Items.Add(wmiClass.Path.ClassName.Trim());  //первые 74
                    count++;
                }
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


        private List<string> GetWMIClass(string Win32_Process, int count)
        {
            List<string> result = new List<string>();
            // Get the WMI class
            ManagementClass processClass =
                new ManagementClass(Win32_Process);
            processClass.Options.UseAmendedQualifiers = true;
            // Get the properties in the class
            PropertyDataCollection properties =
                processClass.Properties;
            // display the properties
            try
            {
                    foreach (PropertyData property in properties)
                    {
                        //LogBox.Items.Add(property.Name);    //Получаем имена полей из классов
                        //HardTreeinfo.Nodes[count].Nodes.Add(property.Name);
                        //result.Add(property.Name.Trim() + obj[property.Name.Trim()].ToString().Trim());
                        result.Add(property.Name.Trim());
                        //foreach (QualifierData q in property.Qualifiers)
                        //{
                        //    if (q.Name.Equals("Description")) //Получаем описание
                        //    {
                        //        LogBox.Items.Add((string)processClass.GetPropertyQualifierValue(property.Name, q.Name));
                        //    }
                        //}
                    }
            }
            catch (Exception ex)
            {
                LogBox.Text = ex.Message;
            }
            return result;
        }

        private List <string> GetNodeItems (List<string> list)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + Win32_Process);
            foreach (ManagementObject obj in searcher.Get())
            {
                obj[list[i]].ToString().Trim();
                }
            return list;
        }

        private static object ClassItemField(ManagementObject ClassItem)
        {

            return ClassItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RemoteConnect.WMI_Conn();
            AddClassesToList();
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

        private void WMIClassesItem_Selected(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.TreeView item = (System.Windows.Forms.TreeView)sender;
            if (item.Nodes.Count == 0)
            {
                ConstructWMIClassTree(item);
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

        }

        private void LogBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

