using Xunit;

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
            Assert.Equal(anon, authentication.EnableAnonymousAuthentication);
            Assert.Equal(basic, authentication.EnableBasicAuthentication);
            Assert.Equal(win, authentication.EnableWindowsAuthentication);

            //Teardown
            CakeHelper.DeleteWebsite(websiteName);
        }
    }
}