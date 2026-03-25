using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class ReservationDto
	{
		[Key]
		public int ProductRef { get; set; }
		public double ReservedQty { get; set; }
		public string? Notes { get; set; }
	}
}
