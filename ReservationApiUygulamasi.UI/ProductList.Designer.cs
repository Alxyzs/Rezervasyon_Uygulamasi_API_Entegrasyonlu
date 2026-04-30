namespace ReservationApiUygulamasi.UI
{
    partial class ProductList
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
            this.btnReserveSelected = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtproductRef = new System.Windows.Forms.TextBox();
            this.txtstockQuantity = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.lnlNot = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReserveSelected
            // 
            this.btnReserveSelected.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReserveSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReserveSelected.FlatAppearance.BorderSize = 0;
            this.btnReserveSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
            this.btnReserveSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReserveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserveSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReserveSelected.ForeColor = System.Drawing.Color.White;
            this.btnReserveSelected.Location = new System.Drawing.Point(239, 387);
            this.btnReserveSelected.Name = "btnReserveSelected";
            this.btnReserveSelected.Size = new System.Drawing.Size(332, 42);
            this.btnReserveSelected.TabIndex = 0;
            this.btnReserveSelected.Text = "Seçili Ürünü Rezerve Et";
            this.btnReserveSelected.UseVisualStyleBackColor = false;
            this.btnReserveSelected.Click += new System.EventHandler(this.btnReserveSelected_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(301, 312);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_Data.Location = new System.Drawing.Point(12, 18);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.ReadOnly = true;
            this.dgv_Data.Size = new System.Drawing.Size(776, 270);
            this.dgv_Data.TabIndex = 2;
            this.dgv_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(235, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ARA:";
            // 
            // txtproductRef
            // 
            this.txtproductRef.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtproductRef.Location = new System.Drawing.Point(55, 312);
            this.txtproductRef.Name = "txtproductRef";
            this.txtproductRef.Size = new System.Drawing.Size(100, 20);
            this.txtproductRef.TabIndex = 4;
            this.txtproductRef.Visible = false;
            // 
            // txtstockQuantity
            // 
            this.txtstockQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtstockQuantity.Location = new System.Drawing.Point(55, 339);
            this.txtstockQuantity.Name = "txtstockQuantity";
            this.txtstockQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtstockQuantity.TabIndex = 5;
            this.txtstockQuantity.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(604, 240);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(183, 48);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.Text = "";
            this.txtNotes.Visible = false;
            // 
            // lnlNot
            // 
            this.lnlNot.AutoSize = true;
            this.lnlNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lnlNot.ForeColor = System.Drawing.Color.White;
            this.lnlNot.Location = new System.Drawing.Point(494, 240);
            this.lnlNot.Name = "lnlNot";
            this.lnlNot.Size = new System.Drawing.Size(49, 20);
            this.lnlNot.TabIndex = 7;
            this.lnlNot.Text = "NOT:";
            this.lnlNot.Visible = false;
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Salmon;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoBack.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.Location = new System.Drawing.Point(12, 387);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(159, 58);
            this.btnGoBack.TabIndex = 8;
            this.btnGoBack.Text = "GERİ DÖN";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(218, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Miktar :";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(301, 339);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(126, 20);
            this.txtMiktar.TabIndex = 9;
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(799, 447);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.dgv_Data);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lnlNot);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtstockQuantity);
            this.Controls.Add(this.txtproductRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReserveSelected);
            this.Name = "ProductList";
            this.Text = "Rezervasyon İşlemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductList_FormClosing);
            this.Load += new System.EventHandler(this.ProductList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReserveSelected;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtproductRef;
        private System.Windows.Forms.TextBox txtstockQuantity;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label lnlNot;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMiktar;
    }
}