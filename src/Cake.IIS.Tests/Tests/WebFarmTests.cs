#region Using Statements
using Xunit;
using Shouldly;
#endregion



namespace Cake.IIS.Tests
{
    public class WebFarmTests
    {
        [Fact(Skip = "Skip on AppVeyor")]
        public void Should_Create_WebFarm()
        {
            // Arrange
            var settings = CakeHelper.GetWebFarmSettings();
            CakeHelper.DeleteWebFarm(settings.Name);

            // Act
            WebFarmManager manager = CakeHelper.CreateWebFarmManager();
            manager.Create(settings);

            // Assert
            CakeHelper.GetWebFarm(settings.Name).ShouldNotBeNull();
        }

        [Fact(Skip = "Skip on AppVeyor")]
        public void Should_Delete_WebFarm()
        {
            // Arrange
            var settings = CakeHelper.GetWebFarmSettings();
            CakeHelper.CreateWebFarm(settings);

            // Act
            CakeHelper.CreateWebFarmManager().Delete(settings.Name);

            // Assert
            CakeHelper.GetWebFarm(settings.Name).ShouldBeNull();
        }



        [Fact(Skip = "Skip on AppVeyor")]
        public void Should_Set_Server_Available()
        {
            // Arrange
            var settings = CakeHelper.GetWebFarmSettings();
            CakeHelper.CreateWebFarm(settings);

            // Act
            WebFarmManager manager = CakeHelper.CreateWebFarmManager();
            manager.SetServerAvailable(settings.Name, settings.Servers[0]);

            // Assert
            manager.GetServerState(settings.Name, settings.Servers[0]).ShouldBe("Avaiable");
        }

        [Fact(Skip = "Skip on AppVeyor")]
        public void Should_Set_Server_Unavailable()
        {
            // Arrange
            var settings = CakeHelper.GetWebFarmSettings();
            CakeHelper.CreateWebFarm(settings);

            // Act
            WebFarmManager manager = CakeHelper.CreateWebFarmManager();
            manager.SetServerUnavailable(settings.Name, settings.Servers[0]);

            // Assert
            manager.GetServerState(settings.Name, settings.Servers[0]).ShouldBe("Unavailable");
        }
    }
}