using System.Collections.Specialized;
using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public sealed class LogLevelOptions
{
    public const string LogLevelName = "LogLevel";
    private string _default = DefaultApplicationOptions.DefaultLoggingLevel;
    private string _microsoftAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;

    public string Default { get => _default; set => _default = value; }

    public string MicrosoftAspNetCore
    {
        get => _microsoftAspNetCore;
        set => _microsoftAspNetCore = value;
    }

    public IConfiguration GetSection(IConfiguration config)
    {
        LogLevelOptions options = new();
        var section = config.GetSection(LogLevelOptions.LogLevelName);

        if (section.Exists())
        {
            section.Bind(this);
        }
        else
        {
            options.Default = DefaultApplicationOptions.DefaultLoggingLevel;
            options.MicrosoftAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            this.Default = DefaultApplicationOptions.DefaultLoggingLevel;
            this.MicrosoftAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            section.Bind(options);
        }
        return config;
    }
}