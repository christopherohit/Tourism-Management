using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using QuanLyDuLich_Library.DAL;



namespace QuanLyDuLich_Library.Models
{
    [Serializable]
    public class VietTravel
    {

        public List<Agency> Agencies { private set; get; }
        public List<Client> Clients { private set; get; }
        public List<Admin> Admins { private set; get; }
        public List<Order> Orders { private set; get; }

        public VietTravel()
        {
            Agencies = new List<Agency>();
            Clients = new List<Client>();
            Admins = new List<Admin>();
            Orders = new List<Order>();
        }

        public bool Hendrichs;
        public void Kiem_Thu(int n)
        {
            Agencies = new List<Agency>();
            var non = new Bitmap(Path.GetFullPath("Beau.jpg"));
            for(int i = 0; i < n; i++)
            {
                List<Trip> Trips = new List<Trip>();
                for(int j = 0; j < 5; j++)
                {
                    Trips.Add(new Trip()
                    {
                        Location = $"{i}",
                        Price = i,
                        Addition_Service = $"{i}",
                        Accomodation = $"{i}",
                        Host = $"{i}",
                    });
                }

                var ps = new List<Portion>();
                for(int m = 0; m < 5; m++)
                {
                    ps.Add(new Portion { Trip = Trips[(m)], Amount = m, OnSale = "On Sale" });
                }

                Agencies.Add(new Agency($"Name {i}", "Good", 0, i, ps, non));

            }

            Clients = new List<Client>();
            for(int i = 1; i <= n; i++)
            {
                Clients.Add(new Client($"Client{i}", 123, "E-Mails"));
            }

            Orders = new List<Order>();
            for(int i = 0; i <n; i++)
            {
                List<Trip> Trips = new List<Trip>();
                for(int j = 0; j < 5; j++)
                {
                    Trips.Add(new Trip()
                    {
                        Location = $"Location {i}",
                        Price = i,
                        Addition_Service = $"{i}",
                        Accomodation = $"{i}",
                        Host = $"{i}",
                    });

                    var ps = new List<Portion>();
                    for (int q = 0; q < 5; q++)
                    {
                        ps.Add(new Portion { Trip = Trips[(q)], Amount = q });
                    }
                    Orders.Add(new Order(ps, Clients[i], DateTime.Now + TimeSpan.FromDays(i)));
                }
            }
        }
        public void Add_Agency(Agency agency)
        {
            Agencies.Add(agency);
        }
        public void Save()
        {
            new Dao(this).Save();
            Hendrichs = false;
        }

        public void Load()
        {
            new Dao(this).Load();
            Hendrichs = false;
        }
    }
}
