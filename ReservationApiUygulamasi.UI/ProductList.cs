using ReservationApiUygulamasi.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Drawing;
using Microsoft.AspNetCore.SignalR.Client;
using System.Security.Cryptography;


namespace ReservationApiUygulamasi.UI
{
    public partial class ProductList : Form
    {
        private HttpClient _client;
        private List<ProductDto> _products;

        public ProductList()
        {
            InitializeComponent();
            InitializeHttpClient();
        }

        HubConnection connection;

        private void InitializeHttpClient()
        {
            var apiSettings = ConfigurationHelper.LoadApiSettings();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };

            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(apiSettings.BaseUrl),
                Timeout = TimeSpan.FromSeconds(apiSettings.Timeout)
            };

            var token = ConfigurationHelper.LoadAppSettings().Token;
            if (!string.IsNullOrWhiteSpace(token))
            {
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
        private HttpClientHandler GetSSL()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };
        }

        private async void ProductList_Load(object sender, EventArgs e)
        {

            var apiSettings = ConfigurationHelper.LoadApiSettings();
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, sslErrors) => true
            };

            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(apiSettings.BaseUrl),
                Timeout = TimeSpan.FromSeconds(apiSettings.Timeout) 
            };

            connection = new HubConnectionBuilder().WithUrl(new Uri(_client.BaseAddress, "stockHubs")).WithAutomaticReconnect().Build();
            //connection = new HubConnectionBuilder().WithUrl("http://192.168.1.90:5003/stockHubs").WithAutomaticReconnect().Build();

            //SignalRHub'dan sinyal gelince otomatik datagrid refreshler.
            connection.On<StockUpdateDto>("UpdateStocks", (data) =>
            {
                Invoke((MethodInvoker)async delegate
                {
                    await LoadProductsFromApi();
                });
            });

            await connection.StartAsync();
            //SignalR Hub

            await LoadProductsFromApi();

            dgv_Data.Columns["id"].Visible = false;
            dgv_Data.Columns["unitRef"].Visible = false;
            dgv_Data.Columns["whNumber"].Visible = false;
        }

        private async Task LoadProductsFromApi()
        {
            try
            {
                var apiSettings = ConfigurationHelper.LoadApiSettings();
                var token = ConfigurationHelper.LoadAppSettings().Token;

                using (var client = new HttpClient(GetSSL()))
                {
                    client.BaseAddress = new Uri(apiSettings.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);

                    if (!string.IsNullOrWhiteSpace(token))
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    //#RestSharp Nuget package'dan indirilebilir.


                    var response = await client.GetAsync("api/Products");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        _products = JsonConvert.DeserializeObject<List<ProductDto>>(json);

                        dgv_Data.DataSource = null;
                        dgv_Data.DataSource = _products;

                        foreach (DataGridViewRow row in dgv_Data.Rows)
                        {
                            if (row.Cells["StockQuantity"].Value != null)
                            {
                                int stock = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                                var cell = row.Cells["StockStatus"];
                                if(stock == 0)
                                {
                                    cell.Value = "Kalmadı";
                                    cell.Style.BackColor = Color.Black;
                                    cell.Style.ForeColor = Color.White;
                                }
                                else if (stock < 10)
                                {
                                    cell.Value = "Az";
                                    cell.Style.BackColor = Color.Red;
                                    cell.Style.ForeColor = Color.White;
                                }
                                else if (stock < 50)
                                {
                                    cell.Value = "Orta";
                                    cell.Style.BackColor = Color.Orange;
                                    cell.Style.ForeColor = Color.Black;
                                }
                                else
                                {
                                    cell.Value = "Fazla";
                                    cell.Style.BackColor = Color.Green;
                                    cell.Style.ForeColor = Color.White;
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Ürünler alınamadı: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            var filtered = _products
                .Where(p => p.ProductName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                         || p.ProductCode.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            dgv_Data.DataSource = null;
            dgv_Data.DataSource = filtered;
            dgv_Data.Columns["id"].Visible = false;
        }


        private async void btnReserveSelected_Click(object sender, EventArgs e)
        {
            FrmLoading loading = new FrmLoading();
            loading.Show();
            try
            {

                if (dgv_Data.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen Malzeme Seçiniz...");
                    return;
                }

                int UserID = CurrentUser.UserID;
                var selectedProduct = (ProductDto)dgv_Data.CurrentRow.DataBoundItem;
                int MalzemKodu = Convert.ToInt32(txtproductRef.Text);
                string Notes = txtNotes.Text;
                double miktar = selectedProduct.StockQuantity;

                bool success = await SendReservationToApi(UserID, MalzemKodu, Notes, miktar);
                MessageBox.Show(success ? "Rezervasyon alınmıştır." : "Rezervasyon gönderilemedi.");
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

        void AuthorizeOtomatik()
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigurationHelper.LoadAppSettings().Token);
        }

        private async Task<bool> SendReservationToApi(int UserID, int MalzemeInt, string Note, double quantity)
        {
            if (_client == null) throw new InvalidOperationException("_client henüz oluşturulmamış.");

            var data = new
            {
                UserID,
                ProductRef = MalzemeInt,
                Notes = Note,
                ReservedQty = quantity,
                date = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                AuthorizeOtomatik();
                var response = await _client.PostAsync("api/Reservations", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var errors = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(errorContent);

                        if (errors != null && errors.Any())
                        {
                            var allErrors = string.Join(Environment.NewLine , errors.SelectMany(e => e.Value.Select(msg => $"{e.Key}: {msg}")));

                            MessageBox.Show(allErrors, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(errorContent + "\nCode: " + response.StatusCode, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show(errorContent + "\nCode: " + response.StatusCode, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("API hatası: " + ex.Message, "API Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void dgv_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                txtproductRef.Text = dgv_Data.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNotes.Text = dgv_Data.Rows[e.RowIndex].Cells["productName"].Value.ToString();
                txtstockQuantity.Text = dgv_Data.Rows[e.RowIndex].Cells["StockQuantity"].Value.ToString();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmSelection frm = new FrmSelection();
            frm.Show();
            this.Hide();
        }

        private void ProductList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
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

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}