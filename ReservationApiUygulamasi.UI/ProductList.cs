using ReservationApiUygulamasi.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml.Linq;


namespace ReservationApiUygulamasi.UI
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private HttpClientHandler GetSSL()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };
        }

        private async void ProductList_Load(object sender, EventArgs e)
        //private void ProductList_Load(object sender, EventArgs e)
        {
            //LoadMockProducts();
            await LoadProductsFromApi();
            dgv_Data.Columns["id"].Visible = false;
        }

        private List<ProductDto> _products;

        //private void LoadMockProducts()
        //{
        //    _products = new List<ProductDto>
        //        {
        //            new ProductDto { Id = 1, ProductCode = "STK001", ProductName = "Product 1", StockQuantity = 100, WhNumber = 1 },
        //            new ProductDto { Id = 2, ProductCode = "STK002", ProductName = "Product 2", StockQuantity = 50, WhNumber = 2 },
        //            new ProductDto { Id = 3, ProductCode = "STK003", ProductName = "Product 3", StockQuantity = 200, WhNumber = 1 },
        //            new ProductDto { Id = 4, ProductCode = "STK004", ProductName = "Product 4", StockQuantity = 75, WhNumber = 3 },
        //        };
        //    dgv_Data.DataSource = _products;

        //}
        private async Task LoadProductsFromApi()
        {
            try
            {
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
                };

                var apiSettings = ConfigurationHelper.LoadApiSettings();

                using (var client = new HttpClient(GetSSL()))
                {
                    client.BaseAddress = new Uri(apiSettings.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);

                    var response = await client.GetAsync("api/Products");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        _products = JsonConvert.DeserializeObject<List<ProductDto>>(json);

                        dgv_Data.DataSource = null;
                        dgv_Data.DataSource = _products;
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
            if (dgv_Data.CurrentRow != null)
            {
                var selectedProduct = (ProductDto)dgv_Data.CurrentRow.DataBoundItem;
                int MalzemKodu = Convert.ToInt32(txtproductRef.Text);
                string Notes = txtNotes.Text;
                
                double  miktar = selectedProduct.StockQuantity; // textbox’tan al

                bool success = await SendReservationToApi
                    (
                    MalzemKodu,
                    Notes,
                    miktar
                    );

                if (success)
                    MessageBox.Show("Rezervasyon alınmıştır.");
                else
                    MessageBox.Show("Rezervasyon gönderilemedi.");
            }
        }

        private async Task<bool> SendReservationToApi(int MalzemeInt, string Note, double quantity)
        {
            try
            {
                var apiSettings = ConfigurationHelper.LoadApiSettings();

                using (var client = new HttpClient(GetSSL()))
                {
                    client.BaseAddress = new Uri(apiSettings.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);

                    var data = new
                    {
                        ProductRef = MalzemeInt,
                        Notes = Note,
                        ReservedQty = quantity
                    };

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/Reservations", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(error);
                    }

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API hatası: " + ex.Message);
                return false;
            }
        }

        // ShowReservationMessage methodu şuan için buton click eventinde çalışmıyor, düzeltilecek.
        private void ShowReservationMessage(ProductDto product, DialogResult result)  // kod tekrarı olmaması için ayrı bir method yaptım.
        {
            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"{product.ProductName} ürünü için rezervasyon işlemi başarıyla gerçekleştirildi. (Test amaçlı)");
                // Gerçek API çağrısı burada yapılacak
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Rezervasyon işlemi iptal edildi.");
            }
            else
            {
                MessageBox.Show("Lütfen önce bir ürün seçin.");
            }
        }

        private void dgv_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0)
            { 
                txtproductRef.Text = dgv_Data.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtstockQuantity.Text = dgv_Data.Rows[e.RowIndex].Cells["StockQuantity"].Value.ToString();
            }
        }
    }
}