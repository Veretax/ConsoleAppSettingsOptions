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
        public void LoggingName_ConstantMatches()
        {
            var expected = "Logging";
            LoggingOptions.LoggingName.Should().Be(expected);
        }

        [Test]
        public void BindOptions_WhenConfigurationIsNull_Parameter()
        {
            // Arrange
            LoggingOptions options = new LoggingOptions();
            LoggingOptions expected = new();
            LogLevelOptions expectedLogLevel = new LogLevelOptions()
            {
                Default = "Debugging",
                MicrosoftAspNetCore = "Trace"
            };
            
            expected.LogLevel = expectedLogLevel;


            var fileName = "loggingloglevelonly.json";
            var config = options.OpenConfig(fileName);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.LogLevel.Default.Should().Be(expected.LogLevel.Default);
            actual.LogLevel.MicrosoftAspNetCore.Should().Be(expected.LogLevel.MicrosoftAspNetCore);
        }

        [Test]
        public void BindOptions_WhenJsonParamsAreMissing_ReturnEmpty()
        {
            // Arrange
            LoggingOptions options = new LoggingOptions();
            LoggingOptions expected = new();
            LogLevelOptions expectedLogLevel = new LogLevelOptions()
            {
                Default = "Debugging",
                MicrosoftAspNetCore = "Trace"
            };

            expected.LogLevel = expectedLogLevel;


            var fileName = "allowhostsonly.json";
            var config = options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.LogLevel.Default.Should().Be(expected.LogLevel.Default);
            actual.LogLevel.MicrosoftAspNetCore.Should().Be(expected.LogLevel.MicrosoftAspNetCore);
        }

        [Test]
        public void BindOptions_WithValidJson_ReturnsValues()
        {
            // Arrange
            LoggingOptions options = new LoggingOptions();
            LoggingOptions expected = new();
            LogLevelOptions expectedLogLevel = new LogLevelOptions()
            {
                Default = "Fatal",
                MicrosoftAspNetCore = "Trace"
            };

            expected.LogLevel = expectedLogLevel;


            var fileName = "loggingloglevelonly.json";
            var config = options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.LogLevel.Default.Should().Be(expected.LogLevel.Default);
            actual.LogLevel.MicrosoftAspNetCore.Should().Be(expected.LogLevel.MicrosoftAspNetCore);
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
