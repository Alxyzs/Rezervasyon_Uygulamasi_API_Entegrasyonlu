using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ReservationApiUygulamasi.UI;

public static class ConfigurationHelper
{
    public static ApiSettings LoadApiSettings()
    {
        var json = File.ReadAllText("appsettings.json");
        var root = JsonConvert.DeserializeObject<Dictionary<string, ApiSettings>>(json);
        return root["ApiSettings"];
    }
}
