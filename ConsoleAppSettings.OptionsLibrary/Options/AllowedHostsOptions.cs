using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

/// TODO: Does not have a method to handle when not present
public class AllowedHostsOptions : IConfigurationOptions
{
    public const string AllowedHostsName = "AllowedHosts";

    public string AllowedHosts { get; set; } = DefaultApplicationOptions.DefaultAllowHosts;

    /// <summary>
    /// Gets the Configuration Section for the AllowedHostsName
    /// </summary>
    /// <param name="config">The configuration option</param>
    /// <returns>the configuration after processing the section</returns>
    public IConfiguration? GetSection(IConfiguration config)
    {
        Configuration = config; 
        AllowedHostsOptions options = new();
        
        IConfigurationSection section = Configuration.GetSection(AllowedHostsName);
        if (section.Exists())
        {
            section.Bind(options);
        }
        else
        {
            this.AllowedHosts = DefaultApplicationOptions.DefaultAllowHosts;
            options.AllowedHosts = this.AllowedHosts;;
            section.Bind(options);
        }
        return Configuration;

    }
    
    /// <summary>
    /// Gets the Configuration Section for the AllowedHostsName
    /// </summary>
    /// <param name="config">The configuration option</param>
    /// <returns>the configuration after processing the section</returns>
    public IConfiguration? GetSection()
    {
        AllowedHostsOptions options = new();

        if (Configuration == null)
        {
            return Configuration;
        }

        IConfigurationSection section = Configuration.GetSection(AllowedHostsName);
        if (section.Exists())
        {
            section.Bind(options);
        }
        else
        {
            this.AllowedHosts = DefaultApplicationOptions.DefaultAllowHosts;
            options.AllowedHosts = this.AllowedHosts;;
            section.Bind(options);
        }
        return Configuration;

    }

    /// <summary>
    /// Represents the Configuration managed by an IConfigurationOption
    /// </summary>
    public IConfiguration? Configuration { get; set; }

    /// <summary>
    /// Uses the filename to get the filepath and then Sets the Configuration
    /// </summary>
    /// <param name="fileName">the filename for the json settings</param>
    public void OpenConfig(string fileName)
    {
        string filePath = Path.GetFullPath(fileName);
        Configuration = ConsoleOptionsJsonConfig.LoadJsonConfig(filePath);
    }
}