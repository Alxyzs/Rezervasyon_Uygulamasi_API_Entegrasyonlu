using ReservationApiUygulamasi.DAL;
using ReservationApiUygulamasi.EL.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApiUygulamasi.BLL
{
	public class QueryBLL
	{
        private readonly QueryDAL _dal;

        public QueryBLL(QueryDAL dal)
        {
            _dal = dal;
        }

        public List<UserDto> GetSearchUser(string username, string password)
		{
			return _dal.GetSearchUser(username, password);
		}
        public (bool IsValid, decimal AvailableStock) CheckStock(int? productRef,  int? whNumber, decimal? requestQty)
        {
            return _dal.CheckStock(productRef, whNumber, requestQty);
        }
    }
}
