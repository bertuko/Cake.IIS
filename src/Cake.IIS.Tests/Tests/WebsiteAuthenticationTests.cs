#region Using Statements
using Xunit;
using Shouldly;
#endregion



namespace Cake.IIS.Tests.Tests
{
    public class WebsiteAuthenticationTests
    {
        [Theory]
        [InlineData(true, false, true)]
        [InlineData(false, true, false)]
        public void Should_Set_Authentication(bool anon, bool basic, bool win)
        {
            //Setup
            var websiteName = "HumanTorch";
            CakeHelper.DeleteWebsite(websiteName);

            // Arrange
            var settings = CakeHelper.GetWebsiteSettings(websiteName);
            settings.Authentication = CakeHelper.GetAuthenticationSettings(anon, basic, win);

            //Act
            CakeHelper.CreateWebsite(settings);
            CakeHelper.StartWebsite(websiteName);

            //Assert
            var authentication = CakeHelper.ReadAuthenticationSettings(websiteName);

            authentication.EnableAnonymousAuthentication.ShouldBe(anon);
            authentication.EnableBasicAuthentication.ShouldBe(basic);
            authentication.EnableWindowsAuthentication.ShouldBe(win);

            //Teardown
            CakeHelper.DeleteWebsite(websiteName);
        }
    }
}