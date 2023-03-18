using ConsoleAppSettingsOptions.Library.Options;
using NUnit.Framework;
using System;
using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
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
            string expected = "localhost";
            var allowedHostsOptions = new AllowedHostsOptions();
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig("allowhostsonly.json");

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
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig("onekeyjsonfile.json");

            // Act
            var result = allowedHostsOptions.GetSection(config).Get<AllowedHostsOptions>();

            // Assert
            result.AllowedHosts.Should().BeEquivalentTo(expected);
        }
    }
}
