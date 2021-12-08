using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarvelManager
{
    public class NentworkManager
    {
        public string GetJson(string url) => new WebClient().DownloadString(url);
    }
}
