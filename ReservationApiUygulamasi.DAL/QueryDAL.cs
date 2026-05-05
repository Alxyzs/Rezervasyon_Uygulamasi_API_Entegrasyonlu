using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using ReservationApiUygulamasi.EL.ApiModels;
using Microsoft.Extensions.Configuration;

namespace ReservationApiUygulamasi.DAL
{
	public class QueryDAL
	{
        //private readonly string _connectionString;

        //public QueryDAL(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");
        //}

        SqlConnection baglanti = new SqlConnection("YOUR_CONNECTION_STRING");

        public List<UserDto> GetSearchUser(string username, string password)
		{
			using (var conn = baglanti)
			{
				string sql = "SELECT * FROM UserDto WHERE Username = @uname AND Password = @pass";
				return conn.Query<UserDto>(sql, new { uname = username, pass = password }).ToList();
			}
		}

        public (bool IsValid, decimal AvailableStock) CheckStock(int? productRef , int? whNumber, decimal? requestQty)
        {
            string sql = @"SELECT StockQuantity FROM ProductDto WHERE Id = @productRef AND WhNumber = @whNumber";

            using( var conn = baglanti)
            {
                var stock = conn.QueryFirstOrDefault<decimal>(sql, new{productRef,whNumber});

                decimal availableStock = stock;

                bool isValid = requestQty <= availableStock;

                return (isValid, availableStock);
            };
        }


    }
}
