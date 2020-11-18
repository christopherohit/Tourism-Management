using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDuLich_Library.Models;


namespace Khach_Hang
{
    public partial class SignUp : Form
    {
        VietTravel GetVietTravel;
        public SignUp(VietTravel vietTravel)
        {
            InitializeComponent();
            this.GetVietTravel = vietTravel;
        }

        public SignUp()
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";
            if(string.IsNullOrWhiteSpace(AccField.Text) || string.IsNullOrWhiteSpace(PassField.Text))
            {
                if (string.IsNullOrWhiteSpace(AccField.Text))
                {
                    AccField.BackColor = Color.Red;
                }
                if(string.IsNullOrWhiteSpace (PassField.Text))
                {
                    PassField.BackColor = Color.Red;
                }
                MessageBox.Show("Please fill in the blank space", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccField.Text = string.Empty;
                PassField.Text = string.Empty;
                AccField.BackColor = Color.White;
                PassField.BackColor = Color.White;
            }
            else if (AccField.Text.Length <= 3 || AccField.Text.Length >= 20)
            {
                AccField.BackColor = Color.Red;
                MessageBox.Show("Your Name Just Fill In Too Short Or Too Long \n The limited for name along from 3 to 20 \n Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccField.Text = string.Empty;
                AccField.BackColor = Color.White;

            }
            else if (PassField.Text.Length < 8 || PassField.Text.Length >= 30)
            {
                PassField.BackColor = Color.Red;
                MessageBox.Show("Your Password Just Fill In Too Short Or Too Long \n The limited for name along from 8 to 30 \n Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PassField.Text = string.Empty;
                PassField.BackColor = Color.White;
            }
            else if (!Regex.IsMatch(MailsField.Text , pattern , RegexOptions.IgnoreCase))
            {
                MailsField.BackColor = Color.Red;
                MessageBox.Show("Your Emails isn't right format \n Please re-check it and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MailsField.Text = string.Empty;
                MailsField.BackColor = Color.White;
            }
            else
            {
                string nickname;
                int number;
                int pass;
                string emails;
                bool IsInt = int.TryParse(PassField.Text, out number);
                bool IsIntName = int.TryParse(AccField.Text, out number);
                // Check Name and pass just consist only number
                if (IsInt == true || IsIntName == true)
                {
                    if(IsIntName == true)
                    {
                        AccField.BackColor = Color.Red;
                        MessageBox.Show("Name Consists Only Of Numbers, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AccField.Text = string.Empty;
                        AccField.BackColor = Color.White;
                    }
                    else
                    {
                        nickname = AccField.Text;
                    }
                    if( IsInt == false)
                    {
                        PassField.BackColor = Color.Red;
                        MessageBox.Show("Password just only Consists Of Numbers, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PassField.Text = string.Empty;
                        PassField.BackColor = Color.White;
                    }
                    else
                    {
                        pass = Convert.ToInt32(PassField.Text);
                    }
                }
                else
                {
                    nickname = AccField.Text;
                    pass = Convert.ToInt32(PassField.Text);
                    emails = MailsField.Text;

                    // Check Acc Was Exist ???
                    if (GetVietTravel.Clients.FirstOrDefault(u => u.Name == nickname) != null)
                    {
                        MessageBox.Show("Sorry, This name already exist \n Please choose another name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AccField.Text = string.Empty;
                    }
                    if(GetVietTravel.Clients.FirstOrDefault(u => u.Emails == emails) != null)
                    {
                        MessageBox.Show("Sorry, This Emails already exist \n Please choose another emails", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MailsField.Text = string.Empty;
                    }
                    else
                    {
                        Client user = new Client(nickname, pass, emails);
                        GetVietTravel.Clients.Add(user);
                        MessageBox.Show("Congratulation, We are glad to hear you joined us !" , "Information" , MessageBoxButtons.OK , MessageBoxIcon.Information);
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

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name longer than 4 anf less than 10\nEmail with normal form\nPassword longer than 4 less than 10 withoun letters");
        }
    }
}
