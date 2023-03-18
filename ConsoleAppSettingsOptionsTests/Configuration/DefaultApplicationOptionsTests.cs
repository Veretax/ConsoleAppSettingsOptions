using ConsoleAppSettingsOptions.Library.Configuration;
using FluentAssertions;

namespace ConsoleAppSettingsOptionsTests.Configuration
{
    [TestFixture]
    public class DefaultApplicationOptionsTests
    {
        [Test]
        public void DefaultAgincourtApplicationName_ReturnsDefaultApplicationName()
        {
            // Arrange

            // Act


            // Assert
            DefaultApplicationOptions.DefaultAgincourtApplicationName.Should().Be("My Agincourt App");
        }
        [Test]
        public void DefaultApplicationVersion_ReturnsDefaultApplicationVersion()
        {
            // Arrange

            // Act


            // Assert
            DefaultApplicationOptions.DefaultApplicationVersion.Should().Be("1.0.0.0");
        }

        [Test]
        public void DefaultAppSettingsFileName_ReturnsDefaultAppSettingsFileName()
        {
            // Arrange

            // Act


            // Assert
            DefaultApplicationOptions.DefaultAppSettingsFileName.Should().Be("appsettings.json");
        }


        [Test]
        public void DefaultNoModuleList_ReturnsDefaultEmptyModuleList()
        {
            // Arrange
            string[] expected = new string[] { "none" };
            // Act

            // Assert
            DefaultApplicationOptions.DefaultNoModulesPresentList.Should().BeEquivalentTo(expected);

        }

        [Test]
        public void DefaultMicrosoftAspNetCoreLoggingLevel_ReturnsInformation()
        {
            // Arrange
            string expected = "Warning";

            // Act

            // Assert
            DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void DefaultLoggingLevel_ReturnsInformation()
        {
            // Arrange
            string expected = "Information";

            // Act

            // Assert
            DefaultApplicationOptions.DefaultLoggingLevel.Should().BeEquivalentTo(expected);
        }



    }
}
