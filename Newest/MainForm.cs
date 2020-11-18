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
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;
namespace Newest
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class MainForm : Form
    {
        VietTravel GetVietTravel;
        Client GetClient;
        public MainForm( ref VietTravel GetHard)
        {
            InitializeComponent();
            GetVietTravel = GetHard;


            //GetVietTravel.FillTestData(5);

            List<Portion> Port = new List<Portion>();
            foreach(Agency agency in GetVietTravel.Agencies)
            {
                foreach(Portion p in agency.Portions)
                {
                    if (p.OnSale == "Future Trip")
                    {
                        Port.Add(p);
                    }   
                }
            }

            List<Portion> portions = new List<Portion>();
            foreach( Agency agency in GetVietTravel.Agencies)
            {
                foreach( Portion p in agency.Portions)
                {
                    if(p.OnSale == "On Sale")
                    {
                        portions.Add(p);
                    }
                }
            }

            portionBindingSource1.DataSource = Port;
            portionBindingSource2.DataSource = portions;
            portionBindingSource1.ResetBindings(false);
            portionBindingSource2.ResetBindings(false);
        }

        public MainForm()
        {
        }

        // To Encrypt Password before put out it 
        public string Encrypt(string toEncrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(GetClient.Password.ToString()));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(GetClient.Password.ToString());

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /*
         This's Container use to recall for action save
         */
        // Container For use to put out data to file 
        public void SaveCompleteOrders(Order order)
        {
            string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Newest\DataCustomer(HistoryWork)\CompleteOrders.docx");

            using (var wr = new StreamWriter(filepath))
            {
                wr.WriteLine("--------------------------");
                wr.WriteLine();

                if(order.IsOrdered == true && order.CheckedByAdmin == true)
                {
                    string magia = Encrypt().ToString();
                    wr.WriteLine("Name: " + order.Client.Name);
                    wr.WriteLine("Email: " + order.Client.Emails);
                    //wr.WriteLine("Password: " + magia);
                    wr.WriteLine("Password: " + Encrypt(order.Client.Password.ToString()));
                    wr.WriteLine("Date: " + order.DateTime);
                    wr.WriteLine(order.Portions.Count);
                    foreach(var p in order.Portions)
                    {
                        wr.WriteLine("Agency: " + p.Agency_Name);
                        wr.WriteLine("Location: " + p.Trip.Location);
                        wr.WriteLine("Host: " + p.Trip.Host);
                        wr.WriteLine("Amount: " + p.Amount);
                        wr.WriteLine("Total Price: " + p.Price_Trip * p.Amount);
                        wr.WriteLine("-------------------Thanks To Belive Us-------------------------");
                        wr.WriteLine("---------------------------------------------------------------");
                    }
                }
                wr.WriteLine("-------------------------------------------------");
                wr.WriteLine();
            }
        }

        private object Encrypt()
        {
            throw new NotImplementedException();
        }

        /* MainForm - Help - AboutSoftware
         This's used to decorate action when user need to the help about aplication
         */
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Newest\DocumentsForHelp\ChiTietPhanMem.docx");

            // Check File If It doesn't exist
            if (!File.Exists(path))
            {
                // create new file to anounmance
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    Byte[] thongtin = new UTF8Encoding(true).GetBytes("404!!! \n Not Foud \n This Error maybe exist when you change local location please check and replace address to solve it");
                    fs.Write(thongtin, 0, thongtin.Length);

                }
            }

            // open it and read
            using (FileStream fs = File.Open(path,FileMode.Open , FileAccess.Write, FileShare.None))
            {
                Byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while( fs.Read(b , 0 , b.Length) >0)
                {
                    Console.WriteLine(temp.GetString(b));
                }

                try
                {
                    using (FileStream fs2 = File.Open(path, FileMode.Open))
                    {
                        while(fs.Read(b , 0 ,b.Length) > 0)
                        {
                            MessageBox.Show(temp.GetString(b));
                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Please Close File Previous To Continue \n The Opening the file twice is Disallowed. \n as Expected: "+ a.ToString(), "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    
                }
            }

        }

        private void Agency_Tab_Click(object sender, EventArgs e)
        {

        }
        // Default When program started it will run every thing below
        private void MainForm_Load(object sender, EventArgs e)
        {
            agencyBindingSource.DataSource = GetVietTravel.Agencies;
            clientBindingSource.DataSource = GetVietTravel.Clients;
            //orderBindingSource.DataSource = GetVietTravel.Orders;

            agencyBindingSource.ResetBindings(false);
            clientBindingSource.ResetBindings(false);
            portionBindingSource.ResetBindings(false);
            
            if(AgencyGribView.Rows.Count > 0)
            {
                AgencyGribView.Rows[0].Selected = true;
            }
            if(ClientGridView.Rows.Count > 0)
            {
                ClientGridView.Rows[0].Selected = true;
            }
        }
        /* MainForm - File - Load
         To Reload the program 
         */
        private void loadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetVietTravel.Load();
            HotAndFuture();
            agencyBindingSource.ResetBindings(false);
            clientBindingSource.ResetBindings(false);
            
        }
        //Reload Type Into OnSales And FutureTrips.

        // The Container For Hot Sale And Future Trips
        public void HotAndFuture()
        {
            List<Portion> port = new List<Portion>();
            foreach(Agency agency in GetVietTravel.Agencies)
            {
                foreach(Portion p in agency.Portions)
                {
                    if(p.OnSale == "FutureTrip")
                    {
                        port.Add(p);
                    }
                }
            }

            List<Portion> portions = new List<Portion>();
            foreach(Agency agency in GetVietTravel.Agencies)
            {
                foreach(Portion p in agency.Portions)
                {
                    if (p.OnSale == "OnSale")
                    {
                        portions.Add(p);
                    }
                }
            }

            portionBindingSource1.DataSource = port;
            portionBindingSource2.DataSource = portions;
            portionBindingSource1.ResetBindings(false);
            portionBindingSource2.ResetBindings(false);

        }
        /* MainForm - File - Exit
         It Used To Exit the program 
         */
        private void exitToolStripMenuItem_Click(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Bạn Có Thật Sư Muốn Thoát" , "Warning" , MessageBoxButtons.OKCancel , MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.OK:
                    Close();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        // Exit program too
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GetVietTravel.Hendrichs)
            {
                Form KhachHang = Application.OpenForms[0];
                KhachHang.Left = this.Left;
                KhachHang.Top = this.Top;
                KhachHang.Show();
                return;
            }

            var res = MessageBox.Show("Bạn có muốn lưu dữ liệu trước khi thoát ứng dụng ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.Yes:
                    GetVietTravel.Save();
                    Form KhachHang = Application.OpenForms[0];
                    KhachHang.Left = this.Left;
                    KhachHang.Top = this.Top;
                    KhachHang.Show();
                    Application.Exit();
                    break;
                case DialogResult.No:
                    Form KhachHang1 = Application.OpenForms[0];
                    KhachHang1.Left = this.Left;
                    KhachHang1.Top = this.Top;
                    KhachHang1.Show();
                    Application.Exit();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        /* MainForm - Management - Add
         This Action Use To If You Want Add Client into Your data
         */
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pf = new EditAgency(GetVietTravel);
            if (pf.ShowDialog() == DialogResult.OK)
            {
                if (pf.agency != null)
                {
                    foreach(Portion p in pf.agency.Portions)
                    {
                        p.Agency_Name = pf.agency.Name;
                        pf.agency.Amount = pf.agency.Portions.Count;
                    }
                    GetVietTravel.Add_Agency(pf.agency);
                    agencyBindingSource.ResetBindings(false);
                    HotAndFuture();
                    GetVietTravel.Hendrichs = true;
                    var lastIdx = AgencyGribView.Rows.Count - 1;
                    AgencyGribView.Rows[lastIdx].Selected = true;
                    AgencyGribView.FirstDisplayedScrollingRowIndex = lastIdx;

                }
            }
        }
        /* MainForm - Management - Edit
         This Action will accept your change information for someone
         */
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(AgencyGribView.Rows.Count > 0)
            {
                var chinhsua = AgencyGribView.SelectedRows[0].DataBoundItem as Agency;
                var pf = new EditAgency(chinhsua, GetVietTravel);

                if(pf.ShowDialog() == DialogResult.OK)
                {
                    agencyBindingSource.ResetBindings(false);
                    HotAndFuture();
                    GetVietTravel.Hendrichs = true;
                }
            }
            else
            {
                MessageBox.Show("Sorry, There are nothing to edit");
            }
        }
        /*MainForm - Management - Delete
         Need to Delete Something Out of YOur database this action will help you do it 
         */
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( AgencyGribView.Rows.Count > 0)
            {
                var xoa = AgencyGribView.SelectedRows[0].DataBoundItem as Agency;
                var res = MessageBox.Show($"Do You Want Delete {xoa.Name} ?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    GetVietTravel.Agencies.Remove(xoa);
                    agencyBindingSource.ResetBindings(false);
                    HotAndFuture();
                    GetVietTravel.Hendrichs = true;
                }
            }
            else
            {
                MessageBox.Show("Sorry, There are Nothing to delete \n Please Re-check your data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        /*MainForm - File - Save
         This Action recall one which is container help for save data which you was create above
         */
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetVietTravel.Save();
        }
        // Display your data on gribview
        private void AgencyGribView_SelectionChanged(object sender, EventArgs e)
        {
            if (AgencyGribView.Rows.Count > 0)
            {
                Agency b = (Agency)AgencyGribView.CurrentRow.DataBoundItem;
                List<Portion> port = b.Portions;
                portionBindingSource.DataSource = port;
                portionBindingSource.ResetBindings(false);
                foreach(DataGridViewRow row in ClientGridView.Rows)
                {
                    for (int i  = 0; i < port.Count; i++)
                    {
                        if (port[i].OnSale == "OnSale")
                        {
                            ClientGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (port[i].OnSale == "FutureTrip")
                        {
                            ClientGridView.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        }
                        else
                        {
                            ClientGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }

             
            }
            else
            {
                MessageBox.Show("Please Re-check Your List \n List of Agency is Empty", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                List<Portion> port = new List<Portion>();
                portionBindingSource.DataSource = port;
                portionBindingSource.ResetBindings(false);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FutureTripGribView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerGribView_SelectionChanged(object sender, EventArgs e)
        {
            if(CustomerGribView.Rows.Count > 0)
            {
                GetClient = (Client)clientBindingSource.Current;
                List<Order> orders = new List<Order>();
                if (GetClient != null)
                {
                    if(GetVietTravel.Orders.Count > 0)
                    {
                        for(int i = 0; i < GetVietTravel.Orders.Count; i++)
                        {
                            if(GetVietTravel.Orders[i].Client.Name == GetClient.Name && GetVietTravel.Orders[i].IsOrdered == true)
                            {
                                orders.Add(GetVietTravel.Orders[i]);
                            }
                        }
                        if(orders.Count > 0)
                        {
                            orderBindingSource.DataSource = orders;
                            orderBindingSource.ResetBindings(false);
                            OrderGribView.Rows[0].Selected = true;
                        }
                        else
                        {
                            orderBindingSource.DataSource = orders;
                            orderBindingSource.ResetBindings(false);
                        }
                    }
                }
                else
                {
                    orderBindingSource.DataSource = orders;
                    orderBindingSource.ResetBindings(false);
                }
            }
            else
            {
                MessageBox.Show("Please Re-Check Your List \n List of Client is Empty" , "Warnning" , MessageBoxButtons.OK,MessageBoxIcon.Warning);
                List<Portion> port = new List<Portion>();
                clientBindingSource.DataSource = port;
                clientBindingSource.ResetBindings(false);
            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        /* Ordered 
         Delete SomeOne
         */
        private void ForBibButton_Click(object sender, EventArgs e)
        {
            if (CustomerGribView.Rows.Count > 0)
            {
                for (int i = 0; i < CustomerGribView.Rows.Count; i++)
                {
                    if(CustomerGribView.Rows[i].Selected == true)
                    {
                        break;
                    }
                    else if( i + 1 == CustomerGribView.Rows.Count)
                    {
                        CustomerGribView.Rows[0].Selected = true;
                    }
                }
                var xoa = CustomerGribView.SelectedRows[0].DataBoundItem as Client;
                var res = MessageBox.Show($"Do You Want to Delete {xoa.Name} ?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    GetVietTravel.Clients.Remove(xoa);
                    clientBindingSource.ResetBindings(false);
                    HotAndFuture();
                    GetVietTravel.Hendrichs = true;
                }

            }
            else
            {
                MessageBox.Show("The List of client is Empty \n Please re-check it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void OperateOrder_Click(object sender, EventArgs e)
        {

        }

        private void s(object sender, EventArgs e)
        {

        }

        private void globallyForQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Newest\DocumentsForHelp\Question.txt");

            // Check File If It doesn't exist
            if (!File.Exists(path))
            {
                // create new file to anounmance
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    Byte[] thongtin = new UTF8Encoding(true).GetBytes("404!!! \n Not Foud \n This Error maybe exist when you change local location please check and replace address to solve it");
                    fs.Write(thongtin, 0, thongtin.Length);

                }
            }

            // open it and read
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                Byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }

                try
                {
                    using (FileStream fs2 = File.Open(path, FileMode.Open))
                    {
                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            MessageBox.Show(temp.GetString(b));
                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Please Close File Previous To Continue \n The Opening the file twice is Disallowed. \n as Expected: " + a.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Starting laughing Brower to Github....
            System.Diagnostics.Process.Start("https://github.com/christopherohit");
            Thread.Sleep(3000);
            var ip = MessageBox.Show("Help Me Follow It \n Thanks You Too Much", "Appeal", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if( ip == DialogResult.Yes)
            {
                MessageBox.Show("Thanks You Following Me");
            }
            else
            {
                MessageBox.Show("Thanks For Trial This Product");
            }
        }

        private void privacyAndLiceneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Newest\DocumentsForHelp\License.txt");

            // Check File If It doesn't exist
            if (!File.Exists(path))
            {
                // create new file to anounmance
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    Byte[] thongtin = new UTF8Encoding(true).GetBytes("404!!! \n Not Foud \n This Error maybe exist when you change local location please check and replace address to solve it");
                    fs.Write(thongtin, 0, thongtin.Length);

                }
            }

            // open it and read
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                Byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }

                try
                {
                    using (FileStream fs2 = File.Open(path, FileMode.Open))
                    {
                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            MessageBox.Show(temp.GetString(b));
                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Please Close File Previous To Continue \n The Opening the file twice is Disallowed. \n as Expected: " + a.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void ViewOrder_Click(object sender, EventArgs e)
        {
            if (OrderGribView.Rows.Count > 0)
            {
                var xemlai = OrderGribView.SelectedRows[0].DataBoundItem as Order;
                var pf = new SeeOrders(xemlai);

                if (pf.ShowDialog() == DialogResult.OK)
                {
                    agencyBindingSource.ResetBindings(false);
                    HotAndFuture();
                    GetVietTravel.Hendrichs = true;
                }
            }
            else
            {
                MessageBox.Show("Sorry ,There is nothing to see \n Please re-check your data " , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        
    }
}
