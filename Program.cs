using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Management;

namespace Another_WMI_app
{
    public class RemoteConnect
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void WMI_Conn()
        {
            // Build an options object for the remote connection
            // if you plan to connect to the remote
            // computer with a different user name
            // and password than the one you are currently using.
            // This example uses the default values. 


            ConnectionOptions options = new ConnectionOptions();
            options.Username = null;
            options.Password = "";
            options.EnablePrivileges = true;
            // Make a connection to a remote computer.
            // Replace the "FullComputerName" section of the
            // string "\\\\FullComputerName\\root\\cimv2" with
            // the full computer name or IP address of the
            // remote computer.

            ManagementScope scope =
                    new ManagementScope("\\\\192.168.1.1\\root\\cimv2", options);
            scope.Connect();

            if (!scope.IsConnected)
                MessageBox.Show("Scope connected");

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery(
                "SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                // Display the remote computer information
                Console.WriteLine("Computer Name : {0}",
                    m["csname"]);
                Console.WriteLine("Windows Directory : {0}",
                    m["WindowsDirectory"]);
                Console.WriteLine("Operating System: {0}",
                    m["Caption"]);
                Console.WriteLine("Version: {0}", m["Version"]);
                Console.WriteLine("Manufacturer : {0}",
                    m["Manufacturer"]);
            }
        }
    }
}
