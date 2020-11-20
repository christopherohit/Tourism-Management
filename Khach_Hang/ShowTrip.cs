using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDuLich_Library.Models;

namespace Khach_Hang
{
    public partial class ShowTrip : Form
    {
        Portion GetPortion;
        Client GetClient;
        VietTravel GetVietTravel;
        Order GetOrder;

        public bool KiemTraDaDat;
        public ShowTrip(Portion portion , Client client , VietTravel vietTravel)
        {
            InitializeComponent();
            GetPortion = portion;
            GetVietTravel = vietTravel;
            GetClient = client;
            GetPortion = new Portion();
            SoLuong.Maximum = GetPortion.Amount;
            SoLuong.Minimum = 0;
            DanhGia.Text = Convert.ToString(GetPortion.Trip.Counter);
        }

        private void ShowTrip_Load(object sender, EventArgs e)
        {
            GetVietTravel.Save();
            DiaDiem.Text = GetPortion.Trip.Location;
            GiaBox.Text = Convert.ToString(GetPortion.Trip.Price);
            AddBox.Text = GetPortion.Trip.Addition_Service;
            AccBox.Text = GetPortion.Trip.Accomodation;
            HostBox.Text = GetPortion.Trip.Host;
            heartUnlike.Hide();
        }

        private void ShowTrip_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Do you want to exit this program ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.OK:
                    Application.Exit();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;

                    break;
            }
        }

        private void hearLike_Click(object sender, EventArgs e)
        {
            DanhGia.Text = Convert.ToString(GetPortion.Trip.Counter);
            GetPortion.Trip.Counter++;

            hearLike.Hide();
            heartUnlike.Show();
            DanhGia.Text = Convert.ToString(GetPortion.Trip.Counter);
            bool breaky = false;
            foreach (Agency a in GetVietTravel.Agencies)
            {
                foreach(Portion p in a.Portions)
                {
                    if (p.Agency_Name == GetPortion.Agency_Name && p.Trip.Location == GetPortion.Trip.Location && p.Trip.Price == GetPortion.Trip.Price || p.Amount == GetPortion.Amount)
                    {
                        a.Likes++;
                        if (p.Agency_Name == GetPortion.Agency_Name && p.Trip.Location == GetPortion.Trip.Location && p.Trip.Price == GetPortion.Trip.Price || p.Amount == GetPortion.Amount)
                        {
                            p.Trip.Counter = GetPortion.Trip.Counter;
                        }
                        breaky = true;
                        break;
                    }
                }
                if (breaky == true)
                {
                    break;
                }
            }
            GetVietTravel.Save();
        }

        private void heartUnlike_Click(object sender, EventArgs e)
        {
            DanhGia.Text = Convert.ToString(GetPortion.Trip.Counter);
            GetPortion.Trip.Counter -= 1;
            heartUnlike.Hide();
            hearLike.Show();
            DanhGia.Text = Convert.ToString(GetPortion.Trip.Counter);
            bool breaky1 = false;
            foreach(Agency a in GetVietTravel.Agencies)
            {
                foreach(Portion p in a.Portions)
                {
                    if (p.Agency_Name == GetPortion.Agency_Name && p.Trip.Location == GetPortion.Trip.Location && p.Trip.Price == GetPortion.Trip.Price || p.Amount == GetPortion.Amount)
                    {
                        a.Likes--;
                        if( p.Agency_Name == GetPortion.Agency_Name && p.Trip.Location == GetPortion.Trip.Location && p.Trip.Price == GetPortion.Trip.Price || p.Amount == GetPortion.Amount)
                        {
                            p.Trip.Counter = GetPortion.Trip.Counter;
                        }
                        breaky1 = true;
                        break;
                    }
                }
                if(breaky1 == true)
                {
                    break;
                }

            }
            GetVietTravel.Save();
        }

        private void SoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SoLuong.Value) >= 1)
            {
                KiemTraDaDat = true;
            }
            else if ( Convert.ToInt32(SoLuong.Value) == GetPortion.Amount)
            {
                MessageBox.Show("The Maximum of Amount of the trip is " + GetPortion.Amount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                KiemTraDaDat = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTraDaDat == true)
            {
                bool chapnhan = true;
                foreach( Order o in GetVietTravel.Orders)
                {
                    if (o.ClientName == GetClient.Name)
                    {
                        if (o.IsOrdered == true)
                        {
                            MessageBox.Show("Please wait before Admin accept your order \n And after that you can choose another trip \n Sorry for the late you can contact to Service provider to get help ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chapnhan = false;
                            break;
                        }
                    }
                }
                if(chapnhan == true)
                {
                    List<Portion> portions = new List<Portion>();

                    Portion chance = new Portion(GetPortion.Trip, (int)SoLuong.Value, GetPortion.OnSale);
                    chance.Agency_Name = GetPortion.Agency_Name;
                    chance.Location_Trip = GetPortion.Location_Trip;
                    chance.Price_Trip = GetPortion.Price_Trip;

                    portions.Add(chance);
                    foreach(Portion p in portions)
                    {
                        p.Agency_Name = GetPortion.Agency_Name;
                    }

                    bool huy = false;
                    if (GetVietTravel.Orders.Count > 0)
                    {
                        for (int i = 0; i < GetVietTravel.Orders.Count; i++)
                        {
                            if (GetVietTravel.Orders[i].Client.Name == GetClient.Name)
                            {
                                for (int j = 0; i < GetVietTravel.Orders[i].Portions.Count; j++)
                                {
                                    if (GetVietTravel.Orders[i].Portions[j].Agency_Name == chance.Agency_Name &&
                                        GetVietTravel.Orders[i].Portions[j].Trip.Location == chance.Trip.Location &&
                                        GetVietTravel.Orders[i].Portions[j].Trip.Price == chance.Trip.Price)
                                    {
                                        GetVietTravel.Orders[i].Portions[j].Amount += chance.Amount;
                                        huy = true;
                                        break;
                                    }
                                    else if ( j + 1  == GetVietTravel.Orders[i].Portions.Count)
                                    {
                                        GetVietTravel.Orders[i].Portions.Add(chance);
                                        huy = true;
                                        break;
                                    }
                                }
                            }

                            if (huy == true)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        GetOrder = new Order(portions, GetClient);
                        GetVietTravel.Orders.Add(GetOrder);
                    }

                    MessageBox.Show($"Congratulation, You Successfully for the ordered this trip {SoLuong.Value} :) \n We wish you have a good time with your choice \n Thanks for choose us", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (GetPortion.Amount == 0)
                    {
                        foreach (Agency a in GetVietTravel.Agencies)
                        {
                            if (a.Name == GetPortion.Agency_Name)
                            {
                                foreach (Portion p in a.Portions)
                                {
                                    if (p.Location_Trip == GetPortion.Location_Trip && p.OnSale == GetPortion.OnSale && p.Price_Trip == GetPortion.Price_Trip && p.Trip.Host == GetPortion.Trip.Host)
                                    {
                                        a.Portions.Remove(p);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        GetPortion.Amount = GetPortion.Amount - Convert.ToInt32(SoLuong.Value);
                    }

                    foreach(Agency a in GetVietTravel.Agencies)
                    {
                        if ( a.Name == GetPortion.Agency_Name)
                        {
                            foreach (Portion p in a.Portions)
                            {
                                if (p.Location_Trip == GetPortion.Location_Trip && p.OnSale == GetPortion.OnSale && p.Price_Trip == GetPortion.Price_Trip && p.Trip.Host == GetPortion.Trip.Host)
                                {
                                    p.Amount = GetPortion.Amount;
                                }
                            }
                        }
                    }
                    GetVietTravel.Save();

                    if (DialogResult != DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, Please pick anyone trip \n Let's Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
