using QuanLyDuLich_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Newest
{
    public partial class EditPortion : Form
    {
        public Portion Portion { get; set; }
        public EditPortion()
        {
            InitializeComponent();

            List<string> diadiem = new List<string>()
            {
                "Cairo", "Bangkok","New York","Budapest","London", "Paris",
                "Berlin", "Gdansk", "Talin", "Beijing", "Rio de Janeiro", 
                "Affins", "Larnaca", "Sharm El Sheikh", "Vienna", "Amsterdam",
                "Odessa", "St. Petersburg", "Moscow", "Lviv", "Sydney"
            };

            List<string> tinhtrang = new List<string>()
            {
                "On Sale" , "Hot Sale" , "Flash Sale In Day" , "Future Trip" , "Non Working" , "None"
            };


            //Them Danh Sach
            LocationTrip.Items.AddRange(diadiem);
            OnSaleFuture.Items.AddRange(tinhtrang);
            AmountOfTrip.Maximum = 30;
            AmountOfTrip.Minimum = 0;

            
        }

        public EditPortion(Portion port) : this()
        {
            Portion = port;
            AmountOfTrip.Value = port.Amount;
            LocationTrip.Text = port.Trip.Location;
            OnSaleFuture.Text = port.OnSale;
            PriceBox.Text = Convert.ToString(port.Trip.Price);
            ServiceBox.Text = port.Trip.Addition_Service;
            AccomodationBox.Text = port.Trip.Accomodation;
            HostBox.Text = port.Trip.Host;
            TripPicBox.Image = port.Trip.Image;
            

        }



        private void TripPicBox_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TripPicBox.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void EditPortion_TextChanged(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        private void HanSuDung(Control c , FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(c.Text) == true)
            {
                c.BackColor = Color.Red;
                e.Cancel = true;
            }
        }
        // This Action use when you click button on top right form
        private void EditPortion_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Do You Want Exit ???", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            switch (res)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    HanSuDung(LocationTrip, e);
                    HanSuDung(PriceBox, e);
                    HanSuDung(ServiceBox, e);
                    HanSuDung(AccomodationBox, e);
                    break;
                case DialogResult.OK:
                    Close();
                    break;
            }
        }
        // Container Check Error When some Blank is empty or This Blank just consist white space
        private void ValidateItems(Control c)
        {
            if (string.IsNullOrWhiteSpace(c.Text))
            {
                c.BackColor = Color.Red;
                MessageBox.Show("Sorry , Please Fill in the blank space ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c.Text = string.Empty;
                c.BackColor = Color.White;
            }
        }

        private void CheckBut_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (Portion == null)
            {
                Portion = new Portion();
            }
            if (LocationTrip.Text != "Location")
            {
                Portion.Trip.Location = LocationTrip.Text;
                Portion.Location_Trip = Portion.Trip.Location;
            }
            else
            {
                MessageBox.Show("Sorry, You Haven't Choose Any Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
            }
            int number;
            bool isInt = int.TryParse(PriceBox.Text, out number);
            if (isInt == true)
            {
                Portion.Trip.Price = Convert.ToInt32(PriceBox.Text);
                Portion.Price_Trip = Portion.Trip.Price;
            }
            else
            {
                PriceBox.BackColor = Color.Red;
                MessageBox.Show("Sorry, The Price Just consist of number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PriceBox.Text = string.Empty;
                PriceBox.BackColor = Color.White;
                flag = false;
            }

            ValidateItems(HostBox);
            if (HostBox.Text.Length < 3 || HostBox.Text.Length > 50)
            {
                HostBox.BackColor = Color.Red;
                MessageBox.Show("The length For Host don't suitable, \n it must should less than 50 and longer than 3 letter \n You can Type Unknow if don't what to type" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                HostBox.Text = string.Empty;
                HostBox.BackColor = Color.White;
                flag = false;
            }
            else
            {
                for (int i = 0; i < HostBox.Text.Length; i++)
                {
                    if (HostBox.Text[i] >= '0' && HostBox.Text[i] <= '9')
                    {
                        HostBox.BackColor = Color.Red;
                        MessageBox.Show("Host Include about 2 impact word and number \n Please Re-check it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        HostBox.Text = string.Empty;
                        HostBox.BackColor = Color.White;
                        flag = false;
                        break;
                    }
                }
            }
            Portion.Trip.Host = HostBox.Text;

            ValidateItems(ServiceBox);
            if (ServiceBox.Text.Length > 1000 || ServiceBox.Text.Length <= 0)
            {
                ServiceBox.BackColor = Color.Red;
                MessageBox.Show("The Length which you just type isn't reasonable \n Please re-check and re-type \n You can Type Unknow if don't what to type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ServiceBox.Text = string.Empty;
                ServiceBox.BackColor = Color.White;
                flag = false;

            }
            Portion.Trip.Addition_Service = ServiceBox.Text;

            ValidateItems(AccomodationBox);
            if (AccomodationBox.Text.Length > 20 || AccomodationBox.Text.Length < 10)
            {
                AccomodationBox.BackColor = Color.Red;
                MessageBox.Show("The Length which you just type isn't reasonable \n Please re-check and re-type You can Type Unknow if don't what to type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccomodationBox.Text = string.Empty;
                AccomodationBox.BackColor = Color.White;
                flag = false;
            }
            Portion.Trip.Accomodation = AccomodationBox.Text;
            Portion.Trip.Image = TripPicBox.Image;
            if(Portion.Trip.Image == null)
            {
                TripPicBox.BackColor = Color.Red;
                MessageBox.Show("You didn't choose any picture","Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                string filepath = @"D:\Lesson\RIT\C #\Winform\Newest\QuanLyDuLich\Moutain\191346.jpg";
                using (var wr = new StreamReader(filepath))
                {

                }
                TripPicBox.BackColor = Color.White;
                flag = false;
                
            }
            if(AmountOfTrip.Value == 0)
            {
                MessageBox.Show("Please Re-check Amount of trip \n it is zero now and it can't be sent client !!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Portion.OnSale = OnSaleFuture.Text;

            if(Portion.Amount == 0 || Portion.Location_Trip == null || Portion.Price_Trip == 0 || Portion.Trip.Image == null
                || Portion.Trip.ImageOf_Host == null || Portion.Trip.Location == "Unknow" || Portion.Trip.Price == 0 
                || Portion.Trip.Addition_Service == "Unknow" || Portion.Trip.Accomodation == "Unknow" || Portion.Trip.Host == "Unknow")
            {
                flag = false;
            }
            if(flag == true)
            {
                FinishBut.Show();
                CheckBut.Hide();
            }
            else
            {
                MessageBox.Show("Sorry You Are missing something in this form \n please check any blank you just fill in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FinishBut.Hide();
                CheckBut.Show();
            }
        

            
        }

        private void AmountOfTrip_ValueChanged(object sender, EventArgs e)
        {
            if(Portion == null)
            {
                Portion = new Portion();
            }
            if (AmountOfTrip.Value == 0)
            {
                MessageBox.Show("Please Re - check Amount of trip \n it is zero now and it can't be sent client !!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(AmountOfTrip.Value) == 40)
            {
                MessageBox.Show("40 Is a maximum Possible For Amount Of trip", "Anounce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Portion.Amount = (int)AmountOfTrip.Value;
            }
        }

        private void EditPortion_Load(object sender, EventArgs e)
        {
            FinishBut.Hide();
        }

        private void FinishBut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Successfully !!!!!!!" , "Success" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
    }
}
