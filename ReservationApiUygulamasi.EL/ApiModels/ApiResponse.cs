using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.ApiModels
{
	public class ApiResponse<T> //Burası API'den dönen ResponseBody kısmı için ve T ise dönen datatipidir yanı tum Dto'lar ıcın kullanılabılır Eğer ReservationDto yapsaydım sadece onu nıcın olurdu dıgerlerı ıcın tekrar tekrar kod yazardım
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }

		//public DataResponse<T>? Data { get; set; }
	}

	//public class DataResponse<T> {} Parantez icinde gostermek icin Reservation bilgilerini .
	//{
	//	public T? Data { get; set; }
	//}
}
