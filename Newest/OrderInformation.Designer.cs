namespace Newest
{
    partial class OrderInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderInformation));
            this.label1 = new System.Windows.Forms.Label();
            this.TenKhach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TongThietHai = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.MailsKhack = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // TenKhach
            // 
            this.TenKhach.Location = new System.Drawing.Point(99, 32);
            this.TenKhach.Name = "TenKhach";
            this.TenKhach.Size = new System.Drawing.Size(138, 20);
            this.TenKhach.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "E-mails:";
            // 
            // TongThietHai
            // 
            this.TongThietHai.Location = new System.Drawing.Point(99, 159);
            this.TongThietHai.Name = "TongThietHai";
            this.TongThietHai.Size = new System.Drawing.Size(138, 20);
            this.TongThietHai.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tripDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.onSaleDataGridViewTextBoxColumn,
            this.agencyNameDataGridViewTextBoxColumn,
            this.locationTripDataGridViewTextBoxColumn,
            this.priceTripDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.portionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(243, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(621, 193);
            this.dataGridView1.TabIndex = 2;
            // 
            // tripDataGridViewTextBoxColumn
            // 
            this.tripDataGridViewTextBoxColumn.DataPropertyName = "Trip";
            this.tripDataGridViewTextBoxColumn.HeaderText = "Trip";
            this.tripDataGridViewTextBoxColumn.Name = "tripDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // onSaleDataGridViewTextBoxColumn
            // 
            this.onSaleDataGridViewTextBoxColumn.DataPropertyName = "OnSale";
            this.onSaleDataGridViewTextBoxColumn.HeaderText = "OnSale";
            this.onSaleDataGridViewTextBoxColumn.Name = "onSaleDataGridViewTextBoxColumn";
            // 
            // agencyNameDataGridViewTextBoxColumn
            // 
            this.agencyNameDataGridViewTextBoxColumn.DataPropertyName = "Agency_Name";
            this.agencyNameDataGridViewTextBoxColumn.HeaderText = "Agency_Name";
            this.agencyNameDataGridViewTextBoxColumn.Name = "agencyNameDataGridViewTextBoxColumn";
            // 
            // locationTripDataGridViewTextBoxColumn
            // 
            this.locationTripDataGridViewTextBoxColumn.DataPropertyName = "Location_Trip";
            this.locationTripDataGridViewTextBoxColumn.HeaderText = "Location_Trip";
            this.locationTripDataGridViewTextBoxColumn.Name = "locationTripDataGridViewTextBoxColumn";
            // 
            // priceTripDataGridViewTextBoxColumn
            // 
            this.priceTripDataGridViewTextBoxColumn.DataPropertyName = "Price_Trip";
            this.priceTripDataGridViewTextBoxColumn.HeaderText = "Price_Trip";
            this.priceTripDataGridViewTextBoxColumn.Name = "priceTripDataGridViewTextBoxColumn";
            // 
            // portionBindingSource
            // 
            this.portionBindingSource.DataSource = typeof(QuanLyDuLich_Library.Models.Portion);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Price:";
            // 
            // MailsKhack
            // 
            this.MailsKhack.Location = new System.Drawing.Point(99, 94);
            this.MailsKhack.Name = "MailsKhack";
            this.MailsKhack.Size = new System.Drawing.Size(138, 20);
            this.MailsKhack.TabIndex = 1;
            // 
            // OrderInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(873, 218);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MailsKhack);
            this.Controls.Add(this.TongThietHai);
            this.Controls.Add(this.TenKhach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderInformation";
            this.Text = "The Order Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderInformation_FormClosing);
            this.Load += new System.EventHandler(this.OrderInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TenKhach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TongThietHai;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource portionBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MailsKhack;
    }
}