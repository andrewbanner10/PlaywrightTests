using PlaywrightTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PlaywrightTests.Tests
{
    public class CatalogTests : TestBase
    {
        public CatalogTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task CatalogCanBeOpened()
        {
            // Arrange
            await HomePage.NavigateAsync();


            // Act
            await HomePage.OpenCartAsync();


            var catalogCount =
                await CatalogPage.GetCatalogItemsAsync();

            //Assert 
            Assert.True(catalogCount > 0);
        }

        [Fact]

        public async Task SoldOutItemCannotBeAddedToCart()
        {
            await CatalogPage.CatalogNavigateAsync(); 
        }

    }
}
