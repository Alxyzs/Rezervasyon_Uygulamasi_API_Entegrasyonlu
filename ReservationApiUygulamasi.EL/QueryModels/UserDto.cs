using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.QueryModels
{
	public class UserDto
	{
		public int ID { get; set; }
		public string? USERNAME { get; set; }
		public string? PASSWORD { get; set; }
	}
}
