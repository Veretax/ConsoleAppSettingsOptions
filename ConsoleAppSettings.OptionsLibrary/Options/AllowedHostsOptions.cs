using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

/// TODO: Does not have a method to handle when not present
public class AllowedHostsOptions
{
    public const string AllowedHostsName = "AllowedHosts";

    public string AllowedHosts { get; set; } = DefaultApplicationOptions.DefaultAllowHosts;

    /// <summary>
    /// Gets the Configuration Section for the AllowedHostsName
    /// </summary>
    /// <param name="config">The configuration option</param>
    /// <returns>the configuration after processing the section</returns>
    public IConfiguration GetSection(IConfiguration config)
    {
        AllowedHostsOptions options = new();

        IConfigurationSection section = config.GetSection(AllowedHostsName);
        if (section.Exists())
        {
            section.Bind(options);
        }
        else
        {
            this.AllowedHosts = DefaultApplicationOptions.DefaultAllowHosts;
        }
        return config;

    }

}