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
            var allowedHostsOptions = new AllowedHostsOptions();
            IConfiguration config = JsonConfigHelper.LoadJsonConfig(fileName);

            // Act
            var result = allowedHostsOptions.GetSection(config).Get<AllowedHostsOptions>();

            // Assert
            result.AllowedHosts.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetSection_WithNoValidAllowHostsKey_ExpectedBehavior()
        {
            // Arrange
            string expected = DefaultApplicationOptions.DefaultAllowHosts;
            var allowedHostsOptions = new AllowedHostsOptions();
            var fileName = "onekeyjsonfile.json";
            IConfiguration config = JsonConfigHelper.LoadJsonConfig(fileName);

            // Act
            var result = allowedHostsOptions.GetSection(config).Get<AllowedHostsOptions>();

            // Assert
            result.AllowedHosts.Should().BeEquivalentTo(expected);
        }
    }
}
