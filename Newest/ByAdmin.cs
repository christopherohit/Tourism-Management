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
    public partial class ByAdmin : Form
    {
        internal VietTravel GetVietTravel;

        public ByAdmin()
        {
            InitializeComponent();
            GetVietTravel = new VietTravel();
        }

        private void ByAdmin_Load(object sender, EventArgs e)
        {
            GetVietTravel.Load();
        }

        private void InBut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserBox.Text) || string.IsNullOrWhiteSpace(PassBox.Text))
            {
                if (string.IsNullOrWhiteSpace(UserBox.Text))
                {
                    UserBox.BackColor = Color.Red;
                }
                if (string.IsNullOrWhiteSpace(PassBox.Text))
                {
                    PassBox.BackColor = Color.Red;
                }

                MessageBox.Show("Please fill in blank space ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserBox.Text = string.Empty;
                PassBox.Text = string.Empty;
                UserBox.BackColor = Color.White;
                PassBox.BackColor = Color.White;
            }
            else if (UserBox.Text.Length <= 3 || UserBox.Text.Length >= 20)
            {
                UserBox.BackColor = Color.Red;
                MessageBox.Show("The length For Host don't suitable, \n it must should less than 20 and longer than 3 letter \n Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserBox.Text = string.Empty;
                UserBox.BackColor = Color.White;
            }
            else
            {
                string nickname;
                int number;
                int password;
                bool isInt = int.TryParse(PassBox.Text, out number);
                bool isIntName = int.TryParse(UserBox.Text, out number);
                if(isIntName == true || isInt == false)
                {
                    if(isIntName == true)
                    {
                        UserBox.BackColor = Color.Red;
                        MessageBox.Show("Username Only Consist of number \n Please try again" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                        UserBox.Text = string.Empty;
                        UserBox.BackColor = Color.White;
                    }
                    else
                    {
                        nickname = UserBox.Text;
                    }
                    if(isInt == false)
                    {
                        PassBox.BackColor = Color.Red;
                        MessageBox.Show("Password Only Consist of number \n Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PassBox.Text = string.Empty;
                        PassBox.BackColor = Color.White;
                    }
                    else
                    {
                        password = Convert.ToInt32(PassBox.Text);
                    }
                }
                else
                {
                    nickname = UserBox.Text;
                    password = Convert.ToInt32(PassBox.Text);
                    // Check User Exist.
                    if(GetVietTravel.Admins.FirstOrDefault(u => u.Name == nickname && u.Password == password) != null)
                    {
                        MessageBox.Show($"Hello, {nickname}! We hope you have a nice day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form aform = new MainForm(ref GetVietTravel);
                        aform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, Such Admin doesn't exist \n You Have Two choice sign up or try again !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UserBox.Text = string.Empty;
                        PassBox.Text = string.Empty;
                    }
                }
            }
        }

        private void UpBut_Click(object sender, EventArgs e)
        {
            Form form = new
        }
    }
}
