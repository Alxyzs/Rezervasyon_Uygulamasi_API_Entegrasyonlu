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
		public List<UserDto> GetSearchUser(string username, string password)
		{
			var baglanti = new SqlConnection(@"Server=DESKTOP-J60E0B5\ATABEY;Database=PEN;User Id=sa;Password=1234;TrustServerCertificate=True;");
			using (var conn = baglanti)
			{
				string sql = $"SELECT * FROM UserDto WHERE Username = @uname AND Password = @pass";
				return conn.Query<UserDto>(sql, new { uname = username, pass = password }).ToList();
			}
		}
	}
}
