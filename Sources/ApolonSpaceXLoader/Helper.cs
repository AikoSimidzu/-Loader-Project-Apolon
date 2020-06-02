using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace ApolonSpaceXLoader
{
    class Helper
    {
        public static string HWID()
        {
            string str = string.Empty;
            {
                try
                {
                    string str2 = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
                    ManagementObject obj1 = new ManagementObject("win32_logicaldisk.deviceid=\"" + str2 + ":\"");
                    obj1.Get();
                    str = obj1["VolumeSerialNumber"].ToString();
                }
                catch (Exception)
                {
                }
            }
            return str;
        }

        public static string GetOSInformation()
        {
            foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get())
            {
                ManagementObject managementObject = (ManagementObject)managementBaseObject;
                try
                {
                    return string.Concat(new string[]
                    {
                    (string)managementObject["Version"]
                    });
                }
                catch
                {
                }
            }
            return "BIOS Maker: Unknown";
        }

        public static string AV()
        {
            var searcher = new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            string gn = string.Empty;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                string displayName = (string)queryObj["displayName"];
                gn += ($"{displayName}, ");
            }
            return gn;
        }

        public static string RandomID()
        {
            string Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(6);
            int Position = 0;

            for (int i = 0; i < 7; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }
    }
}
