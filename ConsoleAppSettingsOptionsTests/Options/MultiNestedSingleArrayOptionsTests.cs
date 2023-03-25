using ConsoleAppSettingsOptions.Library.Options;
using FluentAssertions;
using NUnit.Framework;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class MultiNestedSingleArrayOptionsTests
    {
        [Test]
        public void MultiNestedSingleArrayName_MatchesExpected()
        {
            // Arrange
            string expected = "MultiNestedSingleArray";

            // Act


            // Assert
            MultiNestedSingleArrayOptions.MultiNestedSingleArrayName.Should().Be(expected);
        }
    }
}
