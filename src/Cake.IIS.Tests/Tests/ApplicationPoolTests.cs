#region Using Statements
using Microsoft.Web.Administration;

using Xunit;
using Shouldly;
#endregion



namespace Cake.IIS.Tests
{
    public class ApplicationPoolTests
    {
        [Fact]
        public void Should_Create_Delete_AppPool()
        {
            // Arrange
            var settings = CakeHelper.GetAppPoolSettings("Bart");

            // Create
            CakeHelper.CreateApplicationPoolManager().Create(settings);
            CakeHelper.GetPool(settings.Name).ShouldNotBeNull();

            // Delete
            CakeHelper.DeletePool(settings.Name);
            CakeHelper.GetPool(settings.Name).ShouldBeNull();
        }

        [Fact]
        public void Should_Start_AppPool()
        {
            // Arrange
            var settings = CakeHelper.GetAppPoolSettings("Homer");

            CakeHelper.CreatePool(settings);
            CakeHelper.StopPool(settings.Name);

            // Act
            CakeHelper.CreateApplicationPoolManager().Start(settings.Name);

            // Assert
            ApplicationPool pool = CakeHelper.GetPool(settings.Name);

            pool.ShouldNotBeNull();
            pool.State.ShouldBe(ObjectState.Started);

            CakeHelper.DeletePool(settings.Name);
        }

        [Fact]
        public void Should_Stop_AppPool()
        {
            // Arrange
            var settings = CakeHelper.GetAppPoolSettings("Marg");

            CakeHelper.CreatePool(settings);
            CakeHelper.StartPool(settings.Name);

            // Act
            CakeHelper.CreateApplicationPoolManager().Stop(settings.Name);

            // Assert
            ApplicationPool pool = CakeHelper.GetPool(settings.Name);

            pool.ShouldNotBeNull();
            pool.State.ShouldBe(ObjectState.Stopped);

            CakeHelper.DeletePool(settings.Name);
        }
    }
}