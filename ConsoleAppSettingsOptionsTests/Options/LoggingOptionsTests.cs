using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using ConsoleAppSettingsOptions.Library.Tests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class LoggingOptionsTests
    {
        [Test]
        public void GetSection_LoggingOptions_ReturnsDefaultBehavior()
        {
            // Arrange
            var fileName = "loggingloglevelonly.json";
            var expectedAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            var expectedDefault = DefaultApplicationOptions.DefaultLoggingLevel;

            var options = new LoggingOptions();
            
            var config = JsonConfigHelper.LoadJsonConfig(fileName);

            // Act
            var actual = options.GetSection(config).Get<LoggingOptions>();

            // Assert
            actual.Should().BeOfType<LoggingOptions>();
            actual.LogLevel.Should().BeOfType<LogLevelOptions>();
            
            actual.LogLevel.MicrosoftAspNetCore.Should().Be(DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel);
            actual.LogLevel.Default.Should().Be(DefaultApplicationOptions.DefaultLoggingLevel);
        }
        
        [Test]
        public void LogLevelAspNetCore_WhenSetToValue_ReturnsThatValue()
        {
            // Arrange
            var fileName = "loggingloglevelonly.json";
            var expectedAspNetCore = "Trace";
            var expectedDefault = "Fatal";

            LoggingOptions options = new LoggingOptions();
            var config = JsonConfigHelper.LoadJsonConfig(fileName);
            var actual = options.GetSection(config).Get<LoggingOptions>();

            string expected = "NewAspNetCoreOption";
            // Act
            options.LogLevel.MicrosoftAspNetCore = expected;

            // Assert
            options.LogLevel.MicrosoftAspNetCore.Should().Be(expected);

        }

        [Test]
        public void LogLevelDefault_WhenSetToValue_ReturnsThatValue()
        {
            // Arrange
            var fileName = "loggingloglevelonly.json";
            var expectedAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            var expectedDefault = DefaultApplicationOptions.DefaultLoggingLevel;

            LoggingOptions options = new LoggingOptions();
            var config = JsonConfigHelper.LoadJsonConfig(fileName);
            var actual = options.GetSection(config).Get<LoggingOptions>();
            string expected = "NewDefaultCoreOption";
            // Act
            options.LogLevel.Default = expected;

            // Assert
            options.LogLevel.Default.Should().Be(expected);

        }



        [Test]
        public void LogLevel_WhenSetToValue_ReturnsThatValue()
        {
            // Arrange
            LoggingOptions options = new LoggingOptions();
            LogLevelOptions? expected = new()
            {
                Default = "NoItsANewDefault",
                MicrosoftAspNetCore = "YetAgainItsNotDefault"
            };
            
            // Act
            options.LogLevel = expected;

            // Assert
            options.LogLevel.Should().Be(expected);

        }
    }
}
