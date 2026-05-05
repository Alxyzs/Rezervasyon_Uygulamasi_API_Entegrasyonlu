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
        public int? WhNumber { get; set; }

        public int? UnitRef { get; set; }

        //[JsonIgnore] //Api'de gösterilmesini istemediğimiz bir alan varsa JsonIgnore ile gizlenir.
        public DateTime? DATE { get; set; }//= DateTime.Now;

		[Timestamp]
		public byte[]? RowVersion { get; set; } //Burası Çakışma Önlemek için eklendi . Aynı anda iki kullanıcı aynı kaydı güncellemeye çalışırsa çakışma olur ve bu alan sayesinde çakışma önlenir . RowVersion, veritabanında her kaydın benzersiz bir sürüm numarasıdır. Bir kayıt güncellendiğinde, RowVersion değeri de güncellenir. Böylece, bir kullanıcı kaydı güncellerken, diğer kullanıcı aynı kaydı güncellemeye çalışırsa, RowVersion değerleri farklı olacağı için çakışma tespit edilir ve uygun bir hata mesajı döndürülebilir.
	}
}
