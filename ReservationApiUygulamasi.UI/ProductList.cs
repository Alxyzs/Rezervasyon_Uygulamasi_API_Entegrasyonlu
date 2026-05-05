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
using System.ComponentModel;

namespace ReservationApiUygulamasi.UI
{
    public partial class ProductList : Form
    {
        private HttpClient _client;

        private BindingList<ProductDto> _products;

        private BindingSource _bs = new BindingSource();

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
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        private HttpClientHandler GetSSL()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };
        }
        private bool messageShown = false;

        private void ShowUpdateMessage()
        {
            if (!messageShown)
            {
                MessageBox.Show("Kırmızı olan satırlar güncellenmiştir.");
                messageShown = true;
            }
        }

        private async void GreenFadeRowColor(DataGridViewRow row)
        {
            Color startColor = row.DefaultCellStyle.BackColor;

            int steps = 20;

            for (int i = 0; i < steps; i++)
            {
                await Task.Delay(100);

                int r = startColor.R + (255 - startColor.R) * i / steps;
                int g = startColor.G + (255 - startColor.G) * i / steps;
                int b = startColor.B + (255 - startColor.B) * i / steps;

                row.DefaultCellStyle.BackColor = Color.FromArgb(r, g, b);
            }

            row.DefaultCellStyle.BackColor = Color.White;
        }
        private async void RedFadeRowColor(DataGridViewRow row)
        {
            int steps = 20;

            for (int i = 0; i < steps; i++)
            {
                await Task.Delay(100);

                int r = 255;
                int g = 255 - (i * 10);
                int b = 255 - (i * 10);

                row.DefaultCellStyle.BackColor = Color.FromArgb(r, g, b);
            }

            row.DefaultCellStyle.BackColor = Color.White;
        }

        private void ReducedUpdateRow(SignalRDto data)
        {
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                if (row.Cells["Id"].Value.ToString() == data.Product.ToString()
                    && Convert.ToInt32(row.Cells["WhNumber"].Value) == CurrentUser.WhNumber)
                {
                    double currentStock = Convert.ToDouble(row.Cells["stockQuantity"].Value);
                    double newStock = currentStock - data.Quantity;

                    row.Cells["stockQuantity"].Value = newStock;

                    if (newStock > currentStock)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        GreenFadeRowColor(row);
                    }
                    else if (newStock < currentStock)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        RedFadeRowColor(row);
                    }

                    ShowUpdateMessage();

                    break;
                }
            }
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
            connection.On<SignalRDto>("UpdateStocks", (data) =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    ReducedUpdateRow(data);
                }));
            });

            await connection.StartAsync();

            await LoadProductsFromApi();

            dgv_Data.Columns["id"].Visible = false;
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
                        client.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var response = await client.GetAsync("api/Products");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<ProductDto>>(json);

                        _products = new BindingList<ProductDto>(list);

                        _bs.DataSource = _products;

                        dgv_Data.DataSource = _bs;
                        dgv_Data.AllowUserToAddRows = false;


                        ApplyStockStatus();
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

        private void ApplyStockStatus()
        {
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                if (row.Cells["StockQuantity"].Value != null)
                {
                    int stock = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                    var cell = row.Cells["StockStatus"];

                    if (stock == 0)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                _bs.DataSource = _products;
            }
            else
            {
                var filtered = _products
                    .Where(p => p.ProductName.ToLower().Contains(searchText)
                             || p.ProductCode.ToLower().Contains(searchText))
                    .ToList();

                _bs.DataSource = new BindingList<ProductDto>(filtered);
            }
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

                if (string.IsNullOrEmpty(txtMiktar.Text))
                {
                    MessageBox.Show("Miktar Giriniz "); return;
                }

                int UserID = CurrentUser.UserID;
                var selectedProduct = (ProductDto)dgv_Data.CurrentRow.DataBoundItem;

                int MalzemKodu = Convert.ToInt32(txtproductRef.Text);
                string Notes = txtNotes.Text;
                double quantity = Convert.ToInt32(txtMiktar.Text);

                int? unitRef = selectedProduct.unitRef ?? 0;
                int WhNumber = selectedProduct.whNumber;

                bool success = await SendReservationToApi(UserID, MalzemKodu, Notes, quantity, unitRef ?? 0, WhNumber);

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
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                ConfigurationHelper.LoadAppSettings().Token);
        }

        private async Task<bool> SendReservationToApi(int UserID, int MalzemeInt, string Note, double quantity, int unitRef, int WhNumber)
        {
            if (_client == null) throw new InvalidOperationException("_client henüz oluşturulmamış.");

            var data = new
            {
                UserID,
                ProductRef = MalzemeInt,
                Notes = Note,
                ReservedQty = quantity,
                UnitRef = unitRef,
                whNumber = WhNumber,
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
                    MessageBox.Show(errorContent + "\nCode: " + response.StatusCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("API hatası: " + ex.Message);
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
                CurrentUser.WhNumber = Convert.ToInt32(dgv_Data.Rows[e.RowIndex].Cells["WhNumber"].Value);
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