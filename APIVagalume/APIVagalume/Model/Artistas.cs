using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIVagalume.Model
{

    public class Rank
    {
        public string pos { get; set; }
        public int period { get; set; }
        public string views { get; set; }
        public string uniques { get; set; }
        public string points { get; set; }
    }

    public class Related
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
    }

    public class Toplyrics
    {
        public List<Item> item { get; set; }
    }

    public class Item2
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public string turl { get; set; }
    }

    public class Lyrics
    {
        public List<Item2> item { get; set; }
    }

    public class Item3
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public string year { get; set; }
        public string label { get; set; }

        public string Ano
        {
            get { return "Ano: " + year; }
        }

        public string Gravadora
        {
            get { return "Gravadora: " + label; }
        }


    }

    public class Albums
    {
        public List<Item3> item { get; set; }
    }

    public class artist
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public string pic_small { get; set; }
        public string pic_medium { get; set; }
        public Rank rank { get; set; }
        public List<Related> related { get; set; }
        public Toplyrics toplyrics { get; set; }
        public Lyrics lyrics { get; set; }
        public Albums albums { get; set; }
    }

    public class RootObject
    {
        public artist artist { get; set; }
    }
}
