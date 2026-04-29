using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class ProductDto
	{
        [Key]
        public int Id { get; set; }
		public string? ProductCode { get; set; }
		public string? ProductName { get; set; }
		public double StockQuantity { get; set; }
		public decimal ReservationQuantity { get; set; }
		public string? UnitCode { get; set; }
		public int? UnitRef { get; set; }
		public string? WhName { get; set; }
		public Int16? WhNumber { get; set; }

	}
}
