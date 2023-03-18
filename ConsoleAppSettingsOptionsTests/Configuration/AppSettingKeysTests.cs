using ConsoleAppSettingsOptions.Library.Configuration;
using FluentAssertions;

namespace ConsoleAppSettingsOptionsTests.Configuration
{
    [TestFixture]
    public class AppSettingKeysTests
    {
        [Test]
        public void ApplicationNameKey_WhenCalled_ContainsAppSettings()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.ApplicationNameKey.Should().Contain("AppSettings");
        }

        [Test]
        public void ApplicationVersionKey_WhenCalled_ContainsAppSettings()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.ApplicationVersionKey.Should().Contain("AppSettings");
        }

        [Test]
        public void AgincourtModulelist_WhenCalled_ContainsMvcOptions()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.AgincourtModulelist.Should().Contain("MvcOptions");
        }

        [Test]
        public void CacheProfile_WhenCalled_ContainsMvcOptions()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.CacheProfile.Should().Contain("MvcOptions");
        }

        [Test]
        public void ApplicationNameKey_WhenCalled_MatchesExpectedString()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.ApplicationNameKey.Should().Be("AppSettings:ApplicationName");
        }

        [Test]
        public void ApplicationVersionKey_WhenCalled_MatchesExpectedString()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.ApplicationVersionKey.Should().Be("AppSettings:ApplicationVersion");
        }



        [Test]
        public void AgincourtModulelist_WhenCalled_MatchesExpectedString()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.AgincourtModulelist.Should().Be("MvcOptions:ModuleList");
        }

        [Test]
        public void CacheProfile_WhenCalled_MatchesExpectedString()
        {
            // Arrange

            // Act


            // Assert
            AppSettingKeys.CacheProfile.Should().Be("MvcOptions:CacheProfile");
        }
    }
}
