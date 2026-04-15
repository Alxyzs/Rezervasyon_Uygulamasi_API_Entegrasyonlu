using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ReservationApiUygulamasi.WebApi.Hubs
{
	//BURASI SignalR Hub olarak tanındı . Amacı sunucdaki herkese veya bir kişiye mesaj,bildirim göndermek . Örneğin stok miktarı azaldığında tüm kullanıcılara bildirim göndermek gibi
	//[Authorize] eklenebilir token ile erişim sağlanabilir ama şimdilik eklemedim 
	public class StockHubs : Hub
	{

	}
}
