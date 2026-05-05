using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.UI.Models
{
    public class SignalRDto
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public string Message { get; set; }
        public DateTime UpdateAt { get; set; }
        public double Quantity { get; set; }

        public string ActionType { get; set; }
    }
}
