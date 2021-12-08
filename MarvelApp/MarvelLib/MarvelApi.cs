using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelLib
{
    public class MarvelApi
    {
        NetworkManager networkManager;
        public MarvelApi()
        {
            networkManager = new NetworkManager();
        }
        public List<Charecter> GetCharecters()
        {
            long ts = MarvelApiConfig.TimeStamp;
            string apikey = MarvelApiConfig.PublicKey;
            string hash = MarvelApiConfig.Hash;

            string url = $"http://gateway.marvel.com/v1/public/characters?ts={ts}&apikey={apikey}&hash={hash}";

            string json = networkManager.GetJson(url);

            List<Charecter> characters = new List<Charecter>();
            JObject marvelinfoSearch = JObject.Parse(json);
            IList<JToken> results = marvelinfoSearch["data"]["results"].Children().ToList();
            foreach (JToken result in results)
            {
                characters.Add(new Charecter
                {
                    Name = result["name"].ToString(),
                    ImageUrl = $"{result["thumbnail"]["path"]}.{result["thumbnail"]["extension"]}"
                });
            }
            return characters;
        }
    }
}
