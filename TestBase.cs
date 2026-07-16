using System.Text.Json;
using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using PlaywrightTests.Config;
using PlaywrightTests.Pages;
using Xunit.Abstractions;

namespace PlaywrightTests;

[AllureOwner("QA Team")]
public abstract class TestBase : PageTest
{
    protected HomePage HomePage = null!;
    protected CartPage CartPage = null!;
    protected ProductPage ProductPage = null!;
    protected CatalogPage CatalogPage = null!;
    protected AppConfig AppConfig { get; private set; } = null!;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        var json = await File.ReadAllTextAsync("Config/AppConfig.json");

        AppConfig = JsonSerializer.Deserialize<AppConfig>(json)
            ?? throw new Exception("Failed to load AppConfig.json");

        HomePage = new HomePage(Page, AppConfig);
        CartPage = new CartPage(Page, AppConfig);
        ProductPage = new ProductPage(Page, AppConfig);
        CatalogPage = new CatalogPage(Page, AppConfig);
    }


    public override async Task DisposeAsync()
    {
        if (Page != null)
        {
            try
            {
               
                var screenshotBytes = await Page.ScreenshotAsync(new() { FullPage = true });

                AllureApi.AddAttachment(
                    name: "Final Page State",
                    type: "image/png",
                    content: screenshotBytes,
                    fileExtension: ".png"
                );
            }
            catch (Exception ex)
            {
                AllureApi.AddAttachment(
                    name: "Screenshot Capture Failed",
                    type: "text/plain",
                    content: System.Text.Encoding.UTF8.GetBytes(ex.ToString()),
                    fileExtension: ".txt"
                 );
            }
        }

        await base.DisposeAsync();
    }
}