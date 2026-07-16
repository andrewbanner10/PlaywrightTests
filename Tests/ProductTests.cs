using Xunit;

namespace PlaywrightTests.Tests;

public class ProductTests : TestBase
{
    [Theory]
    [InlineData("S")]
    [InlineData("M")]
    [InlineData("L")]
    public async Task UserCanAddNoirJacketToCart(string size)
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
}