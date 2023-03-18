using ConsoleAppSettings.OptionsLibrary.Configuration;
using NUnit.Framework;
using System;
using FluentAssertions;
using System.Reflection.PortableExecutable;
using ConsoleAppSettingsOptions.Library.Exceptions;

namespace ConsoleAppSettingsOptions.Library.Tests.Configuration
{
    [TestFixture]
    public class ConsoleOptionsJsonConfigTests
    {
        [Test]
        public void LoadJsonConfig_EmptyJsonConfigFile_ReturnsNoChildren()
        {
            // Arrange
            // ~\emptyjsonfile.json
            string settingsFileName = "emptyjsonfile.json";

            // Act
            var result = ConsoleOptionsJsonConfig.LoadJsonConfig(
                settingsFileName);

            // Assert
            result.GetChildren().Count().Should().Be(0);
        }

        [Test]
        public void LoadJsonConfig_MissingFile_ExpectedBehavior()
        {
            // Arrange
            // ~\emptyjsonfile.json
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
    }
}
