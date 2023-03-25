using ConsoleAppSettingsOptions.Library.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class ComplexPackageOptionsTests
    {
        [Test]
        public void ComplexPackageOptionsName_MatchesExpected()
        {
            // Arrange
            string expected = "Packages";

            // Act


            // Assert
            ComplexPackageOptions.ComplexPackageOptionsName.Should().Be(expected);
        }

        [Test]
        public void BindOptions_WhenConfigurationNull_ReturnsParams()
        {
            // Arrange
            ComplexPackageOptions options = new ComplexPackageOptions();
            ComplexPackageOptions expected = new ComplexPackageOptions()
            {
                Name = "First Aid Kit",
                Items = new()
                {
                    "One Inch Band Aids",
                    "Two Inch Band Aids",
                    "Roll of Gauze",
                    "Medical Tape",
                    "Anti-bacterial Cream",
                    "Scissors",
                    "Cotton Balls",
                    "Alcolhol Wipes",
                    "Tylenol"
                }
            };

            string fileName = "complexpackageonly.json";
            options.OpenConfig(fileName);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.Should().Be(expected);

        }

        [Test]
        public void BindOptions_WhenJsonMissing_ReturnsDefaults()
        {
            // Arrange
            ComplexPackageOptions options = new ComplexPackageOptions();
            ComplexPackageOptions expected = new ComplexPackageOptions()
            {
                Name = "First Aid Kit",
                Items = new()
                {
                    "One Inch Band Aids",
                    "Two Inch Band Aids",
                    "Roll of Gauze",
                    "Medical Tape",
                    "Anti-bacterial Cream",
                    "Scissors",
                    "Cotton Balls",
                    "Alcolhol Wipes",
                    "Tylenol"
                }
            };

            string fileName = "loggingloglevelonly.json";
            options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Name.Should().Be(DefaultApplicationOptions.DefaultComplexPackageOptionName);
            actual.Items.Should().BeEquivalentTo(DefaultApplicationOptions.DefaultComplexPackageItems);
        }

        //TODO: Test For BindOptions when json file is right format
        [Test]
        public void BindOptions_WhenValidJson_ReturnsValues()
        {
            // Arrange
            ComplexPackageOptions options = new ComplexPackageOptions();
            ComplexPackageOptions expected = new ComplexPackageOptions()
            {
                Name = "Dishes",
                Items = new()
                {
                    "Big Plates", "Little Plates", "Bowls", "Coffee Mugs"
                }
            };

            string fileName = "complexpackageonly.json";
            options.OpenConfig(fileName);

            // Act
            var actual = options.BindOptions(options);

            // Assert

            // actual.Should().BeEquivalentTo(expected); // This errors because the expected starts out with null configuration,  If it was a fully constructed Option it would have this, but for our test case we don't care about it.
            actual.Name.Should().Be(expected.Name);
            actual.Items.Should().BeEquivalentTo(expected.Items);
        }

    }
}
