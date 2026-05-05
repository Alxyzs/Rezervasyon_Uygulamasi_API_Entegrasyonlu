using Newtonsoft.Json;
using ReservationApiUygulamasi.UI.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        private async void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            FrmLoading loading = new FrmLoading();
            loading.Show();
            if (!int.TryParse(txtUrunID.Text, out int id) || !double.TryParse(txtstockQty.Text, out double qty))
            {
                MessageBox.Show("URUN SECİNİZ");
                return;
            }
            try
            {
                var dto = new Reservation
                {
                    id = id,
                    userID = Convert.ToInt32(txtUserID.Text),
                    reservedQty = qty,
                    notes = txtNotes.Text,
                    productRef = Convert.ToInt32(txtproductRef.Text),
                    rowVersion = txtRowVersion.Text
                };

                using (var client = new HttpClient())
                {
                    var apiSettings = ConfigurationHelper.LoadApiSettings();
                    client.BaseAddress = new Uri(apiSettings.BaseUrl);

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationHelper.LoadAppSettings().Token);


                    var json = JsonConvert.SerializeObject(dto);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync("api/Reservations", content);

                    if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        MessageBox.Show("Bu kayıt zaten Güncellendi veya işlem çakıştı .\n Lütfen Sayfayı yenileyin !");
                        await LoadUserReservationsAsync();
                        return;
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Başarılı");
                        await LoadUserReservationsAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                loading.Close();
            }

        }

        private void dvgCurrentReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgCurrentReservations.Rows[e.RowIndex];

                txtRowVersion.Text = row.Cells["rowVersion"].Value?.ToString() ?? "";
                txtstockQty.Text = row.Cells["reservedQty"].Value?.ToString() ?? "";
                txtNotes.Text = row.Cells["Notes"].Value?.ToString() ?? "";
                txtUrunID.Text = row.Cells["Id"].Value?.ToString() ?? "";
                txtUserID.Text = row.Cells["userID"].Value?.ToString() ?? "";
                txtproductRef.Text = row.Cells["productRef"].Value?.ToString() ?? "";
            }
        }
    }
}
