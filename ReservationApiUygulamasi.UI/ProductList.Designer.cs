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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReserveSelected
            // 
            this.btnReserveSelected.Location = new System.Drawing.Point(513, 39);
            this.btnReserveSelected.Name = "btnReserveSelected";
            this.btnReserveSelected.Size = new System.Drawing.Size(275, 23);
            this.btnReserveSelected.TabIndex = 0;
            this.btnReserveSelected.Text = "Seçili Ürünü Rezerve Et";
            this.btnReserveSelected.UseVisualStyleBackColor = true;
            this.btnReserveSelected.Click += new System.EventHandler(this.btnReserveSelected_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(76, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgv_Data
            // 
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Location = new System.Drawing.Point(98, 106);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.Size = new System.Drawing.Size(592, 270);
            this.dgv_Data.TabIndex = 2;
            this.dgv_Data.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellContentDoubleClick);
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Data);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReserveSelected);
            this.Name = "ProductList";
            this.Text = "ProductList";
            this.Load += new System.EventHandler(this.ProductList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReserveSelected;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv_Data;
    }
}