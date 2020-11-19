using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDuLich_Library.DAL;
using QuanLyDuLich_Library.Models;

namespace Khach_Hang
{
    public partial class ShowAgency : Form
    {
        Agency GetAgency;
        Client GetClient;
        VietTravel GetVietTravel;
        public ShowAgency(Agency agency,Client client , VietTravel vietTravel)
        {
            InitializeComponent();
            GetAgency = agency;
            GetClient = client;
            GetVietTravel = vietTravel;
        }

        private void ShowAgency_Load(object sender, EventArgs e)
        {
            PicClient.Image = GetAgency.Image;
            NameBox.Text = GetAgency.Name;
            DesBox.Text = GetAgency.Description;
            TotalLikeBox.Text = Convert.ToString(GetAgency.Likes);
            TotalTripBox.Text = Convert.ToString(GetAgency.Amount);
            portionBindingSource.ResetBindings(false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Portion a = (Portion)dataGridView1.CurrentRow.DataBoundItem;
            var daily = new ShowTrip(a, GetClient, GetVietTravel);

            if (daily.ShowDialog() == DialogResult.OK)
            {
                portionBindingSource.ResetBindings(false);
            }
        }

        private void ShowAgency_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
