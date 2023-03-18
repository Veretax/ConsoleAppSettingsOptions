using ConsoleAppSettings.OptionsLibrary.Configuration;
using NUnit.Framework;
using System;
using FluentAssertions;
using System.Reflection.PortableExecutable;
using ConsoleAppSettingsOptions.Library.Configuration;
using ConsoleAppSettingsOptions.Library.ExceptionMessages;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Tests.Configuration
{
    [TestFixture]
    public class ConsoleOptionsJsonConfigTests
    {
        #region IsEmptyJsonFile Tests
        [Test]
        public void IsEmptyJsonFile_EmptyJsonConfigFile_ReturnsFalse()
        {
            // Arrange
            string settingsFileName = "emptyjsonfile.json";

            // Act
            var result = ConsoleOptionsJsonConfig.IsEmptyJsonFile(settingsFileName);


            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsEmptyJsonFile_OneKeyJsonConfigFile_ReturnsFalse()
        {
            // Arrange
            string settingsFileName = "onekeyjsonfile.json";

            // Act
            var result = ConsoleOptionsJsonConfig.IsEmptyJsonFile(
                settingsFileName);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsEmptyJsonFile_NoActualConfigFile_ThrowsFileNotFoundException()
        {
            // Arrange
            string settingsFileName = "no_actual_config_file.json";
            string exceptionMsg = FileNotFoundExceptionMessage.GetFileNotFoundExceptionMessage(settingsFileName);

            // Act
            Action action = () =>
            {
                var result = ConsoleOptionsJsonConfig.IsEmptyJsonFile(settingsFileName);
            };

            // Assert
            action.Should().Throw<FileNotFoundException>()
                .WithMessage(exceptionMsg);

        }
        #endregion IsEmptyJsonFile Tests

        #region LoadJsonConfigTests
        [Test]
        public void LoadJsonConfig_EmptyJsonConfigFile_ReturnsNoChildren()
        {
            // Arrange
            string settingsFileName = "emptyjsonfile.json";

            // Act
            var result = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Assert
            result.GetChildren().Count().Should().Be(0);
        }

        [Test]
        public void LoadJsonConfig_OneKeyJsonConfigFile_ReturnsOneChild()
        {
            // Arrange
            string settingsFileName = "onekeyjsonfile.json";

            // Act
            var result = ConsoleOptionsJsonConfig.LoadJsonConfig(
                settingsFileName);

            // Assert
            result.GetChildren().Count().Should().Be(1);
            bool value = result.GetValue<bool>(DefaultApplicationOptions.DefaultOneKey);
            value.Should().BeTrue();
        }

        [Test]
        public void LoadJsonConfig_MissingFile_ThrowsFileNotFoundException()
        {
            // Arrange
            string settingsFileName = "missingjsonfile.json";
            string exceptionMsg = FileNotFoundExceptionMessage.GetFileNotFoundExceptionMessage(settingsFileName);
            
            // Act
            Action action = () =>
            {
                var result = ConsoleOptionsJsonConfig.LoadJsonConfig(
                    settingsFileName);
            };

            // Assert
            action.Should().Throw<FileNotFoundException>()
                .WithMessage(exceptionMsg);
        }
        #endregion LoadJsonConfigTests
    }
}
