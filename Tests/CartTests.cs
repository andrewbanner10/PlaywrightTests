using Allure.Xunit.Attributes;
using Microsoft.Playwright;
using PlaywrightTests.Pages;
using Xunit;
using Xunit.Abstractions;

namespace PlaywrightTests.Tests;

public class CartTests : TestBase
{
    public CartTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task CartShouldDisplayEmptyMessageWhenNoItemsAdded()
    {
        // Arrange
        await HomePage.NavigateAsync();

        // Act
        await CartPage.OpenCartAsync();

        // Assert
        await Expect(CartPage.EmptyCartMessage).ToBeVisibleAsync();
        await Expect(CartPage.EmptyCartMessage).ToHaveTextAsync("Your cart is empty.");
    }

    [Fact]
    public async Task UserShouldAddProductAndViewProductInCart()
    {
        // Arrange 
        await HomePage.NavigateAsync();

        // Act
        await HomePage.OpenFirstProductAsync();

        var productName = await ProductPage.GetProductNameAsync();
        await ProductPage.AddToCartAsync();
        await CartPage.OpenCartAsync();

        // Asserts
        await Expect(CartPage.CartItems).ToHaveCountAsync(1);
        Assert.True(await CartPage.CartContainsProductAsync(productName));
    }
}