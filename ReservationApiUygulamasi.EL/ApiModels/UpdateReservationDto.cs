using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class UpdateReservationDto
	{
		public int Id { get; set; }
		public int? ProductRef { get; set; }
		public decimal? ReservedQty { get; set; }
		public string? Notes { get; set; }
		public int? UserID { get; set; }
		public string? RowVersion { get; set; }  // byte[] DEĞİL, string olsun

		//[Timestamp]
		//public byte[]? RowVersion { get; set; } 
	}
}
