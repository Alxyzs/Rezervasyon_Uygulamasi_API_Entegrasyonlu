using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class UpdateReservationDto
	{
		public int Id { get; set; }
		public decimal? ReservedQty { get; set; }
		public string? Notes { get; set; }
		public byte[]? RowVersion { get; set; } 
	}
}
