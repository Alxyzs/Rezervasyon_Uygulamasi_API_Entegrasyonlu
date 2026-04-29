using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.QueryModels
{
    public class StockReservationSpModel
    {
        public int? ProductRef { get; set; }
        public int WhNumber { get; set; }
        public int? UnitRef { get; set; }
        public int? Miktar { get; set; }
        public string? Notes { get; set; }
        public int? UserID { get; set; }
    }
}
