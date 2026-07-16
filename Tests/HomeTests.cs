using Xunit;
using Xunit.Abstractions;

namespace PlaywrightTests.Tests;

public class HomeTests : TestBase
{

    [Fact]
    public async Task HomePageShouldLoadSuccessfully()
    {
        await HomePage.NavigateAsync();


        var title =
            await HomePage.GetPageTitleAsync();


        Assert.Contains(
            "Sauce Demo",
            title,
            StringComparison.OrdinalIgnoreCase
        );


        Assert.True(
            await HomePage.IsLogoVisibleAsync()
        );
    }



    [Fact]
    public async Task HomePageShouldDisplayProducts()
    {
        await HomePage.NavigateAsync();


        var count =
            await HomePage.GetProductCountAsync();


        Assert.True(
            count > 0
        );
    }
}