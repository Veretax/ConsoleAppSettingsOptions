using System.Diagnostics.CodeAnalysis;
using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using ConsoleAppSettingsOptions.Library.Tests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class LogLevelOptionsTests
    {

        [Test]
        public void LogLevelName_ConstantMatches()
        {
            var expected = "LogLevel";
            LogLevelOptions.LogLevelName.Should().Be(expected);
        }

        [Test]
        public void BindOptions_WhenConfigurationIsNull_Parameter()
        {
            // Arrange
            LogLevelOptions options = new LogLevelOptions();
            LogLevelOptions expected = new();
            expected.MicrosoftAspNetCore = "Error";
            expected.Default = "Off";
            

            var fileName = "loglevelonly.json";
            var config = options.OpenConfig(fileName);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.Default.Should().Be(expected.Default);
            actual.MicrosoftAspNetCore.Should().Be(expected.MicrosoftAspNetCore);
        }

        [Test]
        public void BindOptions_WhenConfigurationIsNull_ReturnsDefaultValues()
        {
            // Arrange
            LogLevelOptions options = new LogLevelOptions();
            LogLevelOptions expected = new();
            expected.MicrosoftAspNetCore = "Error";
            expected.Default = "Off";
            options.Configuration = null;

            var fileName = "loglevelonly.json";
            var config = options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Default.Should().Be(expected.Default);
            actual.MicrosoftAspNetCore.Should().Be(expected.MicrosoftAspNetCore);
        }

        [Test]
        public void DefaultLogLevel_ReturnsInformationLogLevel()
        {
            // Arrange
            var logLevel = new LogLevelOptions();
            var expected = DefaultApplicationOptions.DefaultLoggingLevel;
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
            var expected = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            // Act
            var result = logLevel.MicrosoftAspNetCore;

            // Assert
            result.Should().Be(expected);
        }


        [Test]
        public void GetSection_ReturnsConfigurationBound()
        {
            // Arrange
            LogLevelOptions options = new LogLevelOptions();
            var expectedAspNetCore = "Error";
            var expectedDefault = "Off";

            var fileName = "loglevelonly.json";
            var config = options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Default.Should().Be(expectedDefault);
            actual.MicrosoftAspNetCore.Should().Be(expectedAspNetCore);
        }


        [Test]
        public void GetSection_WhenLogLevelIsNotPresent_ReturnsDefaults()
        {
            // Arrange
            LogLevelOptions options = new LogLevelOptions();
            var expectedAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            var expectedDefault = DefaultApplicationOptions.DefaultLoggingLevel;
            
            var fileName = "twonestedvalueonly.json";
            var config = options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(options);

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


        [Test]
        public void BindOptions_StateBeforeTest_StateAfterTest()
        {

        }


    }
}
