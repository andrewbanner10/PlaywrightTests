using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using PlaywrightTests.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class CatalogPage : CommonPage
    {

    public CatalogPage(IPage page, AppConfig appConfig)
        : base(page, appConfig)
        {
        }


        //locators
        private ILocator CatalogItems =>
            Page.Locator("a[href*='/products/']");

        public ILocator SoldOutProducts =>
            Page.Locator("a:has(.sold-out)");

        private ILocator Product(string productName) =>
             Page.GetByText(productName, new() { Exact = true });

        public async Task OpenFirstSoldOutProductAsync()
        {
            await SoldOutProducts.First.ClickAsync();
        }

        //methods
        public async Task<int> GetCatalogItemsAsync()
        {
            return await CatalogItems.CountAsync();
        }

        public async Task CatalogNavigateAsync()
        {
            await base.NavigateAsync(
                AppConfig.CatalogUrl
            );

            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task SelectProductAsync(string productName)
        {
            await Product(productName).ClickAsync();
        }
    }
}
