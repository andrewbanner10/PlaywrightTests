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

    private ILocator AddToCartButton =>
        Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Add to cart" }
        );


    public ILocator ProductTitle =>
        Page.Locator("h1[itemprop='name']");



    //methods

    public async Task AddToCartAsync()
    {
        await AddToCartButton.ClickAsync();
    }


    public async Task<string> GetProductNameAsync()
    {
        return await ProductTitle.InnerTextAsync();
    }
}