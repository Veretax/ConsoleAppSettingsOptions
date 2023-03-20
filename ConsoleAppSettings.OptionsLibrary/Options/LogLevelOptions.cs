using System.Collections.Specialized;
using ConsoleAppSettings.OptionsLibrary.Configuration;
using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public sealed class LogLevelOptions : AbstractConfigurationOptions, IConfigurationOptions<LogLevelOptions>
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

    public LogLevelOptions BindOptions(LogLevelOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        IConfigurationSection section = Configuration.GetSection(LogLevelName);
        if (section.Exists())
        {
            section.GetChildren();
            this.Default = section["Default"]?.ToString() ?? DefaultApplicationOptions.DefaultLoggingLevel;
            options.Default = section["Default"]?.ToString() ?? DefaultApplicationOptions.DefaultLoggingLevel;

            this.MicrosoftAspNetCore = section["Microsoft.AspNetCore"]?.ToString() ?? DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            options.MicrosoftAspNetCore = section["Microsoft.AspNetCore"]?.ToString() ?? DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel; 
            section.Bind(options);
        }
        else
        {
            this.Default = DefaultApplicationOptions.DefaultLoggingLevel;
            options.Default = this.Default;
            this.MicrosoftAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel;
            options.MicrosoftAspNetCore = this.MicrosoftAspNetCore;
            section.Bind(options);
        }

        return options;
    }
}