using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.TabelModels
{
	public class Log
	{
			[Key]
			public int Id { get; set; }

			public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

			public int? UserId { get; set; }

			public string? IpAddress { get; set; }
			public string? Endpoint { get; set; }
			public string? HttpMethod { get; set; }

			public int? StatusCode { get; set; }

			public string? Exception { get; set; }

			public string? LogType { get; set; }

	}
}
