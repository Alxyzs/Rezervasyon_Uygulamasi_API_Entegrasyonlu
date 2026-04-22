namespace ReservationApiUygulamasi.UI
{
    public class AppSettings
    {
        public ApiSettings ApiSettings { get; set; }
        public string Token { get; set; }
    }

    public class ApiSettings
    {
        public string BaseUrl { get; set; }
        public int Timeout { get; set; }
    }


}