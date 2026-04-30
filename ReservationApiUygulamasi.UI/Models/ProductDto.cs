using System.ComponentModel;
using Newtonsoft.Json;

public class ProductDto : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("productName")]
    public string ProductName { get; set; }

    [JsonProperty("productCode")]
    public string ProductCode { get; set; }

    private double _stockQuantity;

    [JsonProperty("stockQuantity")]
    public double StockQuantity
    {
        get => _stockQuantity;
        set
        {
            if (_stockQuantity != value)
            {
                _stockQuantity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StockQuantity)));
            }
        }
    }

    [JsonProperty("unitCode")]
    public string unitCode { get; set; }

    [JsonProperty("unitRef")]
    public int? unitRef { get; set; }

    [JsonProperty("whName")]
    public string whName { get; set; }

    [JsonProperty("whNumber")]
    public int whNumber { get; set; }

    private string _stockStatus;

    [JsonProperty("stockStatus")]
    public string StockStatus
    {
        get => _stockStatus;
        set
        {
            if (_stockStatus != value)
            {
                _stockStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StockStatus)));
            }
        }
    }
}