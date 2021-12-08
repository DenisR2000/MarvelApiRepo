using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace MarvelManager
{
    public class Character
    {
        public Character()
        {
        }
        public Character(int id, string Name)
        {
            this.Id = id;
            this.Name = Name;

        }
        public Character(int id, string Name, string ImageUrl)
        {
            this.Id = id;
            this.Name = Name;
            this.ImageUrl = ImageUrl;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
