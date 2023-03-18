using ConsoleAppSettingsOptions.Library.ExceptionMessages;
using NUnit.Framework;
using System;
using ConsoleAppSettingsOptions.Library.Configuration;
using FluentAssertions;

namespace ConsoleAppSettingsOptions.Library.Tests.ExceptionMessages
{
    [TestFixture]
    public class FileNotFoundExceptionMessageTests
    {
        [Test]
        public void GetFileNotFoundExceptionMessage_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string filePath = "somefilepath/fromhere/tothere.json";
            var expected =
                $"{FileNotFoundExceptionMessage.DefaultFileNotFoundExceptionMessage} (Parameter '{filePath}')";
            // Act
            var result = FileNotFoundExceptionMessage.GetFileNotFoundExceptionMessage(
                filePath);

            // Assert
            result.Should().Be(expected);
        }
    }
}
