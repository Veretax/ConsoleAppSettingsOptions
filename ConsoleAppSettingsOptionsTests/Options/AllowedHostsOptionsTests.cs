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
