using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLich_Library.Models
{
    [Serializable]
    public class Portion
    {
        public Trip Trip { set; get; }
        public int Amount { set; get; }
        public string OnSale { set; get; }
        public string Agency_Name { set; get; }
        public string Location_Trip { set; get; }
        public decimal Price_Trip { set; get; }

        //Contructor

        public Portion(Trip trip = null , int amout = 0 , string onsale = "None")
        {
            Trip = trip == null ? new Trip() : trip;
            Amount = amout;
            OnSale = onsale;
            if(trip != null)
            {
                Location_Trip = trip.Location;
                Price_Trip = trip.Price;
            }
        }
    }
}
