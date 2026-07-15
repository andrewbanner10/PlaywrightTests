namespace PlaywrightTests.Config;

public class AppConfig
{
    public string ApplicationUrl { get; set; } = string.Empty;

    public string CatalogPath { get; set; } = string.Empty;


    public string CatalogUrl =>
        $"{ApplicationUrl}{CatalogPath}";
}