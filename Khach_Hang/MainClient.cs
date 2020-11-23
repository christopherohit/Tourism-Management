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
using System.Diagnostics;

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
            KhoiPhucDaiLy();
            KhoiPhucHangDat();
            KhoiPhucTrip();
            
        }
        private void KhoiPhucHangDat()
        {
            GetOrder = new Order(null, GetClient);
            cost = 0;
            if(GetVietTravel.Orders.Count > 0)
            {
                for(int i =0; i < GetVietTravel.Orders.Count; i++)
                {
                    if (GetVietTravel.Orders[i].Client.Name == GetClient.Name && GetVietTravel.Orders[i].IsOrdered != true)
                    {
                        GetOrder = new Order(GetVietTravel.Orders[i].Portions, GetClient, GetVietTravel.Orders[i].DateTime);
                        foreach(Portion p in GetVietTravel.Orders[i].Portions)
                        {
                            cost += p.Amount * p.Trip.Price;
                        }
                        TotalPrice.Text = Convert.ToString(cost);
                    }
                    else
                    {
                        TotalPrice.Text = Convert.ToString(cost);
                    }
                }
            }
            else
            {
                TotalPrice.Text = Convert.ToString(cost);
            }
            portionBindingSource.DataSource = GetOrder.Portions;
            portionBindingSource.ResetBindings(false);
        }
        private void KhoiPhucDaiLy()
        {
            List<Agency> agencies = new List<Agency>();
            foreach(Agency a in GetVietTravel.Agencies)
            {
                if (a.Portions.Count != 0)
                {
                    agencies.Add(a);
                }
            }
            agencyBindingSource.DataSource = agencies;
            agencyBindingSource.ResetBindings(false);
        }
        private void KhoiPhucTrip()
        {
            port = new List<Portion>();
            foreach(Agency a in GetVietTravel.Agencies)
            {
                foreach(Portion p in a.Portions)
                {
                    if (p.Amount > 0)
                    {
                        port.Add(p);
                    }
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
            Agency temp;
            for (int i = 0; i < GetAgencies.Count - 1; i++)
            {
                for (int j = i + 1; j < GetAgencies.Count; j++)
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
            Process.Start("https://login.wmtransfer.com/GateKeeper/Password/d8b1e286-4519-40dd-a39b-2d22ba7c7ad4.aspx");
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
            GetPortions = new List<Portion>();
            foreach( Agency a in GetVietTravel.Agencies)
            {
                foreach(Portion p in a.Portions)
                {
                    GetPortions.Add(p);
                }
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);
        }

        private void LocationsForClient_SelectedItemChanged(object sender, EventArgs e)
        {
            GetPortions = new List<Portion>();
            foreach ( Agency a in GetVietTravel.Agencies)
            {
                foreach (Portion p in a.Portions)
                {
                    if (p.Location_Trip == LocationsForClient.Text)
                    {
                        GetPortions.Add(p);
                    }
                }
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);
        }

        private void AgencyView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Agency a = (Agency)AgencyView.CurrentRow.DataBoundItem;
            var chitiet = new ShowAgency(a, GetClient, GetVietTravel);
            if (chitiet.ShowDialog() == DialogResult.OK)
            {
                portionBindingSource.ResetBindings(false);
            }
            KhoiPhucHangDat();
            KhoiPhucDaiLy();
        }

        private void TripClientGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Portion a = (Portion)TripClientGridView.CurrentRow.DataBoundItem;
            var chitiet = new ShowTrip(a, GetClient, GetVietTravel);
            if (chitiet.ShowDialog() == DialogResult.OK)
            {
                portionBindingSource.ResetBindings(false);
            }
            KhoiPhucHangDat();
            KhoiPhucDaiLy();
        }

        private void Compilation_Click(object sender, EventArgs e)
        {
            if (OrderGrid.Rows.Count > 0)
            {
                var xuat = MessageBox.Show("Do you want to order which on your list", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                switch (xuat)
                {
                    case DialogResult.OK:
                        if(GetVietTravel.Orders.Count > 0)
                        {
                            foreach(Order o in GetVietTravel.Orders)
                            {
                                if (GetOrder.Client.Name == GetClient.Name)
                                {
                                    o.IsOrdered = true;
                                    GetVietTravel.Save();
                                }
                            }
                        }
                        break;
                    case DialogResult.Cancel:
                        break;
                }
                KhoiPhucHangDat();
            }
            else
            {
                MessageBox.Show("Sorry, There are nothing of trip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainClient_FormClosing(object sender, FormClosingEventArgs e)
        {

            var res = MessageBox.Show("Bạn Có Thật Sư Muốn Thoát", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.OK:
                    Form toang = Application.OpenForms[0];
                    toang.Left = this.Left;
                    toang.Top = this.Top;
                    toang.Show();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void DeletePortFromOrder_Click(object sender, EventArgs e)
        {
            if (OrderGrid.Rows.Count > 0)
            {
                for (int i = 0; i < OrderGrid.Rows.Count; i++)
                {
                    if(OrderGrid.Rows[i].Selected == true)
                    {
                        break;
                    }
                    else if (i + 1 == OrderGrid.Rows.Count)
                    {
                        OrderGrid.Rows[0].Selected = true;
                    }
                }
                bool huydon = false;

                var xoa = OrderGrid.SelectedRows[0].DataBoundItem as Portion;
                int dem = 0;

                var res = MessageBox.Show($"Do you want to delete the {xoa.Trip.Location} from your list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    Portion click = new Portion();
                    GetOrder.Portions = new List<Portion>();

                    foreach(Order o in GetVietTravel.Orders)
                    {
                        if (o.Client.Name == GetClient.Name) // Check data correctly
                        {
                            foreach(Portion p in o.Portions) // Accept Delete only 1 object
                            {
                                if (p.Agency_Name != xoa.Agency_Name || p.Trip.Location != xoa.Trip.Location || p.Trip.Price !=  xoa.Trip.Price || p.Amount != xoa.Amount)
                                {
                                    GetOrder.Portions.Add(p); // save all except one toDel
                                    dem += 1;
                                }
                                else
                                {
                                    click = p;
                                    dem += 1;
                                }
                                if( dem == o.Portions.Count)
                                {
                                    foreach(Agency a in GetVietTravel.Agencies)
                                    {
                                        if (a.Name == click.Agency_Name)
                                        {
                                            foreach (Portion p2 in a.Portions)
                                            {
                                                if (p2.Location_Trip == click.Location_Trip && p2.Price_Trip == click.Price_Trip)
                                                {
                                                    if(p2.Amount > 0)
                                                    {
                                                        p2.Amount += click.Amount;
                                                        huydon = true;
                                                        portionBindingSource1.DataSource = GetOrder.Portions;
                                                        portionBindingSource1.ResetBindings(false);
                                                        o.Portions = GetOrder.Portions;
                                                    }
                                                    else
                                                    {
                                                        p2.Amount = click.Amount;
                                                        huydon = true;
                                                        portionBindingSource1.DataSource = GetOrder.Portions;
                                                        portionBindingSource1.ResetBindings(false);
                                                        o.Portions = GetOrder.Portions;
                                                    }
                                                }
                                                if( huydon == true)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        if (huydon == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            if(huydon == true)
                            {
                                break;
                            }
                        }
                        if (huydon== true)
                        {
                            break;
                        }
                    }
                    if (GetVietTravel.Orders.Count != 0)
                    {
                        int x = GetVietTravel.Orders.Count - 1;
                        for (int i = x; i >= 0; i--)
                        {
                            if (GetVietTravel.Orders[i].Portions.Count == 0)
                            {
                                GetVietTravel.Orders.Remove(GetVietTravel.Orders[i]);
                            }
                        }
                    }
                    GetVietTravel.Save();
                    KhoiPhucHangDat();
                    KhoiPhucTrip();
                    
                }
            }
            else
            {
                MessageBox.Show("Sorry, if you want to delete - you have to clik on one of the portions");
            }
        }

        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! \nThis is your personal basket)\nPress Delete to remove one selected portion of trip\nPress Complete to send request to the Admin\nWe wish you to have the best trip ever with VisitEasy");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! \nPress wallet for trips with lower price\nPress money for trips with higher price\nChoose location by scrolling up and down\nSearch by available amount of trips\nUndo to start again");
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Process.Start("https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&ru=https%3A%2F%2Fwww.ebay.vn%2F");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.mastercardconnect.com/mccpblcui/#/public/signin");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.visa.com.au/en_au/account/login");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int temp = 3 , cout = 0;
            for (int i = 0; i <= temp; i++)
            {
                cout = cout + 1;
            }
            retry:;
            if (cout <= temp)
            {
                var troll = MessageBox.Show("This service isn't availabel at your country \n Pleas try another service or try again", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (troll == DialogResult.Retry)
                {
                    goto retry;
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Process.Start("https://app.emoney.tpb.vn/auth/login");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://business.momo.vn/login");
        }
    }
}
