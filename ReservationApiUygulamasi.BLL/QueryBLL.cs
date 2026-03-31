using ReservationApiUygulamasi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.BLL
{
	public static class QueryBLL
	{
		public static List<string> GetSearchUser(string username, string password)
		{
			return new QueryDAL().GetSearchUser(username, password);
		}
	}
}
