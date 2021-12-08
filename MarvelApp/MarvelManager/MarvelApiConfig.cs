using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarvelManager
{
    public class MarvelApiConfig
    {
        public static long TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public static string PublicKey => "faa7133d07d230d487b3e3fefd9be924";
        public static string PrivateKey => "24afc92f9cd7d88f375c9c417f5c9e3c9c7eb281";
        public static string Hash =>
            BitConverter.ToString(
                                     MD5
                                    .Create()
                                    .ComputeHash(Encoding.Default.GetBytes($"{TimeStamp}{PrivateKey}{PublicKey}"))
                                 )
                            .ToLower()
                            .Replace("-", "");
    }
}
