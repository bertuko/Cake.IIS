#region Using Statements
using System;

using Xunit;
#endregion



namespace Cake.IIS.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void Should_Create_Application()
        {
            // Arrange
            var websiteSettings = CakeHelper.GetWebsiteSettings("Superman");
            CakeHelper.CreateWebsite(websiteSettings);

            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);

            // Act
            WebsiteManager manager = CakeHelper.CreateWebsiteManager();
            var added = manager.AddApplication(appSettings);

            // Assert
            Assert.True(added);
            Assert.NotNull(CakeHelper.GetApplication(websiteSettings.Name, appSettings.ApplicationPath));

            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }

        [Fact]
        public void Should_Create_Application_With_Predefined_EnabledProtocols()
        {
            // Arrange
            var websiteSettings = CakeHelper.GetWebsiteSettings("Batman");
            CakeHelper.CreateWebsite(websiteSettings);

            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            appSettings.AlternateEnabledProtocols = "http,net.pipe";

            // Act
            WebsiteManager manager = CakeHelper.CreateWebsiteManager();
            var added = manager.AddApplication(appSettings);

            // Assert
            Assert.True(added);
            var application = CakeHelper.GetApplication(websiteSettings.Name, appSettings.ApplicationPath);
            Assert.NotNull(application);
            Assert.Contains(BindingProtocol.Http.ToString(), 
                application.EnabledProtocols, 
                StringComparison.OrdinalIgnoreCase);
            Assert.Contains(BindingProtocol.NetPipe.ToString(), 
                application.EnabledProtocols, 
                StringComparison.OrdinalIgnoreCase);

            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }

        [Theory]
        [InlineData(true,false,true)]
        [InlineData(false,true,false)]
        public void Should_Set_Authentication(bool annon,bool basic,bool win)
        {

            // Arrange
            var websiteName = "Batman";
            CakeHelper.DeleteWebsite(websiteName);
            var websiteSettings = CakeHelper.GetWebsiteSettings(websiteName);
            CakeHelper.CreateWebsite(websiteSettings);

            var appSettings = CakeHelper.GetApplicationSettings(websiteName);

            appSettings.Authentication = CakeHelper.GetAuthenticationSettings(annon, basic, win);

            // Act
            WebsiteManager manager = CakeHelper.CreateWebsiteManager();
            var added = manager.AddApplication(appSettings);

            //Assert
            Assert.True(added);
            var authentication = CakeHelper.ReadAuthenticationSettings(websiteName);

            Assert.Equal(annon, authentication.EnableAnonymousAuthentication);
            Assert.Equal(basic, authentication.EnableBasicAuthentication);
            Assert.Equal(win, authentication.EnableWindowsAuthentication);

            CakeHelper.DeleteWebsite(websiteName);

        }
    }
}