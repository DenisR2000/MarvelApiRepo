using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MarvelLib
{
    public class NetworkManager
    {
        public string GetJson(string url) => new WebClient().DownloadString(url);
    }
}
