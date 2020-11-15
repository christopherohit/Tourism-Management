namespace Newest
{
    partial class EditAgency
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAgency));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddTrip = new System.Windows.Forms.Button();
            this.EditTrip = new System.Windows.Forms.Button();
            this.DeleteTrip = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.locationTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SaveAgency = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CancelSaving = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = " To the Editor !!!! Be Creative - Be First";
            // 
            // AddTrip
            // 
            this.AddTrip.ForeColor = System.Drawing.Color.Black;
            this.AddTrip.Location = new System.Drawing.Point(12, 96);
            this.AddTrip.Name = "AddTrip";
            this.AddTrip.Size = new System.Drawing.Size(75, 23);
            this.AddTrip.TabIndex = 1;
            this.AddTrip.Text = "Add";
            this.AddTrip.UseVisualStyleBackColor = true;
            this.AddTrip.Click += new System.EventHandler(this.AddTrip_Click);
            // 
            // EditTrip
            // 
            this.EditTrip.ForeColor = System.Drawing.Color.Black;
            this.EditTrip.Location = new System.Drawing.Point(141, 96);
            this.EditTrip.Name = "EditTrip";
            this.EditTrip.Size = new System.Drawing.Size(75, 23);
            this.EditTrip.TabIndex = 1;
            this.EditTrip.Text = "Edit";
            this.EditTrip.UseVisualStyleBackColor = true;
            this.EditTrip.Click += new System.EventHandler(this.EditTrip_Click);
            // 
            // DeleteTrip
            // 
            this.DeleteTrip.ForeColor = System.Drawing.Color.Black;
            this.DeleteTrip.Location = new System.Drawing.Point(279, 96);
            this.DeleteTrip.Name = "DeleteTrip";
            this.DeleteTrip.Size = new System.Drawing.Size(75, 23);
            this.DeleteTrip.TabIndex = 1;
            this.DeleteTrip.Text = "Delete";
            this.DeleteTrip.UseVisualStyleBackColor = true;
            this.DeleteTrip.Click += new System.EventHandler(this.DeleteTrip_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.locationTripDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.priceTripDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.portionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(374, 156);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // locationTripDataGridViewTextBoxColumn
            // 
            this.locationTripDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationTripDataGridViewTextBoxColumn.DataPropertyName = "Location_Trip";
            this.locationTripDataGridViewTextBoxColumn.HeaderText = "Location Of Trip";
            this.locationTripDataGridViewTextBoxColumn.Name = "locationTripDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // priceTripDataGridViewTextBoxColumn
            // 
            this.priceTripDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceTripDataGridViewTextBoxColumn.DataPropertyName = "Price_Trip";
            this.priceTripDataGridViewTextBoxColumn.HeaderText = "Price Of Trip";
            this.priceTripDataGridViewTextBoxColumn.Name = "priceTripDataGridViewTextBoxColumn";
            // 
            // portionBindingSource
            // 
            this.portionBindingSource.DataSource = typeof(QuanLyDuLich_Library.Models.Portion);
            // 
            // SaveAgency
            // 
            this.SaveAgency.ForeColor = System.Drawing.Color.Black;
            this.SaveAgency.Location = new System.Drawing.Point(215, 331);
            this.SaveAgency.Name = "SaveAgency";
            this.SaveAgency.Size = new System.Drawing.Size(75, 37);
            this.SaveAgency.TabIndex = 1;
            this.SaveAgency.Text = "Re-Check";
            this.SaveAgency.UseVisualStyleBackColor = true;
            this.SaveAgency.Click += new System.EventHandler(this.SaveAgency_Click);
            // 
            // SendButton
            // 
            this.SendButton.ForeColor = System.Drawing.Color.Black;
            this.SendButton.Location = new System.Drawing.Point(65, 331);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 37);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Accept";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(563, 173);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(225, 63);
            this.DescriptionBox.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(563, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 183);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(445, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(445, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Description:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(563, 105);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(148, 20);
            this.NameBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(445, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Image:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CancelSaving
            // 
            this.CancelSaving.ForeColor = System.Drawing.Color.Black;
            this.CancelSaving.Location = new System.Drawing.Point(139, 380);
            this.CancelSaving.Name = "CancelSaving";
            this.CancelSaving.Size = new System.Drawing.Size(75, 37);
            this.CancelSaving.TabIndex = 1;
            this.CancelSaving.Text = "Cancel";
            this.CancelSaving.UseVisualStyleBackColor = true;
            this.CancelSaving.Click += new System.EventHandler(this.CancelSaving_Click);
            // 
            // EditAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SaveAgency);
            this.Controls.Add(this.CancelSaving);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.DeleteTrip);
            this.Controls.Add(this.EditTrip);
            this.Controls.Add(this.AddTrip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditAgency";
            this.Text = "Chỉnh Sửa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAgency_FormClosing);
            this.Load += new System.EventHandler(this.EditAgency_Load);
            this.TextChanged += new System.EventHandler(this.EditAgency_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddTrip;
        private System.Windows.Forms.Button EditTrip;
        private System.Windows.Forms.Button DeleteTrip;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource portionBindingSource;
        private System.Windows.Forms.Button SaveAgency;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CancelSaving;
    }
}