using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuanLyDuLich_Library.Models
{
    [Serializable]
    public class Agency
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public int Amount { set; get; }
        public int Likes { set; get; }
        public List<Portion> Portions { set; get; }
        public Image Image { set; get; }
        public Agency(string name = "Hello", string Desc = "I'm Going To Victoria City Melbourne", int amount = 0, int like = 0, List<Portion> portions = null, Image image = null)
        {
            Name = name;
            Description = Desc;
            Amount = amount;
            Likes = like;
            Image = image;
            if(portions != null)
            {
                foreach(Portion p in Portions)
                {
                    p.Agency_Name = name;
                    like += p.Trip.Counter;
                }
            }
        }
    }
}
