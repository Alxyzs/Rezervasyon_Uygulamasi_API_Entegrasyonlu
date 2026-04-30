using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using ReservationApiUygulamasi.EL.ApiModels;

namespace ReservationApiUygulamasi.DAL
{
	public class QueryDAL
	{
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-J60E0B5\ATABEY;Database=PEN;User Id=sa;Password=1234;TrustServerCertificate=True;");
		public List<UserDto> GetSearchUser(string username, string password)
		{
			using (var conn = baglanti)
			{
				string sql = $"SELECT * FROM UserDto WHERE Username = @uname AND Password = @pass";
				return conn.Query<UserDto>(sql, new { uname = username, pass = password }).ToList();
			}
		}

        public (bool IsValid, decimal AvailableStock) CheckStock(int? productRef, int? unitRef, int? whNumber, decimal? requestQty)
        {
            string sql = @"SELECT StockQuantity FROM ProductDto WHERE Id = @productRef AND UnitRef = @unitRef AND WhNumber = @whNumber";

            using var conn = baglanti;

            var stock = conn.QueryFirstOrDefault<decimal>(sql, new
            {
                productRef,
                unitRef,
                whNumber
            });

            decimal availableStock = stock;

            bool isValid = requestQty <= availableStock;

            return (isValid, availableStock);
        }
    }
}
