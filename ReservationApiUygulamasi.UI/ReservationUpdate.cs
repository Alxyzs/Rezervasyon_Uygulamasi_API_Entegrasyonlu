using Newtonsoft.Json;
using ReservationApiUygulamasi.UI.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationApiUygulamasi.UI
{
    public partial class ReservationUpdate : Form
    {
        public ReservationUpdate()
        {
            InitializeComponent();
        }

        private async void ReservationUpdate_Load(object sender, EventArgs e)
        {
            await LoadUserReservationsAsync();
            dvgCurrentReservations.Columns["Id"].Visible = false;
            dvgCurrentReservations.Columns["userID"].Visible = false;
            dvgCurrentReservations.Columns["rowVersion"].Visible = false;
            dvgCurrentReservations.Columns["productRef"].Visible = false;
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

                    dvgCurrentReservations.DataSource =
                        new BindingList<Reservation>(filteredReservations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar alınamadı: " + ex.Message);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmSelection frm = new FrmSelection();
            frm.Show();
            this.Hide();
        }

        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgCurrentReservations.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen Güncellenecek Malzeme Seçiniz...");
                    return;
                }

                int UserID = CurrentUser.UserID;
                var selectedProduct = (ProductDto)dvgCurrentReservations.CurrentRow.DataBoundItem;
                int MalzemKodu = Convert.ToInt32(txtproductRef.Text);
                string Notes = txtNotes.Text;
                double miktar = selectedProduct.StockQuantity;

            }
            catch { }

        }

        private void dvgCurrentReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgCurrentReservations.Rows[e.RowIndex];

                txtUrunAdi.Text = row.Cells["KitapId"].Value?.ToString() ?? "";
                txtUrunNumarasi.Text = row.Cells["Ad"].Value?.ToString() ?? "";
                //devamı gelecek...
            }
        }
    }
}
