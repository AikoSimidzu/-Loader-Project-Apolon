namespace ApolonSpaceXLoader
{
    using System;
    using System.Management;
    using System.Security.Cryptography;

    class Helper
    {
        public static string HWID()
        {
            string str = string.Empty;
            try
            {
                string str2 = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
                using (ManagementObject obj1 = new ManagementObject("win32_logicaldisk.deviceid=\"" + str2 + ":\""))
                {
                    obj1.Get();
                    str = obj1["VolumeSerialNumber"]?.ToString();
                }
            }
            catch{}
            return str;
        }

        public static string GetOSInformation()
        {
            foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get())
            {
                ManagementObject managementObject = (ManagementObject)managementBaseObject;
                try
                {
                    return string.Concat(new string[]
                    {
                    (string)managementObject["Version"]
                    });
                }
                catch{}
            }
            return "BIOS Maker: Unknown";
        }

        public static string AV()
        {
            var searcher = new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            string gn = string.Empty;
            foreach (ManagementObject queryObj in searcher.Get())
            {
                string displayName = (string)queryObj["displayName"];
                gn += ($"{displayName}, ");
            }
            return gn;
        }

        // https://ipconfig.ws/threads/%D0%9A%D0%BB%D0%B0%D1%81%D1%81-%D0%B4%D0%BB%D1%8F-%D0%B3%D0%B5%D0%BD%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8-%D1%80%D0%B0%D0%BD%D0%B4%D0%BE%D0%BC%D0%BD%D1%8B%D1%85-%D1%81%D1%82%D1%80%D0%BE%D0%BA.53/
        public static string RandomID(int length)
        {
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                identifier[idx] = AvailableCharacters[randomData[idx] % AvailableCharacters.Length];
            }

            return new string(identifier);
        }

        private static readonly char[] AvailableCharacters =
        {
           'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
           'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
           'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
           'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
           '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
        };
    }
}
