using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class CreateReservationDto
	{
		public int? ProductRef { get; set; }
        public int? WhNumber { get; set; }
        public decimal? ReservedQty { get; set; }
		public string? Notes { get; set; }
        public int? UserID { get; set; }
	}
}
