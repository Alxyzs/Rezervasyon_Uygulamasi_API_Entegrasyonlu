using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.UI.Models
{
    public class Reservation
    {
        public int id { get; set; } //
        public int productRef { get; set; }
        public double? reservedQty { get; set; } //
        public string notes { get; set; } //
        public int? userID { get; set; } //
        public DateTime date { get; set; }
        public string rowVersion { get; set; } //
    }
}
