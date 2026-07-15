using Microsoft.Playwright;
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
        }
    }
}
