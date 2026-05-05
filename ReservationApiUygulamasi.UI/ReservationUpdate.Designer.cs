namespace ReservationApiUygulamasi.UI
{
    partial class ReservationUpdate
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
            this.dvgCurrentReservations = new System.Windows.Forms.DataGridView();
            this.lblCurrentReservations = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.txtUrunID = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRowVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtstockQty = new System.Windows.Forms.TextBox();
            this.btnUpdateReservation = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtproductRef = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCurrentReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgCurrentReservations
            // 
            this.dvgCurrentReservations.AllowUserToAddRows = false;
            this.dvgCurrentReservations.AllowUserToDeleteRows = false;
            this.dvgCurrentReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgCurrentReservations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgCurrentReservations.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dvgCurrentReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCurrentReservations.Location = new System.Drawing.Point(29, 47);
            this.dvgCurrentReservations.Name = "dvgCurrentReservations";
            this.dvgCurrentReservations.ReadOnly = true;
            this.dvgCurrentReservations.Size = new System.Drawing.Size(620, 343);
            this.dvgCurrentReservations.TabIndex = 3;
            this.dvgCurrentReservations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCurrentReservations_CellClick);
            // 
            // lblCurrentReservations
            // 
            this.lblCurrentReservations.AutoSize = true;
            this.lblCurrentReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentReservations.ForeColor = System.Drawing.Color.White;
            this.lblCurrentReservations.Location = new System.Drawing.Point(24, 9);
            this.lblCurrentReservations.Name = "lblCurrentReservations";
            this.lblCurrentReservations.Size = new System.Drawing.Size(382, 26);
            this.lblCurrentReservations.TabIndex = 5;
            this.lblCurrentReservations.Text = "Rezervasyon Güncelleme İşlemleri";
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Salmon;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoBack.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.Location = new System.Drawing.Point(12, 435);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(159, 58);
            this.btnGoBack.TabIndex = 9;
            this.btnGoBack.Text = "GERİ DÖN";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // txtUrunID
            // 
            this.txtUrunID.Location = new System.Drawing.Point(701, 85);
            this.txtUrunID.Name = "txtUrunID";
            this.txtUrunID.ReadOnly = true;
            this.txtUrunID.Size = new System.Drawing.Size(256, 20);
            this.txtUrunID.TabIndex = 10;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(795, 65);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(68, 17);
            this.lblUsername.TabIndex = 17;
            this.lblUsername.Text = "Ürün ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(787, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "RowVersion";
            this.label1.Visible = false;
            // 
            // txtRowVersion
            // 
            this.txtRowVersion.Location = new System.Drawing.Point(701, 29);
            this.txtRowVersion.Name = "txtRowVersion";
            this.txtRowVersion.ReadOnly = true;
            this.txtRowVersion.Size = new System.Drawing.Size(256, 20);
            this.txtRowVersion.TabIndex = 18;
            this.txtRowVersion.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(790, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ürün Adeti:";
            // 
            // txtstockQty
            // 
            this.txtstockQty.Location = new System.Drawing.Point(704, 143);
            this.txtstockQty.Name = "txtstockQty";
            this.txtstockQty.Size = new System.Drawing.Size(256, 20);
            this.txtstockQty.TabIndex = 20;
            // 
            // btnUpdateReservation
            // 
            this.btnUpdateReservation.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdateReservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateReservation.FlatAppearance.BorderSize = 0;
            this.btnUpdateReservation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
            this.btnUpdateReservation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdateReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateReservation.ForeColor = System.Drawing.Color.White;
            this.btnUpdateReservation.Location = new System.Drawing.Point(667, 298);
            this.btnUpdateReservation.Name = "btnUpdateReservation";
            this.btnUpdateReservation.Size = new System.Drawing.Size(332, 42);
            this.btnUpdateReservation.TabIndex = 26;
            this.btnUpdateReservation.Text = "Güncelle";
            this.btnUpdateReservation.UseVisualStyleBackColor = false;
            this.btnUpdateReservation.Click += new System.EventHandler(this.btnUpdateReservation_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUserID.Location = new System.Drawing.Point(12, 396);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 27;
            this.txtUserID.Visible = false;
            // 
            // txtproductRef
            // 
            this.txtproductRef.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtproductRef.Location = new System.Drawing.Point(127, 396);
            this.txtproductRef.Name = "txtproductRef";
            this.txtproductRef.Size = new System.Drawing.Size(100, 20);
            this.txtproductRef.TabIndex = 28;
            this.txtproductRef.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(704, 196);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(256, 85);
            this.txtNotes.TabIndex = 29;
            this.txtNotes.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(813, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Not:";
            // 
            // ReservationUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1008, 505);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtproductRef);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnUpdateReservation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtstockQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRowVersion);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUrunID);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblCurrentReservations);
            this.Controls.Add(this.dvgCurrentReservations);
            this.Name = "ReservationUpdate";
            this.Text = "ReservationUpdate";
            this.Load += new System.EventHandler(this.ReservationUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCurrentReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgCurrentReservations;
        private System.Windows.Forms.Label lblCurrentReservations;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtstockQty;
        private System.Windows.Forms.Button btnUpdateReservation;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtproductRef;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUrunID;
        private System.Windows.Forms.Label lblUsername;
    }
}