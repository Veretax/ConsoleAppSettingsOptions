using ConsoleAppSettings.OptionsLibrary.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public abstract class AbstractConfigurationOptions
{
    public IConfiguration? Configuration { get; set; }

    /// <summary>
    /// Uses the filename to get the filepath and then Sets the Configuration
    /// </summary>
    /// <param name="fileName">the filename for the json settings</param>
    public IConfiguration? OpenConfig(string fileName)
    {
        Configuration = ConsoleOptionsJsonConfig.OpenJsonConfigFile(fileName);
        return Configuration;
    }

}