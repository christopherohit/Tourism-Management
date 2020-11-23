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

        }

        private void Question_MouseHover(object sender, EventArgs e)
        {

        }

        private void Unrate_Click(object sender, EventArgs e)
        {

        }

        private void Rate_Click(object sender, EventArgs e)
        {

        }

        private void nameOfagency_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainClient_Load(object sender, EventArgs e)
        {
            GetVietTravel.Load();

            agencyBindingSource.ResetBindings(false);
            portionBindingSource.ResetBindings(false);

        }

        private void More_Butt_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
