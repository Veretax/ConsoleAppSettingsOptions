using ConsoleAppSettingsOptions.Library.Options;
using NUnit.Framework;
using System;
using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
using ConsoleAppSettingsOptions.Library.Tests.Helpers;
using Microsoft.Extensions.Configuration;
using FluentAssertions;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class AllowedHostsOptionsTests
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
            AllowedHostsOptions options = new AllowedHostsOptions();
            AllowedHostsOptions expected = new();
            expected.AllowedHosts = "myhost.com";


            var fileName = "allowhostsonly.json";
            var config = options.OpenConfig(fileName);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.AllowedHosts.Should().Be(expected.AllowedHosts);
        }

        [Test]
        public void GetSection_WithValidAllowHostsKey_ReturnsKeyValue()
        {
            // Arrange
            var fileName = "allowhostsonly.json";
            string expected = "localhost";
            var options = new AllowedHostsOptions();
            options.OpenConfig(fileName);

            // Act
            var result = options.BindOptions(options);

            // Assert
            result.AllowedHosts.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetSection_WithNoValidAllowHostsKey_ExpectedBehavior()
        {
            // Arrange
            string expected = DefaultApplicationOptions.DefaultAllowHosts;
            var options = new AllowedHostsOptions();
            var fileName = "onekeyjsonfile.json";
            options.OpenConfig(fileName);

            // Act
            var result = options.BindOptions(options);

            // Assert
            result.AllowedHosts.Should().BeEquivalentTo(expected);
        }
    }
}
