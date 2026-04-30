using System;
using System.IO;
using Newtonsoft.Json;
using ReservationApiUygulamasi.UI;

public static class ConfigurationHelper
{
    private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

    public static AppSettings LoadAppSettings()
    {
        if (!File.Exists(ConfigPath))
            throw new FileNotFoundException("appsettings.json bulunamadı.", ConfigPath);

        var json = File.ReadAllText(ConfigPath);
        var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);

        if (appSettings == null)
            throw new Exception("appsettings.json okunamadı veya format hatalı.");

        return appSettings;
    }
    public static ApiSettings LoadApiSettings()
    {
        return LoadAppSettings().ApiSettings;
    }
    public static void UpdateToken(string newToken)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        if (!File.Exists(path))
            throw new FileNotFoundException("appsettings.json bulunamadı!", path);

        var json = File.ReadAllText(path);

        var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);

        if (appSettings == null)
            throw new Exception("appsettings.json okunamadı veya format hatalı.");

        appSettings.Token = newToken;
        File.WriteAllText(path, JsonConvert.SerializeObject(appSettings, Formatting.Indented));
    }

    public static string GetToken()
    {
        var appSettings = LoadAppSettings();

        return appSettings.Token;
    }
}