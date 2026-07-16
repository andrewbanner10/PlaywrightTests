using Allure.Xunit.Attributes;
using Microsoft.Playwright;
using PlaywrightTests.Pages;
using Xunit;
using Xunit.Abstractions;

namespace PlaywrightTests.Tests;

public class CartTests : TestBase
{

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


    //This test fails - Would raise a bug
    [Fact]
    public async Task UserAddsProductAndCanViewProductInCart()
    {
        // Arrange 
        await HomePage.NavigateAsync();

        // Act
        await HomePage.OpenFirstProductAsync();

        var productName = await ProductPage.GetProductNameAsync();
        await ProductPage.AddToCartAsync();
        await CartPage.OpenCartAsync();

        // Asserts
        Assert.True(await CartPage.CartContainsProductAsync(productName));
    }


}