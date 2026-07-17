using Microsoft.Playwright;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;

public class ProductPage : CommonPage
{
    public ProductPage(IPage page, AppConfig appConfig)
        : base(page, appConfig)
    {
    }


    //locators

    public ILocator AddToCartButton =>
        Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Add to cart" }
        );

    public ILocator SoldOutButton =>
    Page.GetByRole(AriaRole.Button, new() { Name = "Sold out" });

    public ILocator ProductTitle =>
        Page.Locator("h1[itemprop='name']");

    private ILocator SizeDropdown =>
    Page.Locator("#product-select-option-0");

    private ILocator ColourDropdown =>
    Page.Locator("#product-select-option-1");

    //methods

    public async Task AddToCartAsync()
    {
        await AddToCartButton.ClickAsync();
    }


    public async Task<string> GetProductNameAsync()
    {
        return await ProductTitle.InnerTextAsync();
    }


    public async Task SelectSizeAsync(string size)
    {
        await SizeDropdown.SelectOptionAsync(size);
    }

    public async Task SelectColourAsync(string colour)
    {
        await ColourDropdown.SelectOptionAsync(colour);
    }
}