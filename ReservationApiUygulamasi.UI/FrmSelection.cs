using ReservationApiUygulamasi.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationApiUygulamasi.UI
{
    public partial class FrmSelection : Form
    {
        private async void FrmSelection_Load(object sender, EventArgs e)
        {
            await LoadUserReservationsAsync();
            dvgCurrentReservations.Columns["Id"].Visible = false;
            dvgCurrentReservations.Columns["userID"].Visible = false;
        }
        private async Task LoadUserReservationsAsync()
        {
            try
            {
                int currentUserId = CurrentUser.UserID;

                if (currentUserId <= 0)
                {
                    MessageBox.Show("Geçerli kullanıcı bilgisi bulunamadı.");
                    Login frm = new Login();
                    this.Hide();
                    frm.Show();
                    return;
                }

                using (HttpClient httpClient = new HttpClient())
                {
                    var apiSettings = ConfigurationHelper.LoadApiSettings();
                    httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);
                    httpClient.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationHelper.GetToken());

                    HttpResponseMessage response = await httpClient.GetAsync("api/Reservations");
                    response.EnsureSuccessStatusCode();

                    string responseString = await response.Content.ReadAsStringAsync();
                    var allReservations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(responseString);

                    var filteredReservations = allReservations.Where(r => r.userID != null && Convert.ToInt32(r.userID) == currentUserId).ToList();


                    dvgCurrentReservations.DataSource = new BindingList<dynamic>(filteredReservations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar alınamadı: " + ex.Message);
            }
        }




        //private async void LoadReservations()
        //{
        //    try
        //    {
        //        int userId = CurrentUser.UserID;

        //        using (HttpClient httpClient = new HttpClient())
        //        {
        //            // API ayarlarını yükle
        //            var apiSettings = ConfigurationHelper.LoadApiSettings();
        //            httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);
        //            httpClient.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);

        //            // Token ekle
        //            httpClient.DefaultRequestHeaders.Authorization =
        //                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationHelper.GetToken());

        //            // API'den rezervasyonları çek
        //            HttpResponseMessage response = await httpClient.GetAsync("api/Reservations");
        //            response.EnsureSuccessStatusCode();

        //            string responseString = await response.Content.ReadAsStringAsync();

        //            // JSON'u listeye dönüştür
        //            List<Reservation> allReservations = JsonConvert.DeserializeObject<List<Reservation>>(responseString);

        //            // Kullanıcıya ait rezervasyonları filtrele
        //            var filteredReservations = allReservations
        //                .Where(r => r.UserID == userId)
        //                .ToList();

        //            // DataGrid'e yükle
        //            dvgCurrentReservations.DataSource = new BindingList<Reservation>(filteredReservations);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Rezervasyonlar alınamadı: " + ex.Message);
        //    }
        //}



        public FrmSelection()
        {
            InitializeComponent();
        }

        private void btnGetReservation_Click(object sender, EventArgs e)
        {
            ProductList frm = new ProductList();
            frm.Show();
            this.Hide();
        }

        private void btnRemoveReservation_Click(object sender, EventArgs e)
        {
            frmReservationCancel frm = new frmReservationCancel();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void FrmSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // sadece X tuşu
            {
                var result = MessageBox.Show
                (
                    "Uygulamadan çıkmak istediğinizden emin misiniz?",
                    "Çıkış Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
