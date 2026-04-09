namespace ReservationApiUygulamasi.UI
{
    partial class frmReservationCancel
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
            this.dvgCurrentReservationCancel = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReservationCancel = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCurrentReservationCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgCurrentReservationCancel
            // 
            this.dvgCurrentReservationCancel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgCurrentReservationCancel.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dvgCurrentReservationCancel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCurrentReservationCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dvgCurrentReservationCancel.Location = new System.Drawing.Point(12, 12);
            this.dvgCurrentReservationCancel.Name = "dvgCurrentReservationCancel";
            this.dvgCurrentReservationCancel.Size = new System.Drawing.Size(776, 270);
            this.dvgCurrentReservationCancel.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(224, 330);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(51, 20);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "ARA:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(290, 330);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnReservationCancel
            // 
            this.btnReservationCancel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReservationCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservationCancel.FlatAppearance.BorderSize = 0;
            this.btnReservationCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
            this.btnReservationCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReservationCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservationCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReservationCancel.ForeColor = System.Drawing.Color.White;
            this.btnReservationCancel.Location = new System.Drawing.Point(228, 380);
            this.btnReservationCancel.Name = "btnReservationCancel";
            this.btnReservationCancel.Size = new System.Drawing.Size(332, 42);
            this.btnReservationCancel.TabIndex = 6;
            this.btnReservationCancel.Text = "Seçili Ürünün Rezervasyonunu İptal Et";
            this.btnReservationCancel.UseVisualStyleBackColor = false;
            this.btnReservationCancel.Click += new System.EventHandler(this.btnReservationCancel_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Salmon;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoBack.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.Location = new System.Drawing.Point(12, 380);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(159, 58);
            this.btnGoBack.TabIndex = 9;
            this.btnGoBack.Text = "GERİ DÖN";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // frmReservationCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnReservationCancel);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dvgCurrentReservationCancel);
            this.Name = "frmReservationCancel";
            this.Text = "frmReservationCancel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReservationCancel_FormClosing);
            this.Load += new System.EventHandler(this.frmReservationCancel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCurrentReservationCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgCurrentReservationCancel;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReservationCancel;
        private System.Windows.Forms.Button btnGoBack;
    }
}