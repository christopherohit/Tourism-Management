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

namespace Newest
{
    public partial class OrderInformation : Form
    {
        
        List<Portion> GetPortions;
        Order GetOrder;
        public OrderInformation(Order order)
        {
            InitializeComponent();
            GetOrder = order;
        }

        private void OrderInformation_Load(object sender, EventArgs e)
        {

            int count = 0;
            GetPortions = new List<Portion>();
            foreach (Portion p in GetOrder.Portions)
            {
                GetPortions.Add(p);
                count += (int)(p.Amount * p.Trip.Price);
            }
            portionBindingSource.DataSource = GetPortions;
            portionBindingSource.ResetBindings(false);

            TenKhach.Text = GetOrder.Client.Name;
            MailsKhack.Text = GetOrder.Client.Emails;
            TongThietHai.Text = Convert.ToString(count);

            
        }

        private void OrderInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Bạn Có Thật Sư Muốn Thoát", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
