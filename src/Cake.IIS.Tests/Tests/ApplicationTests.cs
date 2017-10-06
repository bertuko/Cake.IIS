#region Using Statements
using System;
using System.Runtime.InteropServices;
using Xunit;
using System.IO;
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
            CakeHelper.DeleteWebsite(websiteSettings.Name);

            // Act
            CakeHelper.CreateWebsite(websiteSettings);
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);

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

            // Act
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            appSettings.AlternateEnabledProtocols = "http,net.pipe";

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

        [Fact]
        public void Should_Create_Application_With_DirectoryBrowsing()
        {
            // Arrange
            var websiteSettings = CakeHelper.GetWebsiteSettings("Hulk");
            CakeHelper.DeleteWebsite(websiteSettings.Name);

            // Act
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            CakeHelper.CreateWebConfig(appSettings);

            var manager = CakeHelper.CreateWebsiteManager();
            manager.Create(websiteSettings);
            manager.AddApplication(appSettings);
            manager.SetWebConfiguration(websiteSettings.Name, appSettings.ApplicationPath, config => config.EnableDirectoryBrowsing());

            // Assert
            var value = CakeHelper.GetWebConfigurationValue(websiteSettings.Name, appSettings.ApplicationPath, "system.webServer/directoryBrowse", "enabled");
            Assert.True((bool)value);

            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }

        [Fact]
        public void Should_Create_Application_Without_DirectoryBrowsing()
        {
            // Arrange
            var websiteSettings = CakeHelper.GetWebsiteSettings("Smash");
            CakeHelper.DeleteWebsite(websiteSettings.Name);

            // Act
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            CakeHelper.CreateWebConfig(appSettings);

            var manager = CakeHelper.CreateWebsiteManager();
            manager.Create(websiteSettings);
            manager.AddApplication(appSettings);
            manager.SetWebConfiguration(websiteSettings.Name, appSettings.ApplicationPath, config => config.DisableDirectoryBrowsing());

            // Assert
            var value = CakeHelper.GetWebConfigurationValue(websiteSettings.Name, appSettings.ApplicationPath, "system.webServer/directoryBrowse", "enabled");
            Assert.False((bool)value);

            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }

        [Fact]
        public void Should_Create_Application_With_DirectoryBrowsing_In_Settings()
        {
            // Arrange
            var websiteSettings = CakeHelper.GetWebsiteSettings("Bruce");
            CakeHelper.DeleteWebsite(websiteSettings.Name);

            // Act
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            appSettings.EnableDirectoryBrowsing = true;
            CakeHelper.CreateWebConfig(appSettings);

            var manager = CakeHelper.CreateWebsiteManager();
            manager.Create(websiteSettings);
            manager.AddApplication(appSettings);

            // Assert
            var value = CakeHelper.GetWebConfigurationValue(websiteSettings.Name, appSettings.ApplicationPath, "system.webServer/directoryBrowse", "enabled");
            Assert.True((bool)value);

            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }

        [Fact]
        public void Should_Create_Application_Without_DirectoryBrowsing_In_Settings()
        {
            //Setup
            var websiteSettings = CakeHelper.GetWebsiteSettings("Banner");
            CakeHelper.DeleteWebsite(websiteSettings.Name);

            // Arrange
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            appSettings.EnableDirectoryBrowsing = false;

            // Make sure the web.config exists
            CakeHelper.CreateWebConfig(appSettings);

            // Act
            var manager = CakeHelper.CreateWebsiteManager();
            manager.Create(websiteSettings);
            manager.AddApplication(appSettings);

            // Assert
            var value = CakeHelper.GetWebConfigurationValue(websiteSettings.Name, appSettings.ApplicationPath, "system.webServer/directoryBrowse", "enabled");
            Assert.False((bool)value);

            //Teardown
            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }
    }
}