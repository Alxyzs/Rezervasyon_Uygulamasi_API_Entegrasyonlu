namespace ReservationApiUygulamasi.UI
{
    partial class FrmSelection
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
            this.btnGetReservation = new System.Windows.Forms.Button();
            this.btnRemoveReservation = new System.Windows.Forms.Button();
            this.dvgCurrentReservations = new System.Windows.Forms.DataGridView();
            this.lblCurrentReservations = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCurrentReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetReservation
            // 
            this.btnGetReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGetReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetReservation.ForeColor = System.Drawing.Color.White;
            this.btnGetReservation.Location = new System.Drawing.Point(363, 368);
            this.btnGetReservation.Name = "btnGetReservation";
            this.btnGetReservation.Size = new System.Drawing.Size(333, 74);
            this.btnGetReservation.TabIndex = 0;
            this.btnGetReservation.Text = "REZERVASYON AL";
            this.btnGetReservation.UseVisualStyleBackColor = false;
            this.btnGetReservation.Click += new System.EventHandler(this.btnGetReservation_Click);
            // 
            // btnRemoveReservation
            // 
            this.btnRemoveReservation.BackColor = System.Drawing.Color.Salmon;
            this.btnRemoveReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRemoveReservation.ForeColor = System.Drawing.Color.White;
            this.btnRemoveReservation.Location = new System.Drawing.Point(363, 448);
            this.btnRemoveReservation.Name = "btnRemoveReservation";
            this.btnRemoveReservation.Size = new System.Drawing.Size(333, 74);
            this.btnRemoveReservation.TabIndex = 1;
            this.btnRemoveReservation.Text = "REZERVASYON İPTAL ET";
            this.btnRemoveReservation.UseVisualStyleBackColor = false;
            this.btnRemoveReservation.Click += new System.EventHandler(this.btnRemoveReservation_Click);
            // 
            // dvgCurrentReservations
            // 
            this.dvgCurrentReservations.AllowUserToAddRows = false;
            this.dvgCurrentReservations.AllowUserToDeleteRows = false;
            this.dvgCurrentReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgCurrentReservations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgCurrentReservations.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dvgCurrentReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCurrentReservations.Location = new System.Drawing.Point(62, 42);
            this.dvgCurrentReservations.Name = "dvgCurrentReservations";
            this.dvgCurrentReservations.ReadOnly = true;
            this.dvgCurrentReservations.Size = new System.Drawing.Size(926, 307);
            this.dvgCurrentReservations.TabIndex = 2;
            // 
            // lblCurrentReservations
            // 
            this.lblCurrentReservations.AutoSize = true;
            this.lblCurrentReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentReservations.ForeColor = System.Drawing.Color.White;
            this.lblCurrentReservations.Location = new System.Drawing.Point(358, 9);
            this.lblCurrentReservations.Name = "lblCurrentReservations";
            this.lblCurrentReservations.Size = new System.Drawing.Size(338, 26);
            this.lblCurrentReservations.TabIndex = 3;
            this.lblCurrentReservations.Text = "Şuanki Aktif Rezervasyonlarım";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Salmon;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 463);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(159, 58);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "ÇIKIŞ";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1068, 533);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCurrentReservations);
            this.Controls.Add(this.dvgCurrentReservations);
            this.Controls.Add(this.btnRemoveReservation);
            this.Controls.Add(this.btnGetReservation);
            this.Name = "FrmSelection";
            this.Text = "Rezervasyon İşlemleri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSelection_FormClosing);
            this.Load += new System.EventHandler(this.FrmSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCurrentReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetReservation;
        private System.Windows.Forms.Button btnRemoveReservation;
        private System.Windows.Forms.DataGridView dvgCurrentReservations;
        private System.Windows.Forms.Label lblCurrentReservations;
        private System.Windows.Forms.Button btnExit;
    }
}