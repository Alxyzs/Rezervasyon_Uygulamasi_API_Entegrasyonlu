using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class ReservationDto
	{
		public int ProductRef { get; set; }
		public double ReservedQty { get; set; }
		public string Notes { get; set; }
	}
}
