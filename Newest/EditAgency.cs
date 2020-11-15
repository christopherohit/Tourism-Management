using QuanLyDuLich_Library.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Newest
{
    public partial class EditAgency : Form
    {
        public Agency agency { get; set; }
        public VietTravel vietTravel;
        bool Odd;
        //Create New a Agency
        public EditAgency(VietTravel VietTravel)
        {
            InitializeComponent();
            agency = new Agency();
            vietTravel = VietTravel;
            Odd = false;
        }

        // Update old Version
        public EditAgency(Agency Agency, VietTravel VietTravel) : this(VietTravel)
        {
            Odd = true;
            vietTravel = VietTravel;
            agency = Agency;
            NameBox.Text = Agency.Name;
            DescriptionBox.Text = Agency.Description;
            Agency a = Agency;
            List<Portion> port = a.Portions;
            if (port == null)
            {
                port = new List<Portion> { new Portion(new Trip("Unknow", 0, "Unknow", "Unknow", "Unknow"), 0) };
            }

            pictureBox1.Image = Agency.Image;

        }

        private void EditAgency_Load(object sender, EventArgs e)
        {
            portionBindingSource.DataSource = agency.Portions;
            portionBindingSource.ResetBindings(false);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
            SendButton.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void EditAgency_TextChanged(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        private void EditAgency_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (agency != null)
            {
                if (DialogResult != DialogResult.OK)
                {
                    return;
                }
            }
        }
        private void ValidateItems(Control c)
        {
            if (string.IsNullOrWhiteSpace(c.Text))
            {
                c.BackColor = Color.Red;
                MessageBox.Show("Please fill in the blank space", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c.Text = string.Empty;
                c.BackColor = Color.White;
            }
        }

        private void SaveAgency_Click(object sender, EventArgs e)
        {
            if (agency == null)
            {
                agency = new Agency();
            }
            //Check
            bool flag = true;

            ValidateItems(NameBox);
            if (NameBox.Text.Length > 50 || NameBox.Text.Length < 4)
            {
                NameBox.BackColor = Color.Red;
                MessageBox.Show("The Length of name isn't inconsonant. \n The name is belong from 4 to 50 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameBox.Text = string.Empty;
                NameBox.BackColor = Color.White;
                flag = false;
            }
            else
            {
                for (int i = 0; i < NameBox.Text.Length; i++)
                {
                    if (NameBox.Text[i] >= '0' && NameBox.Text[i] <= '9')
                    {
                        NameBox.BackColor = Color.Red;
                        MessageBox.Show("The Name Just Contains Number ??? \n The Name Should be Include Number and Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NameBox.Text = string.Empty;
                        NameBox.BackColor = Color.White;
                        flag = false;
                        break;
                    }
                }
            }
            agency.Name = NameBox.Text;

            ValidateItems(DescriptionBox);
            if (DescriptionBox.Text.Length > 1000 || DescriptionBox.Text.Length < 12)
            {
                DescriptionBox.BackColor = Color.Red;
                MessageBox.Show("The Length of Description isn't inconsonant. \n The Description is belong from 12 to 1000 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DescriptionBox.BackColor = Color.White;
                DescriptionBox.Text = string.Empty;
            }
            else if (DescriptionBox.Text == null)
            {
                DescriptionBox.BackColor = Color.Red;
                MessageBox.Show("Please Something Into Blank space" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                DescriptionBox.Text = string.Empty;
                DescriptionBox.BackColor = Color.White;
            }

            agency.Description = DescriptionBox.Text;
            


            agency.Image = pictureBox1.Image;
            bool AlreadyExist = false;
            if (agency.Image == null)
            {
                pictureBox1.BackColor = Color.Gray;
                MessageBox.Show("Have You Choose The Picture ???", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.BackColor = Color.White;
                flag = false;
            }
            foreach (Agency a in vietTravel.Agencies)
            {
                if (a.Name == agency.Name && Odd == false)
                {
                    AlreadyExist = true;
                    break;
                }
                else
                {
                    AlreadyExist = false;
                }
            }

            if (AlreadyExist == true)
            {
                NameBox.BackColor = Color.Red;
                MessageBox.Show("This Name Already Exist \n Please Try Again With Another Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameBox.Text = string.Empty;
                NameBox.BackColor = Color.White;
                flag = false;
            }
            if (agency.Portions.Count == 0)
            {
                MessageBox.Show("Please add some trips! It`s impossible to send agency without any trips to the client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
            }
            else
            {
                agency.Portions = new List<Portion>();
                agency.Portions = (List<Portion>)portionBindingSource.DataSource;
                foreach (Portion p in agency.Portions)
                {
                    p.Agency_Name = agency.Name;
                }
                agency.Amount = agency.Portions.Count;
                portionBindingSource.DataSource = agency.Portions;
                portionBindingSource.ResetBindings(false);
            }
            if (agency.Name == "Hendrichs Cullen" || agency.Description == "Victoria City, Melbourne" || agency.Image == null || agency.Portions.Count == 0 || AlreadyExist == true)
            {
                flag = false;
            }
            if (agency.Name == "Christopher Rohit" || agency.Description == "Stuttgart , Germany" || agency.Image == null || agency.Portions.Count == 0 || AlreadyExist == true)
            {
                flag = false;
            }
            if (flag == false)
            {
                SendButton.Show();
                SaveAgency.Hide();
            }
            else
            {
                MessageBox.Show("Do you missed something !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveAgency.Show();
                SendButton.Hide();
            }


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if(dataGridView1.Rows[i].Selected == true)
                    {
                        break;
                    }
                    else if ( i + 1 == dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                }
            }
        }

        private void AddTrip_Click(object sender, EventArgs e)
        {
            var pf = new EditPortion();
            if(pf.ShowDialog() == DialogResult.OK)
            {
                agency.Portions.Add(pf.Portion);
                portionBindingSource.ResetBindings(false);

                if(dataGridView1.Rows.Count > 1)
                {
                    var lastIdx = dataGridView1.Rows.Count - 1;
                    dataGridView1.Rows[lastIdx].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = lastIdx;
                }
            }
        }

        private void EditTrip_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                var chinhsua = dataGridView1.SelectedRows[0].DataBoundItem as Portion;
                var pf = new EditPortion(chinhsua);

                if(pf.ShowDialog() == DialogResult.OK)
                {
                    portionBindingSource.ResetBindings(false);
                }
            }
            else
            {
                MessageBox.Show("Sorry, There Are Nothing To Edit \n You Can add some portions or Delete Agency ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DeleteTrip_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var xoa = dataGridView1.SelectedRows[0].DataBoundItem as Portion;
                var res = MessageBox.Show($"Do you want to delete {xoa.Trip.Location} ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    agency.Portions.Remove(xoa);
                    portionBindingSource.ResetBindings(false);
                }
            }
            else
            {
                MessageBox.Show("Sorry, There's Nothing to delete \n Please Re-check it ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CancelSaving_Click(object sender, EventArgs e)
        {
            if(DialogResult != DialogResult.OK)
            {
                return;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added Data Successly \n You Can Re-check or Edit it" , "Congratulation" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
    }
}
