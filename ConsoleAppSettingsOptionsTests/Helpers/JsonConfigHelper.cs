using ConsoleAppSettings.OptionsLibrary.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Tests.Helpers;

public class JsonConfigHelper
{
    public static IConfigurationRoot? LoadJsonConfig(string fileName)
    {
        return ConsoleOptionsJsonConfig.LoadJsonConfig(fileName);
    }
}