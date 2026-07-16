using Microsoft.Playwright;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;

public class HomePage : CommonPage
{

    public HomePage(IPage page, AppConfig appConfig)
        : base(page, appConfig)
    {
    }



    // Locators

    private ILocator Logo =>
        Page.Locator("header img");


    private ILocator ProductCards =>
        Page.Locator(".product");

    private ILocator FirstProduct =>
    Page.Locator("a[href*='/products/']").First;

    // Methods
    public async Task NavigateAsync()
    {
        await base.NavigateAsync(
            AppConfig.ApplicationUrl
        );
    }

    public async Task OpenFirstProductAsync()
    {
        await FirstProduct.ClickAsync();
    }


    public async Task<bool> IsLogoVisibleAsync()
    {
        return await IsVisibleAsync(Logo);
    }


    public async Task<int> GetProductCountAsync()
    {
        return await ProductCards.CountAsync();
    }
}