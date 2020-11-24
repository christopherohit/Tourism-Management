namespace Khach_Hang
{
    partial class ShowAgency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAgency));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.agencyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.TotalLikeBox = new System.Windows.Forms.TextBox();
            this.TotalTripBox = new System.Windows.Forms.TextBox();
            this.DesBox = new System.Windows.Forms.TextBox();
            this.PicClient = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClient)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Here is an Agency you liked:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dear , Client! ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.agencyNameDataGridViewTextBoxColumn,
            this.locationTripDataGridViewTextBoxColumn,
            this.onSaleDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.priceTripDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.portionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(619, 340);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // agencyNameDataGridViewTextBoxColumn
            // 
            this.agencyNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.agencyNameDataGridViewTextBoxColumn.DataPropertyName = "Agency_Name";
            this.agencyNameDataGridViewTextBoxColumn.HeaderText = "Tên Đại Lý";
            this.agencyNameDataGridViewTextBoxColumn.Name = "agencyNameDataGridViewTextBoxColumn";
            // 
            // locationTripDataGridViewTextBoxColumn
            // 
            this.locationTripDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationTripDataGridViewTextBoxColumn.DataPropertyName = "Location_Trip";
            this.locationTripDataGridViewTextBoxColumn.HeaderText = "Địa Điểm Chuyến Đi";
            this.locationTripDataGridViewTextBoxColumn.Name = "locationTripDataGridViewTextBoxColumn";
            // 
            // onSaleDataGridViewTextBoxColumn
            // 
            this.onSaleDataGridViewTextBoxColumn.DataPropertyName = "OnSale";
            this.onSaleDataGridViewTextBoxColumn.HeaderText = "Tình Trạng Khuyến Mãi";
            this.onSaleDataGridViewTextBoxColumn.Name = "onSaleDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Số Lượng";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // priceTripDataGridViewTextBoxColumn
            // 
            this.priceTripDataGridViewTextBoxColumn.DataPropertyName = "Price_Trip";
            this.priceTripDataGridViewTextBoxColumn.HeaderText = "Giá Tiền";
            this.priceTripDataGridViewTextBoxColumn.Name = "priceTripDataGridViewTextBoxColumn";
            // 
            // portionBindingSource
            // 
            this.portionBindingSource.DataSource = typeof(QuanLyDuLich_Library.Models.Portion);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 557);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Trips:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 557);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Likes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(216, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Description:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(100, 472);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 9;
            // 
            // TotalLikeBox
            // 
            this.TotalLikeBox.Location = new System.Drawing.Point(100, 556);
            this.TotalLikeBox.Name = "TotalLikeBox";
            this.TotalLikeBox.Size = new System.Drawing.Size(100, 20);
            this.TotalLikeBox.TabIndex = 9;
            // 
            // TotalTripBox
            // 
            this.TotalTripBox.Location = new System.Drawing.Point(301, 556);
            this.TotalTripBox.Name = "TotalTripBox";
            this.TotalTripBox.Size = new System.Drawing.Size(100, 20);
            this.TotalTripBox.TabIndex = 9;
            // 
            // DesBox
            // 
            this.DesBox.Location = new System.Drawing.Point(301, 472);
            this.DesBox.Multiline = true;
            this.DesBox.Name = "DesBox";
            this.DesBox.Size = new System.Drawing.Size(331, 66);
            this.DesBox.TabIndex = 9;
            // 
            // PicClient
            // 
            this.PicClient.Location = new System.Drawing.Point(658, 98);
            this.PicClient.Name = "PicClient";
            this.PicClient.Size = new System.Drawing.Size(199, 340);
            this.PicClient.TabIndex = 10;
            this.PicClient.TabStop = false;
            // 
            // ShowAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(869, 610);
            this.Controls.Add(this.PicClient);
            this.Controls.Add(this.DesBox);
            this.Controls.Add(this.TotalTripBox);
            this.Controls.Add(this.TotalLikeBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowAgency";
            this.Text = "ShowAgency";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowAgency_FormClosing);
            this.Load += new System.EventHandler(this.ShowAgency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource portionBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox TotalLikeBox;
        private System.Windows.Forms.TextBox TotalTripBox;
        private System.Windows.Forms.TextBox DesBox;
        private System.Windows.Forms.PictureBox PicClient;
    }
}