using Xunit;

namespace PlaywrightTests.Tests;

public class ProductTests : TestBase
{
    [Theory]
    [InlineData("S")]
    [InlineData("M")]
    [InlineData("L")]
    public async Task UserCanAddItemWithSizesToCart(string size)
    {
        //Arrange - Navigate to catalog
        await CatalogPage.CatalogNavigateAsync();

        //Act - Select Noir Jacket, Size and Add to card
        await CatalogPage.SelectProductAsync("Noir jacket");
        await ProductPage.SelectSizeAsync(size);
        await ProductPage.AddToCartAsync();

        //Assert - Check cart updated
        var cartCount = await CartPage.GetCartItemCountAsync();

        Assert.True(
            cartCount =="(1)",
            "Cart count should increase after adding product."
        );
    }

    [Theory]
    [InlineData("Red")]
    [InlineData("Blue")]
    public async Task UserCanAddItemWithColoursToCart(string colour)
    {
        // Arrange -Navigate to catalog
        await CatalogPage.CatalogNavigateAsync();

        // Act - Select Noir Jacket, Colour and Add to card
        await CatalogPage.SelectProductAsync("Noir jacket");
        await ProductPage.SelectColourAsync(colour);
        await ProductPage.AddToCartAsync();

        // Assert - Check cart updated
        var cartCount = await CartPage.GetCartItemCountAsync();

        Assert.True(
            cartCount == "(1)",
            "Cart count should increase after adding product."
        );
    }

    [Theory]
    [InlineData("S", "Red")]
    [InlineData("M", "Blue")]
    [InlineData("L", "Red")]
    public async Task UserCanAddItemWithColoursAndSizeToCart(string size, string colour)
    {
        // Arrange - Navigate to catalog
        await CatalogPage.CatalogNavigateAsync();

        // Act - Select Noir Jacket, Size, Colour and Add to card
        await CatalogPage.SelectProductAsync("Noir jacket");
        await ProductPage.SelectSizeAsync(size);
        await ProductPage.SelectColourAsync(colour);
        await ProductPage.AddToCartAsync();

        // Assert - Check cart updated
        var cartCount = await CartPage.GetCartItemCountAsync();

        Assert.True(
            cartCount == "(1)",
            "Cart count should increase after adding product."
        );
    }
}