using ConsoleAppSettingsOptions.Library.Options;
using FluentAssertions;
using NUnit.Framework;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class PackageOptionsTests
    {
        [Test]
        public void PackageOptionsName_MatchesExpected()
        {
            // Arrange
            string expected = "Packages";


            // Act


            // Assert
            PackageOptions.PackageOptionsName.Should().Be(expected);
        }


        [Test]
        public void BindOptions_WhenConfigurationIsNull_ReturnsParams()
        {
            // Arrange
            PackageOptions options = new PackageOptions();
            PackageOptions expected = new PackageOptions()
            {
                Packages =
                {
                    "left",
                    "right",
                    "left",
                    "right",
                    "up",
                    "down",
                    "up",
                    "down",
                    "b",
                    "a",
                    "start"

                }
            };

            string filename = "packageonly.json";

            options.OpenConfig(filename);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.Packages.Should().BeEquivalentTo(expected.Packages);

        }

        [Test]
        public void BindOptions_WhenJsonParamsMissing_ReturnsDefaultss()
        {
            // Arrange
            PackageOptions options = new PackageOptions();
            List<string> expected = new List<string>()
            {
                "package1",
                "package2",
                "package3"
            };
            
            string filename = "allowhostsonly.json";

            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Packages.Should().BeEquivalentTo(expected);

        }

        [Test]
        public void BindOptions_WhenValidJson_ReturnsValues()
        {
            // Arrange
            PackageOptions options = new PackageOptions();
            List<string> expected = new List<string>()
            {
                "item1",
                "item2",
                "item3"
            };

            string filename = "packageonly.json";

            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Packages.Should().BeEquivalentTo(expected);

        }
    }
}
