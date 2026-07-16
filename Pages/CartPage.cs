using Microsoft.Playwright;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;

public class CartPage : CommonPage
{
    public CartPage(IPage page, AppConfig appConfig)
        : base(page, appConfig)
    { 
    }


    //locators

    public ILocator EmptyCartMessage =>
        Page.GetByText("Your cart is empty.");


    public ILocator ItemsInCartCount =>
        Page.Locator("#cart-target-desktop span.count");

    public ILocator CartProductNames =>
    Page.Locator(".cart-item .product-name");

    //methods

    public async Task<string> GetCartItemCountAsync()
    {
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        return await ItemsInCartCount.InnerTextAsync();
    }

    public async Task<bool> CartContainsProductAsync(string productName)
    {
        return await CartProductNames
            .Filter(new()
            {
                HasText = productName
            })
            .IsVisibleAsync();
    }
}