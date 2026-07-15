using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using PlaywrightTests.Config;
using PlaywrightTests.Pages;
using System.Text.Json;

namespace PlaywrightTests;

public abstract class TestBase : PageTest
{
    protected HomePage HomePage = null!;
    protected CartPage CartPage = null!;
    protected ProductPage ProductPage = null!;
    protected CatalogPage CatalogPage = null!;
    protected AppConfig AppConfig { get; set; } = null!;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();


        var json =
            await File.ReadAllTextAsync(
                "Config/AppConfig.json"
            );

        AppConfig =
        JsonSerializer.Deserialize<AppConfig>(json)!;

        HomePage = new HomePage(Page, AppConfig);
        CartPage = new CartPage(Page, AppConfig);
        ProductPage = new ProductPage(Page, AppConfig);
        CatalogPage = new CatalogPage(Page, AppConfig);
    }
}