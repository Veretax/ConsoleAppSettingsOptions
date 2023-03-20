using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using ConsoleAppSettingsOptions.Library.Tests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class TwoNestedValueOptionsTests
    {
        [Test]
        public void GetSection_StringValue_ExpectedBehavior()
        {
            // Arrange
            TwoNestedValueOptions options = new TwoNestedValueOptions();
            var expectedStringKey1 = "StringValue1";
            var expectedIntKey2 = 535;

            var fileName = "twonestedvalueonly.json";
            var config = options.OpenConfig(fileName); 

            // Act
            var result = options.BindOptions(options);


            // Assert
            result.StringKey1.Should().Be(expectedStringKey1);
            result.IntKey2.Should().Be(expectedIntKey2);
        }
    }
}
