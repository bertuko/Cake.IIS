#region Using Statements
    using Microsoft.Web.Administration;
    using Xunit;
#endregion



namespace Cake.IIS.Tests
{
    public class WebsiteTests
    {
        [Fact]
        public void Should_Create_Website()
        {
            // Arrange
            var settings = CakeHelper.GetWebsiteSettings();
            CakeHelper.DeleteWebsite(settings.Name);

            // Act
            WebsiteManager manager = CakeHelper.CreateWebsiteManager();
            manager.Create(settings);

            // Assert
            Assert.NotNull(CakeHelper.GetWebsite(settings.Name));
        }

        [Fact]
        public void Should_Delete_Website()
        {
            // Arrange
            var settings = CakeHelper.GetWebsiteSettings();
            CakeHelper.CreateWebsite(settings);

            // Act
            CakeHelper.CreateWebsiteManager().Delete(settings.Name);

            // Assert
            Assert.Null(CakeHelper.GetWebsite(settings.Name));
        }

        [Fact]
        public void Should_Start_Website()
        {
            // Arrange
            var settings = CakeHelper.GetWebsiteSettings();

            CakeHelper.CreateWebsite(settings);
            CakeHelper.StopWebsite(settings.Name);

            // Act
            CakeHelper.CreateWebsiteManager().Start(settings.Name);

            // Assert
            Site site = CakeHelper.GetWebsite(settings.Name);

            Assert.NotNull(site);
            Assert.True(site.State == ObjectState.Started);
        }

        [Fact]
        public void Should_Stop_Website()
        {
            // Arrange
            var settings = CakeHelper.GetWebsiteSettings();

            CakeHelper.CreateWebsite(settings);
            CakeHelper.StartWebsite(settings.Name);

            // Act
            CakeHelper.CreateWebsiteManager().Stop(settings.Name);

            // Assert
            Site site = CakeHelper.GetWebsite(settings.Name);

            Assert.NotNull(site);
            Assert.True(site.State == ObjectState.Stopped);
        }

        [Fact]
        public void Should_Add_Binding()
        {
            // Arrange
            var settings = CakeHelper.GetWebsiteSettings();
            CakeHelper.DeleteWebsite(settings.Name);
            WebsiteManager manager = CakeHelper.CreateWebsiteManager();
            manager.Create(settings);
            BindingSettings bindingSettings = new BindingSettings(settings.Name)
            {
                BindingProtocol = BindingProtocol.Ftp,
                Port = 21,
            };

            // Act
            manager.AddBinding(bindingSettings);

            // Assert
            var website = CakeHelper.GetWebsite(settings.Name);
            Assert.NotNull(website);
            Assert.Equal(2, website.Bindings.Count);
            Assert.Contains(website.Bindings, b => b.Protocol == BindingProtocol.Ftp.ToString());
        }
    }
}