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


namespace Newest
{
    public partial class SeeOrders : Form
    {
        List<Portion> OrderPortion;
        Order GetOrder;

        public SeeOrders(Order order)
        {
            InitializeComponent();
            GetOrder = order;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Load Information for SeeOrders
        private void SeeOrders_Load(object sender, EventArgs e)
        {
            int count = 0;
            OrderPortion = new List<Portion>();
            foreach(Portion p in GetOrder.Portions)
            {
                OrderPortion.Add(p);
                count += (int)(p.Amount * p.Trip.Price);
            }
            portionBindingSource.DataSource = GetOrder;
            portionBindingSource.ResetBindings(false);

            NameForClient.Text = GetOrder.Client.Name;
            EmailsForClient.Text = GetOrder.Client.Emails;
            BigMoney.Text = Convert.ToString(count);
        }

        private void SeeOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Do You Want Exit ???", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            switch (res)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.OK:
                    Close();
                    break;
            }
        }
    }
}
