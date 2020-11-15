using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Drawing.Imaging;


namespace QuanLyDuLich_Library.Models
{
    [Serializable]
//    location + price + additional service + accomodation + host(and his\her image) + image of trip + counter of likes.
    public class Trip
    {
        public string Location { set; get; }
        public decimal Price { set; get; }
        public string Addition_Service { set; get; }
        public string Accomodation { set; get; }
        public string Host { set; get; }
        public Image Image { set; get; }
        public Image ImageOf_Host { set; get; }
        public int Counter { set; get; }

        public Trip(string location = "Stuttgart", decimal price = 9000, string addition_service = "Rest At 5-Start Hotel", string accomodation = "Unknow", string host = "Unknow", Image image = null, Image imageof_host = null)
        {
            Location = location;
            Price = price;
            Addition_Service = addition_service;
            Accomodation = accomodation;
            Host = host;
            Image = image;
            ImageOf_Host = imageof_host;
            Counter = 0;
        }
    }
}
