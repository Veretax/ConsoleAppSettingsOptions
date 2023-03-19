using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class LogLevelOptionsTests
    {
        [Test]
        public void DefaultLogLevel_ReturnsInformationLogLevel()
        {
            // Arrange
            var logLevel = new LogLevelOptions();
            var expected = "Information";
            // Act
            var result = logLevel.Default;

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void DotNetCore_ReturnsWarningLogLevel()
        {
            // Arrange
            var logLevel = new LogLevelOptions();
            var expected = "Warning";
            // Act
            var result = logLevel.MicrosoftAspNetCore;

            // Assert
            result.Should().Be(expected);
        }


        [Test]
        public void GetSection_ReturnsConfigurationBound()
        {
            // Arrange
            var config = ConsoleOptionsJsonConfig.LoadJsonConfig("appsettings.json");
            LogLevelOptions options = new LogLevelOptions();
            var expectedAspNetCore = "Warning";
            var expectedDefault = "Information";

            // Act
            var actual = options.GetSection(config).Get<LogLevelOptions>();

            // Assert
            actual.Default.Should().Be(expectedDefault);
            actual.MicrosoftAspNetCore.Should().Be(expectedAspNetCore);
        }
        
        [Test]
        public void DefaultLogLevel_WhenSet_ReturnsTheSameValue()
        {
            // Arrange
            var expected = "AnythingElse";
            var options = new LogLevelOptions();

            // Act
            options.Default = expected;

            // Assert
            options.Default.Should().Be(expected);

        }

        [Test]
        public void MicrosoftAspNetCoreLogLevel_WhenSet_ReturnsTheSameValue()
        {
            // Arrange
            var expected = "DoSomethingElse";
            var options = new LogLevelOptions();

            // Act
            options.MicrosoftAspNetCore = expected;

            // Assert
            options.MicrosoftAspNetCore.Should().Be(expected);

        }

    }
}
