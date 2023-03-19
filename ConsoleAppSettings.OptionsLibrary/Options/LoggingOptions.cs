using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public sealed class LoggingOptions
{
    public const string LoggingName = "Logging";
    public LogLevelOptions? LogLevel { get; set; } = new LogLevelOptions();
    
    public IConfiguration GetSection(IConfiguration config)
    {
        LoggingOptions options = new();

        var section = config.GetSection(LoggingOptions.LoggingName);
        if (section.Exists())
        {
            section.Bind(this);
        }
        else
        {
            
            options.LogLevel = new LogLevelOptions()
            {
                Default = DefaultApplicationOptions.DefaultLoggingLevel,
                MicrosoftAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel
            };

            this.LogLevel = options.LogLevel;
            section.Bind(options);
        }
        
        return config;
    }
}