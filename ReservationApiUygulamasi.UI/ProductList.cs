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


namespace ReservationApiUygulamasi.UI
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private async void ProductList_Load(object sender, EventArgs e)
        //private void ProductList_Load(object sender, EventArgs e)
        {
            //LoadMockProducts();
            await LoadProductsFromApi();
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
                var apiSettings = ConfigurationHelper.LoadApiSettings();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiSettings.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(apiSettings.Timeout);

                    var response = await client.GetAsync("api/products");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        _products = JsonConvert.DeserializeObject<List<ProductDto>>(json);

                        dgv_Data.DataSource = null;
                        dgv_Data.DataSource = _products;
                    }
                    else
                    {
                        MessageBox.Show($"API'den veri alınamadı: {response.StatusCode} - {response.ReasonPhrase}");
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
        }
        private void dgv_Data_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedProduct = (ProductDto)dgv_Data.Rows[e.RowIndex].DataBoundItem;
                DialogResult result = MessageBox.Show(
                    $"Ürünü rezerve etmek istiyor musun? {selectedProduct.ProductName}?",
                    "Ürünü rezerve edilsin mi?",
                    MessageBoxButtons.YesNo);

                ShowReservationMessage(selectedProduct, result);
            }
        }

        private void btnReserveSelected_Click(object sender, EventArgs e)
        {
            if (dgv_Data.CurrentRow != null)
            {
                var selectedProduct = (ProductDto)dgv_Data.CurrentRow.DataBoundItem;
                DialogResult result = MessageBox.Show(
                    $"Ürünü rezerve etmek istiyor musun? {selectedProduct.ProductName}?",
                    "Ürünü rezerve edilsin mi?",
                    MessageBoxButtons.YesNo);

                ShowReservationMessage(selectedProduct, result);
            }
        }
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

    }
}