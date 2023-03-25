using ConsoleAppSettingsOptions.Library.Configuration;
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


        [Test]
        public void BindOptions_WhenJsonMissing_ReturnsDefaults()
        {
            // Arrange
            MultiNestedSingleArrayOptions options = new MultiNestedSingleArrayOptions();
            var expectedPackageList = GenerateExpectedPackageList();

            MultiNestedSingleArrayOptions paramOptions = new MultiNestedSingleArrayOptions()
            {
                Packages = expectedPackageList
            };

            var defaultlist = new ComplexPackageOptions()
            {
                Name = DefaultApplicationOptions.DefaultComplexPackageOptionName,
                Items = DefaultApplicationOptions.DefaultComplexPackageItems
            };
            string filename = "loglevelonly.json";

            options.OpenConfig(filename);

            // Act
            var actual = options.BindOptions(options);

            // Assert
            actual.Packages.Count.Should().Be(1);
            actual.Packages[0].Should().BeEquivalentTo(defaultlist);
        }

        [Test]
        public void BindOptions_WhenValidJson_ReturnsValues()
        {
            // Arrange
            MultiNestedSingleArrayOptions options = new MultiNestedSingleArrayOptions();
            var expectedPackageList = GenerateExpectedMultiNestedSingleArrayList();

            MultiNestedSingleArrayOptions paramOptions = new MultiNestedSingleArrayOptions()
            {
                Packages = expectedPackageList
            };

            string filename = "multinestedsinglearray.json";

            options.OpenConfig(filename);

            // Act
             var actual = options.BindOptions(options);

            // Assert
            actual.Packages.Count.Should().Be(3);
            actual.Packages.Should().BeEquivalentTo(expectedPackageList);
        }

        [Test]
        public void BindOptions_WhenConfigurationNull_ReturnsParams()
        {
            // Arrange
            MultiNestedSingleArrayOptions options = new MultiNestedSingleArrayOptions();
            var expectedPackageList = GenerateExpectedPackageList();

            MultiNestedSingleArrayOptions expected = new MultiNestedSingleArrayOptions()
            {
                Packages = expectedPackageList
            };

            string filename = "multinestedsinglearray.json";

            options.OpenConfig(filename);
            options.Configuration = null;

            // Act
            var actual = options.BindOptions(expected);

            // Assert
            actual.Packages.Should().BeEquivalentTo(expectedPackageList);


        }

        private static List<ComplexPackageOptions> GenerateExpectedPackageList()
        {
            List<ComplexPackageOptions> expectedPackageList = new List<ComplexPackageOptions>();

            ComplexPackageOptions expectedToys = new ComplexPackageOptions()
            {
                Name = "Fun Toys",
                Items = new List<string>()
                {
                    "Yo-Yo",
                    "Top",
                    "Legos",
                    "Dolls",
                    "Blocks"
                }
            };

            expectedPackageList.Add(expectedToys);

            ComplexPackageOptions expectedMensWear = new ComplexPackageOptions()
            {
                Name = "Mensware",
                Items = new List<string>()
                {
                    "Button Up Shirt",
                    "Polo Shirt",
                    "Underwear",
                    "Pants",
                    "Hat"
                }
            };

            expectedPackageList.Add(expectedMensWear);

            ComplexPackageOptions expectedLadiesWear = new ComplexPackageOptions()
            {
                Name = "Ladiesware",
                Items = new List<string>()
                {
                    "Blouse",
                    "Dress",
                    "Underwear",
                    "Bra",
                    "Hair bow",
                    "Skirt",
                    "Hosiery"
                }
            };

            expectedPackageList.Add(expectedLadiesWear);

            ComplexPackageOptions expectedTools = new ComplexPackageOptions()
            {
                Name = "Tools",
                Items = new List<string>()
                {
                    "Hammer",
                    "Standard Screw Driver",
                    "Phillips Screw Driver",
                    "Needle Nose Plyers",
                    "Tape Measure",
                    "Adjustable Wrench",
                    "Socket Set"
                }
            };

            expectedPackageList.Add(expectedTools);
            return expectedPackageList;
        }
        
        private static List<ComplexPackageOptions> GenerateExpectedMultiNestedSingleArrayList()
        {
            List<ComplexPackageOptions> expectedPackageList = new List<ComplexPackageOptions>();

            ComplexPackageOptions expectedFlowers = new ComplexPackageOptions()
            {
                Name = "All Carnations",
                Items = new List<string>()
                {
                    "red", "yellow", "blue", "orange"
                }
            };

            expectedPackageList.Add(expectedFlowers);

            ComplexPackageOptions expectedChocolates = new ComplexPackageOptions()
            {
                Name = "ChocolateLovers",
                Items = new List<string>()
                {
                    "Ghiardeli", "Dove", "Hershey`'s Pot of Gold", "Lindor", "Russel Stover", "Whitmans"
                }
            };

            expectedPackageList.Add(expectedChocolates);

            ComplexPackageOptions expectedFruit = new ComplexPackageOptions()
            {
                Name = "Fruit",
                Items = new List<string>()
                {
                    "apples", "peaches", "bananas", "grapes", "cantoloupe", "water melon"
                }
            };

            expectedPackageList.Add(expectedFruit);
            
            return expectedPackageList;
        }
    }
}
