using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class ReservationDto
	{
		[Key]
		public int Id { get; set; }
		public int? ProductRef { get; set; }
		public decimal? ReservedQty { get; set; }
		public string? Notes { get; set; }
		public int? UserID { get; set; }
		//[JsonIgnore] //Api'de gösterilmesini istemediğimiz bir alan varsa JsonIgnore ile gizlenir.
		public DateTime? DATE { get; set; }//= DateTime.Now;
	}
}
