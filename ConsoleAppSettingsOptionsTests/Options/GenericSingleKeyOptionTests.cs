using ConsoleAppSettingsOptions.Library.Options;
using NUnit.Framework;
using System;
using Microsoft.Extensions.Configuration;
using ConsoleAppSettings.OptionsLibrary.Configuration;
using FluentAssertions;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class GenericSingleKeyOptionTests
    {
        [Test]
        public void GetSection_SectionNotPresent_ReturnsDefaultValue()
        {
            // Arrange
            var singleKeyName = "String";
            var genericSingleKeyOption = new GenericSingleKeyOption<string>(singleKeyName);
            var expected = "mystring";
            string stringDefault = string.Empty;
            var secondExpected = "NewString";
            ;

            string settingsFileName = "twonestedvalueonly.json";
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Act
            var result = genericSingleKeyOption.GetSection(config, stringDefault);

            // Assert
            result.Value.Should().BeEquivalentTo(stringDefault);
            result.Key.Should().BeEquivalentTo(singleKeyName);
        }

        //[Test]
        //public void GetSection_SectionNotPresentThenGetValue_ReturnsDefaultValue()
        //{
        //    // Arrange
        //    var singleKeyName = "String";
        //    var genericSingleKeyOption = new GenericSingleKeyOption<string>(singleKeyName);
        //    var expected = "mystring";
        //    string stringDefault = string.Empty;
        //    var secondExpected = "NewString";
        //    ;

        //    string settingsFileName = "twonestedvalueonly.json";
        //    IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

        //    // Act
        //    var result = genericSingleKeyOption.GetSection(config, stringDefault).GetValue<string>(singleKeyName);

        //    // Assert
        //    result.Should().BeEquivalentTo(stringDefault);
        //}

        [Test]
        public void GetSection_ForString_ReturnsString()
        {
            // Arrange
            var singleKeyName = "String";
            var genericSingleKeyOption = new GenericSingleKeyOption<string>(singleKeyName);
            var expected = "mystring";
            string stringDefault = string.Empty;
            var secondExpected = "NewString";
            ;

            string settingsFileName = "objectsinglekeytypes.json";
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Act
            var result = genericSingleKeyOption.GetSection(config, stringDefault);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
            result.Key.Should().BeEquivalentTo(singleKeyName);

            result.Value = secondExpected;
            result.Value.Should().Be(secondExpected);
        }

        [Test]
        public void GetSection_ForInt32_ReturnsInt32Min()
        {
            // Arrange
            var singleKeyName = "Int32";
            var genericSingleKeyOption = new GenericSingleKeyOption<int>(singleKeyName);
            var expected = Int32.MinValue;
            var defaultValue = 0;
            var secondExpected = Int32.MaxValue;

            string settingsFileName = "objectsinglekeytypes.json";
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Act
            var result = genericSingleKeyOption.GetSection(config, defaultValue);

            // Assert
            Convert.ToInt32(result.Value).Should().Be(expected);
            result.Key.Should().BeEquivalentTo(singleKeyName);

            result.Value = secondExpected.ToString();
            Convert.ToInt32(result.Value).Should().Be(secondExpected);
        }
        
        [Test]
        public void GetSection_ForInt16_ReturnsInt32Min()
        {
            // Arrange
            var singleKeyName = "Int16";
            var genericSingleKeyOption = new GenericSingleKeyOption<Int16>(singleKeyName);
            var expected = Int16.MinValue;
            Int16 defaultValue = 0;
            var secondExpected = Int16.MaxValue;

            string settingsFileName = "objectsinglekeytypes.json";
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Act
            var result = genericSingleKeyOption.GetSection(config, defaultValue);

            // Assert
            Convert.ToInt32(result.Value).Should().Be(expected);
            result.Key.Should().BeEquivalentTo(singleKeyName);

            result.Value = secondExpected.ToString();
            Convert.ToInt16(result.Value).Should().Be(secondExpected);
        }
        
        [Test]
        public void GetSection_ForBoolTrue_ReturnsTrue()
        {
            // Arrange
            var singleKeyName = "BoolTrue";
            var genericSingleKeyOption = new GenericSingleKeyOption<Boolean>(singleKeyName);
            var expected = true;
            Boolean defaultValue = false;

            string settingsFileName = "objectsinglekeytypes.json";
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Act
            var result = genericSingleKeyOption.GetSection(config, defaultValue);

            // Assert
            Convert.ToBoolean(result.Value).Should().BeTrue();
            result.Key.Should().BeEquivalentTo(singleKeyName);
        }
        
        [Test]
        public void GetSection_ForBoolFalse_ReturnsFalse()
        {
            // Arrange
            var singleKeyName = "BoolFalse";
            var genericSingleKeyOption = new GenericSingleKeyOption<Boolean>(singleKeyName);
            var expected = false;
            Boolean defaultValue = true;

            string settingsFileName = "objectsinglekeytypes.json";
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig(settingsFileName);

            // Act
            var result = genericSingleKeyOption.GetSection(config, defaultValue);

            // Assert
            Convert.ToBoolean(result.Value).Should().BeFalse();
            result.Key.Should().BeEquivalentTo(singleKeyName);
        }


        [Test]
        public void Value_IsSet_StateAfterTest()
        {

        }

    }
}
