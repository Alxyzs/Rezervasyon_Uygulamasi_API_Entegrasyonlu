using Newtonsoft.Json;
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
    public partial class frmReservationCancel : Form
    {
        public frmReservationCancel()
        {
            InitializeComponent();
        }
        private async void frmReservationCancel_Load(object sender, EventArgs e)
        {
            await LoadUserReservationsAsync();
            dvgCurrentReservationCancel.Columns["Id"].Visible = false;
            dvgCurrentReservationCancel.Columns["userID"].Visible = false;
            dvgCurrentReservationCancel.Columns["rowVersion"].Visible = false;
            dvgCurrentReservationCancel.Columns["productRef"].Visible = false;
        }

        private HttpClientHandler GetSSL()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };
        }
        // Form seviyesinde tanımlayın
        private List<dynamic> _originalReservations = new List<dynamic>();

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
                    httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationHelper.GetToken());

                    HttpResponseMessage response = await httpClient.GetAsync("api/Reservations");
                    response.EnsureSuccessStatusCode();

                    string responseString = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ApiResponse<Reservation>>(responseString);

                    if (result == null || !result.success)
                    {
                        MessageBox.Show("API'den veri alınamadı: " + result?.message);
                        return;
                    }

                    var allReservations = result.data;

                    var filteredReservations = allReservations
                        .Where(r => r.userID == currentUserId)
                        .ToList();

                    dvgCurrentReservationCancel.DataSource = new BindingList<Reservation>(filteredReservations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar alınamadı: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                dvgCurrentReservationCancel.DataSource = new BindingList<dynamic>(_originalReservations);
            }
            else
            {
                var filtered = _originalReservations
                    .Where(p =>
                        (p.productRef != null && p.productRef.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (p.reservedQty != null && p.reservedQty.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (p.notes != null && p.notes.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    )
                    .ToList();

                dvgCurrentReservationCancel.DataSource = new BindingList<dynamic>(filtered);
            }
        }

        private async void btnReservationCancel_Click(object sender, EventArgs e)
        {
            FrmLoading loading = new FrmLoading();
            loading.Show();

            try
            {
                if (dvgCurrentReservationCancel.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen bir rezervasyon seçin.");
                    return;
                }


                else
                {
                    var selectedRow = dvgCurrentReservationCancel.SelectedRows[0];
                    int reservationId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                    string rowVersion = selectedRow.Cells["rowVersion"].Value.ToString();

                    using (HttpClient httpClient = new HttpClient())
                    {
                        var apiSettings = ConfigurationHelper.LoadApiSettings();
                        httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);
                        httpClient.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);

                        httpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue(
                                "Bearer",
                                ConfigurationHelper.GetToken());

                        httpClient.DefaultRequestHeaders.Add("rowVersion", rowVersion);

                        HttpResponseMessage response = await httpClient.DeleteAsync($"api/Reservations/{reservationId}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Rezervasyon silindi.");
                            await LoadUserReservationsAsync();
                        }
                        if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
                        {

                            var result = MessageBox.Show("Rezervasyonu silmek istiyor musunuz?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                HttpResponseMessage responce = await httpClient.DeleteAsync($"api/Reservations/{reservationId}/force");
                                await LoadUserReservationsAsync();
                            }
                            else return;
                        }
                        else
                        {
                            string error = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Silme hatası: " + error);
    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                loading.Close();
            }
        }


        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmSelection frm = new FrmSelection();
            frm.Show();
            this.Hide();
        }

        private void frmReservationCancel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
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
