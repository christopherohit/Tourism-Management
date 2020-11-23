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
    public partial class MainClient : Form
    {
        VietTravel GetVietTravel;
        List<Portion> port = new List<Portion>();
        List<Agency> GetAgencies = new List<Agency>();
        List<Portion> GetPortions = new List<Portion>();
        Client GetClient;
        Order GetOrder;
        decimal cost;
        public MainClient(VietTravel vietTravel , Client client)
        {
            GetVietTravel = vietTravel;
            GetClient = client;
            cost = 0;
            List<string> vung = new List<string>
            {
                "Cairo", "Bangkok","New York","Budapest","London", "Paris",
                "Berlin", "Gdansk", "Talin", "Beijing", "Rio de Janeiro",
                "Affins", "Larnaca", "Sharm El Sheikh", "Vienna", "Amsterdam",
                "Odessa", "St. Petersburg", "Moscow", "Lviv", "Sydney","Kyoto" ,"Seol",
                "Vernice", "Coron","Mauritius" , "Mandalay" ,"Isetwald" ,"Sigriswil Urban",
                "Grindelwald" , "Obwalden" , "Zurich" , "Jeju Island" , "Zanzibar" , "Labadee",
                "Mozambique","Cusco" , "Oku Mountain" , "Kilimanjaro" , "Fatucama Peninsula" ,
                "Inhambane" , "Misti Volcano" , "Bazaruto Island" , "Titicaca Lake" ,"Serengeti",
                "Petrovaradin" , "Maputo Church" , "Kalemegdan","Skadarlija" , "Maria Cathedral"
            };
            InitializeComponent();
            LocationsForClient.Items.Add(vung);

            foreach(Agency a in GetVietTravel.Agencies)
            {
                foreach ( Portion p in a.Portions)
                {
                    if(p.Amount > 0)
                    {
                        GetPortions.Add(p);
                    }
                }
            }
            foreach (Agency a in GetVietTravel.Agencies)
            {
                if (a.Portions.Count > 0)
                {
                    GetAgencies.Add(a);
                }
            }
            
        }
       
        private void Undo_Butt_Click(object sender, EventArgs e)
        {
            NameForSearch.Text = string.Empty;
            agencyBindingSource.DataSource = GetVietTravel.Agencies;
            agencyBindingSource.ResetBindings(false);
        }

        private void Question_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Hello \n You can Search any your favourite agency just by filling in its name (only letters) \nRate hearts will rate agencies by popularity(likes)\nUndo to start again");
        }

        private void Unrate_Click(object sender, EventArgs e)
        {
            Agency temp;
            for (int i = 0; i < GetAgencies.Count - 1; i++)
            {
                for (int j = i + 1; j <GetAgencies.Count; j++)
                {
                    if (GetAgencies[i].Likes < GetAgencies[j].Likes && GetAgencies[i].Portions.Count > 0 && GetAgencies[j].Portions.Count > 0)
                    {
                        temp = GetAgencies[i];
                        GetAgencies[i] = GetAgencies[j];
                        GetAgencies[j] = temp;
                    }
                }
            }

            agencyBindingSource.DataSource = GetAgencies;
            agencyBindingSource.ResetBindings(false);
        }

        private void Rate_Click(object sender, EventArgs e)
        {

        }

        private void MainClient_Load(object sender, EventArgs e)
        {
            GetVietTravel.Load();

            agencyBindingSource.ResetBindings(false);
            portionBindingSource.ResetBindings(false);
            portionBindingSource1.ResetBindings(false);
            if (OrderGrid.Rows.Count > 0)
            {
                OrderGrid.Rows[0].Selected = true;
            }
            if(TripClientGridView.Rows.Count > 0)
            {
                TripClientGridView.Rows[0].Selected = true;
            }
            if (AgencyView.Rows.Count > 0)
            {
                AgencyView.Rows[0].Selected = true;
            }

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void NameForSearch_TextChanged(object sender, EventArgs e)
        {
            if (NameForSearch.Text.Length >= 30)
            {
                NameForSearch.BackColor = Color.Red;
                MessageBox.Show("The name you just fill in too long \n Please try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameForSearch.Text = string.Empty;
                NameForSearch.BackColor = Color.White;
            }
            else
            {
                for (int i = 0; i < NameForSearch.Text.Length; i++)
                {
                    if (NameForSearch.Text[i] >= '0' && NameForSearch.Text[i] <= '9')
                    {
                        NameForSearch.BackColor = Color.Red;
                        MessageBox.Show("The Name Just Contains Number ??? ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NameForSearch.Text = string.Empty;
                        NameForSearch.BackColor = Color.White;
                        break;
                    }
                }
            }

            string str = NameForSearch.Text;
            GetAgencies = new List<Agency>();
            foreach (Agency a in GetVietTravel.Agencies)
            {
                if (a.Name.IndexOf(str) > -1 && a.Portions.Count > 0)
                {
                    // Already exist
                    GetAgencies.Add(a);
                }
                else
                {
                    // never exist before
                    MessageBox.Show("Oh No We can't find any thing from here \nPlease Re-check it and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            agencyBindingSource.DataSource = GetAgencies;
            if (GetAgencies.Count == 0)
            {
                MessageBox.Show("Sorry,there is no agency with such a name");
            }
            agencyBindingSource.ResetBindings(false);
        }

        private void LessPrice_Click(object sender, EventArgs e)
        {
            // Sort
            Portion temp; 
            for(int i =0; i <GetPortions.Count - 1; i++)
            {
                for ( int j = i + 1; j <GetPortions.Count; j++)
                {
                    if (GetPortions[i].Trip.Price > GetPortions[j].Trip.Price)
                    {
                        temp = GetPortions[i];
                        GetPortions[i] = GetPortions[j];
                        GetPortions[j] = temp;
                    }
                }
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);
        }

        private void BiggerPrice_Click(object sender, EventArgs e)
        {
            Portion temp;
            for (int i = 0; i < GetPortions.Count - 1; i++)
            {
                for (int j = i+1;j < GetPortions.Count; j++)
                {
                    if (GetPortions[i].Trip.Price < GetPortions[j].Trip.Price)
                    {
                        temp = GetPortions[i];
                        GetPortions[i] = GetPortions[j];
                        GetPortions[j] = temp;  
                    }
                }
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);
        }

        private void More_Butt_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void less_Click(object sender, EventArgs e)
        {
            Portion temp;
            for (int i = 0; i < GetPortions.Count - 1; i++)
            {
                for (int j = i + 1; j < GetPortions.Count; j++)
                {
                    if (GetPortions[i].Amount > GetPortions[j].Amount)
                    {
                        temp = GetPortions[i];
                        GetPortions[i] = GetPortions[j];
                        GetPortions[j] = temp;
                    }
                }
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);
        }
        private void More_Butt_Click(object sender, EventArgs e)
        {
            // Sort
            Portion temp;
            for (int i = 0; i < GetPortions.Count - 1; i++)
            {
                for (int j = i + 1; j < GetPortions.Count; j++)
                {
                    if (GetPortions[i].Amount < GetPortions[j].Amount)
                    {
                        temp = GetPortions[i];
                        GetPortions[i] = GetPortions[j];
                        GetPortions[j] = temp;
                    }
                }
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);
        }

        private void UndoButtForTrips_Click(object sender, EventArgs e)
        {

        }
    }
}
