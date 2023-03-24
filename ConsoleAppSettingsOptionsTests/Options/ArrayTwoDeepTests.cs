using ConsoleAppSettingsOptions.Library.Configuration;
using ConsoleAppSettingsOptions.Library.Options;
using FluentAssertions;
using NUnit.Framework;

namespace ConsoleAppSettingsOptions.Library.Tests.Options
{
    [TestFixture]
    public class ArrayTwoDeepTests
    {
        [Test]
        public void ArrayToDeepName_MatchesExpected()
        {
            // Arrange
            string expected = "ArrayTwoDeepOptions";

            // Act


            // Assert
            ArrayTwoDeepOptions.ArrayTwoDeepName.Should().Be(expected);
        }


        [Test]
        public void BindOptions_WhenConfigurationNull_ReturnsOptions()
        {
            // Arrange
            ArrayTwoDeepOptions options = new ArrayTwoDeepOptions();
            PackageOptions expectedPackages = new PackageOptions()
            {
                Packages = new List<string>()
                {
                    "Forth",
                    "C",
                    "Lisp",
                    "Ada"
                }
            };
            ArrayTwoDeepOptions expetedOptions = new ArrayTwoDeepOptions()
            {
                Packages = expectedPackages
            };
            string filename = "arraytwodeep.json";

            options.OpenConfig(filename);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expetedOptions);

            // Assert
            actual.Packages.Should().Be(expectedPackages);
        }

        [Test]
        public void BindOptions_WhenJsonIsMissing_ReturnsDefaults()
        {
            // Arrange
            ArrayTwoDeepOptions options = new ArrayTwoDeepOptions();
            
            List<string> expectedPackages = DefaultApplicationOptions.DefaultPackageOptionsArray;
            ArrayTwoDeepOptions expectedOptions = new ArrayTwoDeepOptions()
            {
                Packages = new PackageOptions()
                {
                    Packages = expectedPackages
                }
            };
            string filename = "allowhostsonly.json";

            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(expectedOptions);

            // Assert
            actual.Packages.Packages.Should().BeEquivalentTo(expectedPackages);
        }

        [Test]
        public void BindOptions_WhenValidJson_ReturnsValues()
        {
            // Arrange
            ArrayTwoDeepOptions options = new ArrayTwoDeepOptions();

            List<string> expectedPackages = new List<string>()
            {
                "item1",
                "item2",
                "item3"
            };

            ArrayTwoDeepOptions expectedOptions = new ArrayTwoDeepOptions()
            {
                Packages = new PackageOptions()
                {
                    Packages = expectedPackages
                }
            };
            string filename = "arraytwodeep.json";

            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(expectedOptions);

            // Assert
            actual.Packages.Packages.Should().BeEquivalentTo(expectedPackages);
        }

    }
}
