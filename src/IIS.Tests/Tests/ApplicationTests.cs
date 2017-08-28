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

        [Fact]
        public void Should_Create_Application_With_DirectoryBrowsing()
        {
            // Arrange
            var websiteSettings = CakeHelper.GetWebsiteSettings("Hulk");
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            // Make sure the web.config exists
            CakeHelper.CreateWebConfig(appSettings);

            // Act
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
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            // Make sure the web.config exists
            CakeHelper.CreateWebConfig(appSettings);

            // Act
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
            var appSettings = CakeHelper.GetApplicationSettings(websiteSettings.Name);
            appSettings.EnableDirectoryBrowsing = true;
            // Make sure the web.config exists
            CakeHelper.CreateWebConfig(appSettings);

            // Act
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
            var websiteName = "Banner";
            var websiteSettings = CakeHelper.GetWebsiteSettings("Banner");
            Cleanup(websiteSettings);

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
            Cleanup(websiteSettings);
        }

        private void Cleanup(WebsiteSettings websiteSettings)
        {
            var path = websiteSettings.PhysicalDirectory.ToString();
            if(Directory.Exists(path))
                Directory.Delete(path);

            CakeHelper.DeleteWebsite(websiteSettings.Name);
        }
    }
}