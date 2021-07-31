namespace ApolonSpaceXLoader
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    class SConsole
    {
        public static bool CVoid(string Command)
        {
            try
            {
                Process.Start("cmd.exe", PathReplacer(Command));
                return true;
            }
            catch { return false; }            
        }

        private static string PathReplacer(string Str)
        {
            try
            {
                string result = string.Empty;
                switch (Str)
                {
                    case "{AppData}":
                        result = Str.Replace("{AppData}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                        break;
                    case "{UserProfile}":
                        result = Str.Replace("{UserProfile}", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                        break;
                    case "{Documents}":
                        result = Str.Replace("{Documents}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                        break;
                    case "{ProgramFiles}":
                        result = Str.Replace("{ProgramFiles}", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
                        break;
                    case "{Startup}":
                        result = Str.Replace("{Startup}", Environment.GetFolderPath(Environment.SpecialFolder.Startup));
                        break;

                        default: result = Str; break;
                }
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
