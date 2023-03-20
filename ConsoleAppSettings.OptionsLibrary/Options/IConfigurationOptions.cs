using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public interface IConfigurationOptions<T>
{
    /// <summary>
    /// Represents the Configuration managed by an IConfigurationOption
    /// </summary>
    IConfiguration? Configuration { get; set; }

    /// <summary>
    /// Uses the filename to get the filepath and then Sets the Configuration
    /// </summary>
    /// <param name="fileName">the filename for the json settings</param>
    IConfiguration? OpenConfig(string fileName);

    /// <summary>
    /// Method used to bind the values in the options and then return the options
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    T BindOptions(T options);
}