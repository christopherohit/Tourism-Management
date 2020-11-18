using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QuanLyDuLich_Library.Models;
using QuanLyDuLich_Library.DAL;

namespace Khach_Hang
{
    public partial class SignIn : Form
    {
        internal VietTravel GetVietTravel;
        Client GetClient;
        
        public SignIn()
        {
            InitializeComponent();
            GetVietTravel = new VietTravel();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            GetVietTravel.Load();
        }

        private void SignInBut_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(PassBox.Text))
            {
                if (string.IsNullOrWhiteSpace(NameBox.Text))
                {
                    NameBox.BackColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(PassBox.Text))
                {
                    PassBox.BackColor = Color.Red;
                }
                MessageBox.Show("Please fill in the blank space", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameBox.Text = string.Empty;
                PassBox.Text = string.Empty;
                NameBox.BackColor = Color.White;
                PassBox.BackColor = Color.White;
            }
            else if (NameBox.Text.Length <= 3 || NameBox.Text.Length >= 20)
            {
                NameBox.BackColor = Color.Red;
                MessageBox.Show("Your Name Just Fill In Too Short Or Too Long \n The limited for name along from 3 to 20 \n Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameBox.Text = string.Empty;
                NameBox.BackColor = Color.White;

            }
            else if (PassBox.Text.Length < 8 || PassBox.Text.Length >= 30)
            {
                PassBox.BackColor = Color.Red;
                MessageBox.Show("Your Password Just Fill In Too Short Or Too Long \n The limited for name along from 8 to 30 \n Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PassBox.Text = string.Empty;
                PassBox.BackColor = Color.White;
            }
            else if (!Regex.IsMatch(MailsBox.Text, pattern, RegexOptions.IgnoreCase))
            {
                MailsBox.BackColor = Color.Red;
                MessageBox.Show("Your Emails isn't right format \n Please re-check it and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MailsBox.Text = string.Empty;
                MailsBox.BackColor = Color.White;
            }
            else
            {
                string nickname;
                int number;
                int pass;
                string emails;
                bool IsInt = int.TryParse(PassBox.Text, out number);
                bool IsIntName = int.TryParse(NameBox.Text, out number);
                // Check Name and pass just consist only number
                if (IsInt == true || IsIntName == true)
                {
                    if (IsIntName == true)
                    {
                        NameBox.BackColor = Color.Red;
                        MessageBox.Show("Name Consists Only Of Numbers, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NameBox.Text = string.Empty;
                        NameBox.BackColor = Color.White;
                    }
                    else
                    {
                        nickname = NameBox.Text;
                    }
                    if (IsInt == false)
                    {
                        PassBox.BackColor = Color.Red;
                        MessageBox.Show("Password just only Consists Of Numbers, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PassBox.Text = string.Empty;
                        PassBox.BackColor = Color.White;
                    }
                    else
                    {
                        pass = Convert.ToInt32(PassBox.Text);
                    }
                }
                else
                {
                    nickname = NameBox.Text;
                    pass = Convert.ToInt32(PassBox.Text);
                    emails = MailsBox.Text;

                    // Check Acc Was Exist ???
                    if (GetVietTravel.Clients.FirstOrDefault(u => u.Name == nickname) != null)
                    {
                        MessageBox.Show("Sorry, This name already exist \n Please choose another name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NameBox.Text = string.Empty;
                    }
                    if (GetVietTravel.Clients.FirstOrDefault(u => u.Emails == emails) != null)
                    {
                        MessageBox.Show("Sorry, This Emails already exist \n Please choose another emails", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MailsBox.Text = string.Empty;
                    }
                    else
                    {
                        Client user = new Client(nickname, pass, emails);
                        GetVietTravel.Clients.Add(user);
                        MessageBox.Show("Congratulation, We are glad to hear you joined us !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetVietTravel.Save();
                        Form customer = Application.OpenForms[0];
                        customer.Left = this.Left;
                        customer.Top = this.Top;
                        customer.Show();
                        this.Close();
                    }
                }
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        private void SignUpBut_Click(object sender, EventArgs e)
        {
            Form chuyen = new SignUp(GetVietTravel);
            chuyen.Show();
            this.Hide();
        }

        private void MailsBox_TextChanged(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
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
