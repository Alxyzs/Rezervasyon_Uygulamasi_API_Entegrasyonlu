using Newtonsoft.Json;

public class ProductDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("productName")]
    public string ProductName { get; set; }

    [JsonProperty("productCode")]
    public string ProductCode { get; set; }

    [JsonProperty("stockQuantity")]
    public double StockQuantity { get; set; }

    [JsonProperty("stockStatus")]
    public string StockStatus { get; set; }
}