using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.EL.QueryModels
{
    public class StockCheckResult
    {
        public bool IsSuccess { get; set; }
        public decimal AvailableStock { get; set; }
        public string? Message { get; set; }
    }
}
