namespace Newest
{
    partial class SeeOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeOrders));
            this.NameForClient = new System.Windows.Forms.TextBox();
            this.EmailsForClient = new System.Windows.Forms.TextBox();
            this.BigMoney = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.agencyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // NameForClient
            // 
            this.NameForClient.Location = new System.Drawing.Point(93, 45);
            this.NameForClient.Name = "NameForClient";
            this.NameForClient.Size = new System.Drawing.Size(115, 20);
            this.NameForClient.TabIndex = 0;
            // 
            // EmailsForClient
            // 
            this.EmailsForClient.Location = new System.Drawing.Point(93, 109);
            this.EmailsForClient.Name = "EmailsForClient";
            this.EmailsForClient.Size = new System.Drawing.Size(115, 20);
            this.EmailsForClient.TabIndex = 0;
            // 
            // BigMoney
            // 
            this.BigMoney.Location = new System.Drawing.Point(93, 165);
            this.BigMoney.Name = "BigMoney";
            this.BigMoney.Size = new System.Drawing.Size(115, 20);
            this.BigMoney.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.agencyNameDataGridViewTextBoxColumn,
            this.locationTripDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.onSaleDataGridViewTextBoxColumn,
            this.priceTripDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.portionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(313, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(551, 185);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // agencyNameDataGridViewTextBoxColumn
            // 
            this.agencyNameDataGridViewTextBoxColumn.DataPropertyName = "Agency_Name";
            this.agencyNameDataGridViewTextBoxColumn.HeaderText = "Agency_Name";
            this.agencyNameDataGridViewTextBoxColumn.Name = "agencyNameDataGridViewTextBoxColumn";
            // 
            // locationTripDataGridViewTextBoxColumn
            // 
            this.locationTripDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationTripDataGridViewTextBoxColumn.DataPropertyName = "Location_Trip";
            this.locationTripDataGridViewTextBoxColumn.HeaderText = "Location_Trip";
            this.locationTripDataGridViewTextBoxColumn.Name = "locationTripDataGridViewTextBoxColumn";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(219, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Portion of trip:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-Mails:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total price:";
            // 
            // SeeOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(876, 240);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BigMoney);
            this.Controls.Add(this.EmailsForClient);
            this.Controls.Add(this.NameForClient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeeOrders";
            this.Text = "SeeOrders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeeOrders_FormClosing);
            this.Load += new System.EventHandler(this.SeeOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameForClient;
        private System.Windows.Forms.TextBox EmailsForClient;
        private System.Windows.Forms.TextBox BigMoney;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource portionBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTripDataGridViewTextBoxColumn;
    }
}