using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.IO;

using MarvelManager;

namespace MarvelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MarvelApi marvelApi = new MarvelApi();
            //foreach (var charecter in marvelApi.GetCharacters())
            //{
            //    Console.WriteLine($"{charecter.Name}\n{charecter.ImageUrl}\n{charecter.Id}");
            //    Console.WriteLine("----------------------------------");
            //}
            foreach (Comics comics in marvelApi.GetComics())
            {
                Console.WriteLine($"{comics.Title}\n{comics.ImageUrl}");
                Console.WriteLine("______________________________________________");
            }
           /* long TimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string PublicKey = "faa7133d07d230d487b3e3fefd9be924";
            string PrivateKey = "24afc92f9cd7d88f375c9c417f5c9e3c9c7eb281";
            string Hash =
            BitConverter.ToString(
                                     MD5
                                    .Create()
                                    .ComputeHash(Encoding.Default.GetBytes($"{TimeStamp}{PrivateKey}{PublicKey}"))
                                 )
                            .ToLower()
                            .Replace("-", "");

            string url = $"http://gateway.marvel.com/v1/public/characters?ts={TimeStamp}&apikey={PublicKey}&hash={Hash}&offset={1}&limit={20}";
            string json = new WebClient().DownloadString(url);
            Console.WriteLine(json);*/
            Console.ReadKey();
        }
    }
}
