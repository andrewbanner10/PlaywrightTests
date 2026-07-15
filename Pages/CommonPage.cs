using Microsoft.Playwright;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;

public class CommonPage
{
    protected readonly IPage Page;
    protected readonly AppConfig AppConfig;

    public CommonPage(IPage page, AppConfig appConfig)
    {
        Page = page;
        AppConfig = appConfig;
        
    }

    private ILocator CartLink =>
    Page.GetByRole(AriaRole.Link, new()
    {
        Name = "My Cart"
    });

    private ILocator CatalogLink =>
    Page.GetByText("Catalog");


    // -----------------------
    // Navigation
    // -----------------------

    public async Task NavigateAsync(string url)
    {
        await Page.GotoAsync(url);
    }



    // -----------------------
    // Browser Information
    // -----------------------

    public async Task<string> GetPageTitleAsync()
    {
        return await Page.TitleAsync();
    }


    public string CurrentUrl()
    {
        return Page.Url;
    }



    // -----------------------
    // Common Actions
    // -----------------------

    public async Task OpenCartAsync()
    {
        await CartLink.ClickAsync();
    }

    public async Task OpenCatalog()
    {
        await CatalogLink.ClickAsync();
    }


    // -----------------------
    // Common Validation
    // -----------------------

    public async Task<bool> IsVisibleAsync(
        ILocator locator)
    {
        return await locator.IsVisibleAsync();
    }
}