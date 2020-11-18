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
using QuanLyDuLich_Library.DAL;
using System.Security.Cryptography;


namespace Newest
{
    public partial class SignUp_Form : Form
    {
        VietTravel GetVietTravel;
        const string Pass_code = "2812199920032000";
        public string Encryt(string mahoa)
        {
            bool bangbam = true;
            Byte[] mangkhoa;
            Byte[] mahoamang = UTF8Encoding.UTF8.GetBytes(mahoa);

            if (bangbam == true)
            {
                MD5CryptoServiceProvider styleMD5 = new MD5CryptoServiceProvider();
                mangkhoa = styleMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Pass_code));
            }
            else
            {
                mangkhoa = UTF8Encoding.UTF8.GetBytes(Pass_code);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = mangkhoa;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
            Byte[] ngaunhien = cryptoTransform.TransformFinalBlock(mahoamang, 0, mahoamang.Length);
            string thucnghiem = Convert.ToBase64String(ngaunhien, 0, ngaunhien.Length);
            return thucnghiem;
        }
        public SignUp_Form(ref VietTravel store)
        {
            this.GetVietTravel = store;
            InitializeComponent();        
        }

        private void SignUp_Button_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Admin_acc.Text) || string.IsNullOrWhiteSpace(Admin_Pass.Text))
            {
                if (string.IsNullOrWhiteSpace(Admin_acc.Text))
                {
                    Admin_acc.BackColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(Admin_Pass.Text))
                {
                    Admin_Pass.BackColor = Color.Red;
                }

                MessageBox.Show("Please fill in blankspace","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Admin_acc.BackColor = Color.Red;
                Admin_Pass.BackColor = Color.Red;
            }
            else if (Admin_acc.Text.Length <= 4 || Admin_Pass.Text.Length <= 6)
            {
                if(Admin_acc.Text.Length <= 4)
                {
                    Admin_acc.BackColor = Color.Red;
                    MessageBox.Show("Your Name Just Fill In Too Short \n Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Admin_acc.BackColor = Color.White;
                    Admin_acc.Text = string.Empty;
                }
                if(Admin_Pass.Text.Length <= 6)
                {
                    Admin_Pass.BackColor = Color.Red;
                    MessageBox.Show("Your Password Which You Just Fill In Too Short \n We Required You Should Set The Password Which Have More And More Characters \n Thanks You.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Admin_Pass.BackColor = Color.White;
                    Admin_Pass.Text = string.Empty;
                }
            }
            else
            {
                string fake_name;
                int finger;
                int secure;
                bool isInt = int.TryParse(Admin_Pass.Text, out finger);
                bool isIntName = int.TryParse(Admin_acc.Text, out finger);
                if(isIntName == true || isInt == false)
                {
                    if(isIntName == true)
                    {
                        Admin_acc.BackColor = Color.Red;
                        MessageBox.Show("Name Consists Only Of Numbers, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Admin_acc.Text = string.Empty;
                        Admin_acc.BackColor = Color.White;
                    }
                    else
                    {
                        fake_name = Admin_acc.Text;
                    }
                    if(isInt == false)
                    {
                        Admin_Pass.BackColor = Color.Red;
                        MessageBox.Show("Password Include Number And Character, Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Admin_Pass.Text = string.Empty;
                        Admin_Pass.BackColor = Color.White;
                    }
                    else
                    {
                        secure = Convert.ToInt32(Admin_Pass.Text);
                    }
                }
                else
                {
                    fake_name = Admin_acc.Text;
                    secure = Convert.ToInt32(Admin_Pass.Text);
                    string pass = Secret_Code.Text;

                    if(GetVietTravel.Admins.FirstOrDefault(u => u.Name == fake_name) != null)
                    {
                        MessageBox.Show("You Have Already Exist In My System...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Admin_acc.Text = string.Empty;
                        Admin_Pass.Text = string.Empty;
                    }
                    else
                    {
                        if(pass == Pass_code)
                        {
                            Admin Krystal = new Admin(fake_name, secure);
                            GetVietTravel.Admins.Add(Krystal);
                            MessageBox.Show("Welcome To My Team \n We are Glad to Hear you joined us", "Anounment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetVietTravel.Save();
                            Form Customer = Application.OpenForms[0];
                            Customer.Left = this.Left;
                            Customer.Top = this.Top;
                            Customer.Show();
                            this.Close();
                        }
                        else
                        {
                            Secret_Code.BackColor = Color.Red;
                            MessageBox.Show("Please Re-Checked Your Admin Password !!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Secret_Code.Text = string.Empty;
                            Secret_Code.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void SignUp_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Do You Want Exit From The Signing Up Form ???", "Anoun", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    Form Custom = Application.OpenForms[0];
                    Custom.Left = this.Left;
                    Custom.Top = this.Top;
                    Custom.Show();
                    break;
            }
        }

        private void SignUp_Form_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"To create account by admin, you need a Passcode \n To have a passcode let decode this code: \n {Encryt(Pass_code)}", "Challenge", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
