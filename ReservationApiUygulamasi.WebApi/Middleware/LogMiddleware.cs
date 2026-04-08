using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;
using ReservationApiUygulamasi.EL.TabelModels;
using ReservationApiUygulamasi.WebApi.Context;
using ReservationApiUygulamasi.EL.QueryModels;

public class LogMiddleware
{
	private readonly RequestDelegate _next;

	public LogMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		if (context.Request.Path.StartsWithSegments("/swagger"))
		{
			await _next(context);
			return;
		}

		Exception? caughtEx = null;

		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			caughtEx = ex;
			throw; 
		}
		finally
		{
			try
			{
				using var scope = context.RequestServices.CreateScope();
				var db = scope.ServiceProvider.GetRequiredService<ApiContext>();

				db.Logs.Add(new Log
				{
					UserId = InstantUser.UserID,
					IpAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown !",
					Endpoint = context.Request.Path,
					HttpMethod = context.Request.Method,
					StatusCode = caughtEx == null ? context.Response.StatusCode : 500,
					Exception = caughtEx?.ToString(),
					LogType = caughtEx == null ? "Info" : "Error",
					CreatedAt = DateTime.Now
				});

				await db.SaveChangesAsync();
			}
			catch
			{
				// Log yazılamadıysa uygulamayı çökertme
			}
		}
	}
}