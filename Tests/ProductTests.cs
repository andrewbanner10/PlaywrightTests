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
        // Navigate to catalog
        await CatalogPage.CatalogNavigateAsync();

        // Select Noir Jacket, Size and Add to card
        await CatalogPage.SelectProductAsync("Noir jacket");
        await ProductPage.SelectSizeAsync(size);
        await ProductPage.AddToCartAsync();

        // Check cart updated
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
        // Navigate to catalog
        await CatalogPage.CatalogNavigateAsync();

        // Select Noir Jacket, Size and Add to card
        await CatalogPage.SelectProductAsync("Noir jacket");
        await ProductPage.SelectColourAsync(colour);
        await ProductPage.AddToCartAsync();

        // Check cart updated
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
        // Navigate to catalog
        await CatalogPage.CatalogNavigateAsync();

        // Select Noir Jacket, Size and Add to card
        await CatalogPage.SelectProductAsync("Noir jacket");
        await ProductPage.SelectSizeAsync(size);
        await ProductPage.SelectColourAsync(colour);
        await ProductPage.AddToCartAsync();

        // Check cart updated
        var cartCount = await CartPage.GetCartItemCountAsync();

        Assert.True(
            cartCount == "(1)",
            "Cart count should increase after adding product."
        );
    }
}