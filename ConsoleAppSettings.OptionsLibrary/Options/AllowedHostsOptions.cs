using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class AllowedHostsOptions
{
    public const string AllowedHostsName = "AllowedHosts";

    public string AllowedHosts { get; set; } = DefaultApplicationOptions.DefaultAllowHosts;


    public IConfiguration GetSection(IConfiguration config)
    {
        AllowedHostsOptions options = new();

        config.GetSection(AllowedHostsName)
            .Bind(options);
        return config;
    }

}