using ReservationApiUygulamasi.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationApiUygulamasi.UI.Models
{
    public class ApiService
    {
        private readonly string _baseUrl;
        public ApiService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        //get/api/products mock
        public List<ProductDto> GetProducts()
        {
            return new List<ProductDto>
            {
                new ProductDto { Id = 1, ProductCode = "STK001", ProductName = "Product 1", StockQuantity = 25, WhNumber = 0 },
                new ProductDto { Id = 2, ProductCode = "STK002", ProductName = "Product 2", StockQuantity = 150, WhNumber = 1 }
            };
        }
        //post/api/reserve mock
        public void ReserveProduct(ProductDto product, double qty)
        {
            //şimdilik
            MessageBox.Show($"{product.ProductName} için {qty} adet rezerve edildi (mock)");
        }
    }
}
