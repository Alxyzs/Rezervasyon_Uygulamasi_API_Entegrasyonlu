using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class UserDto
	{
		public int ID { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
