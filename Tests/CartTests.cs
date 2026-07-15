using Microsoft.Playwright;
using PlaywrightTests.Pages;
using Xunit;

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


        //Assert
        await Expect(CartPage.EmptyCartMessage)
            .ToBeVisibleAsync();

        await Expect(
            CartPage.EmptyCartMessage
        )
        .ToHaveTextAsync("Your cart is empty.");
    }

    //This test fails as the cart fails to load
    // Would raise this as a bug
    [Fact]
    public async Task UserShouldAddProductAndViewProductInCart()
    {
        //Arrange 
        await HomePage.NavigateAsync();

        //Act
        await HomePage.OpenFirstProductAsync();

        var productName =
            await ProductPage.GetProductNameAsync();

        await ProductPage.AddToCartAsync();

        await CartPage.OpenCartAsync();

        //Asserts

        await Expect(CartPage.CartItems)
            .ToHaveCountAsync(1);

        Assert.True(
            await CartPage.CartContainsProductAsync(productName)
        );
    }
}