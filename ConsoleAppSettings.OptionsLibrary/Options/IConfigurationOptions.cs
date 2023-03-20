using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public interface IConfigurationOptions
{
    /// <summary>
    /// Represents the Configuration managed by an IConfigurationOption
    /// </summary>
    IConfiguration? Configuration { get; set; }

    /// <summary>
    /// Uses the filename to get the filepath and then Sets the Configuration
    /// </summary>
    /// <param name="fileName">the filename for the json settings</param>
    void OpenConfig(string fileName);
}