using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using ConsoleAppSettingsOptions.Library.Tests.Configuration;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace ConsoleAppSettingsOptions.Library.Tests.Configuration
{
    [TestFixture]
    public class TwoNestedValueOptionsTests
    {
        [Test]
        public void GetSection_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string expectedStringKey1 = "StringValue1";
            int expectedIntKey2 = 532;
            var options = new TwoNestedValueOptions();
            IConfiguration config = ConsoleOptionsJsonConfig.LoadJsonConfig("twonestedvalueonly.json");

            //// Act
            //var result = options.GetSection(config).Get<TwoNestedValueOptions>();

            //// Assert
            //result.StringKey1.Should().Be(expectedStringKey1);
            //result.IntKey2.Should().Be(expectedIntKey2);
        }
    }
}
