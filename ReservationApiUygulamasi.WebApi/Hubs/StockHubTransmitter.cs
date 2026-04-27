using Microsoft.AspNetCore.SignalR;

namespace ReservationApiUygulamasi.WebApi.Hubs
{
	public class StockHubTransmitter
	{
		private readonly IHubContext<StockHubs> _hubContext;

		public StockHubTransmitter( IHubContext<StockHubs> hubContext)
		{
			_hubContext = hubContext;
		}

		//burada SignalRHubs Classını kullanarak bir Stock UPDATELERİ İÇİN !!! bir bildirim,mesaj gondermek için CLASS Oluşturuldu .
		public async Task UpdateStocksAsync(object data)
		{
			await _hubContext.Clients.All.SendAsync("UpdateStocks", data);
		}

	}
}
