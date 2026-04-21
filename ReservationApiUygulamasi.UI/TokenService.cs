using ReservationApiUygulamasi.UI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Linq;

namespace ReservationApiUygulamasi.UI
{
    public class TokenService
    {
        private string _token;
        private DateTime _expireDate;
        private readonly HttpClient _httpClient;

        public TokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetTokenAsync(string username, string password)
        {
            if (!string.IsNullOrEmpty(_token) && _expireDate > DateTime.UtcNow) return _token;

            string requestUri = "api/Auth";

            var json = JsonConvert.SerializeObject(new
            {
                username = username,
                password = password
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUri, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API hatası: {response.StatusCode}\nİçerik: {responseString}");
            }
            if (responseString.Trim().StartsWith("{"))
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<TokenResponse>(responseString);

                    if (result != null && !string.IsNullOrEmpty(result.Token))
                    {
                        _token = result.Token;
                        _expireDate = DateTime.UtcNow.AddMinutes(30);

                        if (result.UserId != 0)
                        {
                            CurrentUser.UserID = result.UserId;
                        }

                        return _token;
                    }
                }
                catch
                { }
            }
            if (!string.IsNullOrWhiteSpace(responseString))
            {
                _token = responseString.Replace("\"", "");
                _expireDate = DateTime.UtcNow.AddMinutes(30);

                try
                {
                    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(_token);

                    var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid" || x.Type == "sub");

                    if (userIdClaim != null)
                    {
                        CurrentUser.UserID = int.Parse(userIdClaim.Value);
                    }
                }
                catch
                { }

                return _token;
            }

            throw new Exception("Token alınamadı. Gelen veri:\n" + responseString);
        }
        public class TokenResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("data")]
            public string Token { get; set; }

            [JsonProperty("userId")]
            public int UserId { get; set; }
        }
    }
}