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
        public void TwoNestedValueName_MatchesExpectedConstantString()
        {
            TwoNestedValueOptions options = new();

            var expected = "TwoNestedValue";
            TwoNestedValueOptions.TwoNestedValueName.Should().Be(expected);
        }



        [Test]
        public void BindOptions_WhenConfigurationIsNull_ReturnsParameterOptions()
        {
            // Arrange
            TwoNestedValueOptions options = new TwoNestedValueOptions();
            options.Configuration = null;

            TwoNestedValueOptions expectedOptions = new TwoNestedValueOptions();
            expectedOptions.IntKey2 = 35;
            expectedOptions.StringKey1 = "MYONLYoptionsDude$#";

            // Act
            var actual = options.BindOptions(expectedOptions);

            // Assert
            actual.Should().BeEquivalentTo(expectedOptions);


        }

        [Test]
        public void GetSection_StringAndIntValue_ExpectedBehavior()
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

            options.IntKey2.Should().Be(expectedIntKey2);
            options.StringKey1.Should().Be(expectedStringKey1);

            options.IntKey2.Should().Be(result.IntKey2);
            options.StringKey1.Should().Be(result.StringKey1);
        }

        [Test]
        public void GetSection_NoJsonAttributeMatch_ReturnsEmptyOptionValues()
        {
            // Arrange
            TwoNestedValueOptions options = new TwoNestedValueOptions();
            var expectedStringKey1 = string.Empty;
            var expectedIntKey2 = 0;

            var fileName = "allowhostsonly.json";
            var config = options.OpenConfig(fileName);

            // Act
            var result = options.BindOptions(options);


            // Assert
            result.StringKey1.Should().Be(expectedStringKey1);
            result.IntKey2.Should().Be(expectedIntKey2);

            options.IntKey2.Should().Be(expectedIntKey2);
            options.StringKey1.Should().Be(expectedStringKey1);

            options.IntKey2.Should().Be(result.IntKey2);
            options.StringKey1.Should().Be(result.StringKey1);
        }
    }
}
