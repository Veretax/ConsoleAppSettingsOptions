using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

// TODO migrate GetSection to BindOptions Style
public sealed class LoggingOptions : AbstractConfigurationOptions, IConfigurationOptions<LoggingOptions>
{
    public const string LoggingName = "Logging";
    public LogLevelOptions? LogLevel { get; set; } = new LogLevelOptions();
    
    //public IConfiguration GetSection(IConfiguration config)
    //{
    //    LoggingOptions options = new();

    //    var section = config.GetSection(LoggingOptions.LoggingName);
    //    if (section.Exists())
    //    {
    //        section.Bind(this);
    //    }
    //    else
    //    {
            
    //        options.LogLevel = new LogLevelOptions()
    //        {
    //            Default = DefaultApplicationOptions.DefaultLoggingLevel,
    //            MicrosoftAspNetCore = DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel
    //        };

    //        this.LogLevel = options.LogLevel;
    //        section.Bind(options);
    //    }
        
    //    return config;
    //}


    public LoggingOptions BindOptions(LoggingOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        var section = Configuration.GetSection(LoggingOptions.LoggingName);
        if (section.Exists())
        {
            LogLevelOptions logLevel = new LogLevelOptions()
            {
                Default = section["Default"]?.ToString() ?? DefaultApplicationOptions.DefaultLoggingLevel,
                MicrosoftAspNetCore = section["MicrosoftAspNetCore"]?.ToString()
                    ?? DefaultApplicationOptions.DefaultMicrosoftAspNetCoreLoggingLevel

            };
            options.LogLevel = logLevel;
            this.LogLevel = logLevel;
            section.Bind(options);
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

        return options;
    }
}