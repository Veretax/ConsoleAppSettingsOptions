using ConsoleAppSettings.OptionsLibrary.Configuration;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace ConsoleAppSettingsOptions.Library.Tests.Configuration
{
    [TestFixture]
    public class ConsoleOptionsJsonConfigTests
    {
        [Test]
        public void LoadJsonConfig_StateUnderTest_ExpectedBehavior()
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
    }
}
