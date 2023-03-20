using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public sealed class AllowedHostsOptions : AbstractConfigurationOptions, IConfigurationOptions<AllowedHostsOptions>
{
    public const string AllowedHostsName = "AllowedHosts";

    public string AllowedHosts { get; set; } = DefaultApplicationOptions.DefaultAllowHosts;
    
    public AllowedHostsOptions BindOptions(AllowedHostsOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        IConfigurationSection section = Configuration.GetSection(AllowedHostsName);
        if (section.Exists())
        {
            if (section.Value != null)
            {
                this.AllowedHosts = section.Value;
                options.AllowedHosts = section.Value;
            }
            section.Bind(options);
        }
        else
        {
            this.AllowedHosts = DefaultApplicationOptions.DefaultAllowHosts;
            options.AllowedHosts = this.AllowedHosts;
            section.Bind(options);
        }

        return options;
    }
}