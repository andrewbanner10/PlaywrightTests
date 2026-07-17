using Xunit;
using Xunit.Abstractions;

namespace PlaywrightTests.Tests;

public class HomeTests : TestBase
{

    [Fact]
    public async Task HomePageShouldLoadSuccessfully()
    {
        //Arrage
        await HomePage.NavigateAsync();

        //Act
        var title =
            await HomePage.GetPageTitleAsync();


        //Assert
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
        //Arrange
        await HomePage.NavigateAsync();

        //Act
        var count =
            await HomePage.GetProductCountAsync();

        //Assert
        Assert.True(
            count > 0
        );
    }
}