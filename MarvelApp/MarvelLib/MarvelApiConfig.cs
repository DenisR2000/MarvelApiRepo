using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MarvelLib
{
    public class MarvelApiConfig
    {
        public static long TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public static string PublicKey => "faa7133d07d230d487b3e3fefd9be924";
        public static string PrivateKey => "24afc92f9cd7d88f375c9c417f5c9e3c9c7eb281";

        //MD5 cryptor = MD5.Create();
        //string stringToHash = $"{ts}{privatKey}{publicKey}";
        //byte[] bytes = cryptor.ComputeHash(Encoding.Default.GetBytes(stringToHash));
        //public static string hash = BitConverter.ToString(bytes).ToLower().Replace("-", "");

        public static string Hash => BitConverter.ToString(
                                                                MD5
                                                               .Create()
                                                               .ComputeHash(Encoding.Default.GetBytes($"{TimeStamp}{PrivateKey}{PublicKey}"))
                                                           )
                                                       .ToLower()
                                                       .Replace("-", ""); // свойство для хеширования

    }
}
