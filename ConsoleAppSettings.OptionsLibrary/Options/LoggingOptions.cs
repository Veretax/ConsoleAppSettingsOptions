using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public sealed class LoggingOptions
{
    public const string LoggingName = "Logging";
    public LogLevelOptions? LogLevel { get; set; } = new LogLevelOptions();
    
    public IConfiguration GetSection(IConfiguration config)
    {
        config = config.GetSection(LoggingOptions.LoggingName);
        LogLevel = LogLevel?.GetSection(config).Get<LogLevelOptions>();
        return config;
    }
}