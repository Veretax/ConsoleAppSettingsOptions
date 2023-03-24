using ConsoleAppSettingsOptions.Library.Options;
using NUnit.Framework;
using System;
using ConsoleAppSettings.OptionsLibrary.Configuration;
using FluentAssertions;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class SingleArrayOptionsTests
    {

        [Test]
        public void SingleArrayOptionsName_ConstantReturnsExpected()
        {
            string expected = "SingleArrayOptions";

            SingleArrayOptions.SingleArrayOptionsName.Should().Be(expected);
        }


        [Test]
        public void BindOptions_WhenConfigurationIsNull_ReturnsDefaults()
        {
            // Arrange
            SingleArrayOptions options = new SingleArrayOptions();
            SingleArrayOptions expected = new SingleArrayOptions()
            {
                Options =  new List<string>()
                {
                    "one",
                    "two",
                    "four",
                    "eight",
                    "sixteen",
                    "thirty-two"
                }
            };
            string filename = "singlearrayitem.json";
            options.OpenConfig(filename);
            options.Configuration = null;
            
            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.Options.Should().BeEquivalentTo(expected.Options);

        }

        [Test]
        public void BindOptions_WhenValidFile_ReturnsValues()
        {
            // Arrange
            SingleArrayOptions options = new SingleArrayOptions();

            List<string> expectedOptions = new List<string>()
            {
                "orange", 
                "apple", 
                "banana", 
                "aardvark"
            };
            string filename = "singlearrayitem.json";
            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Options.Should().BeEquivalentTo(expectedOptions);

        }

        [Test]
        public void BindOptions_WhenJsonKeyMissing_ReturnsDefault()
        {
            // Arrange
            SingleArrayOptions options = new SingleArrayOptions();

            List<string> expectedOptions = new List<string>()
            {
                "default"
            };
            string filename = "allowhostsonly.json";
            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Options.Should().BeEquivalentTo(expectedOptions);

        }

        [Test]
        public void BindOptions_WhenJsonIsNotFound_ReturnsDefaults()
        {
            // Arrange
            SingleArrayOptions options = new SingleArrayOptions();
            SingleArrayOptions expected = new SingleArrayOptions()
            {
                Options = new List<string>()
                {
                    "default"
                }
            };
            string filename = "allowhostsonly.json";
            options.OpenConfig(filename);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.Options.Should().BeEquivalentTo(expected.Options);

        }
    }
}
