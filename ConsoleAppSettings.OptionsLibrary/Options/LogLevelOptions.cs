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
        options = config.GetSection(LogLevelOptions.LogLevelName).Get<LogLevelOptions>();
        config.GetSection(LogLevelOptions.LogLevelName)
            .Bind(options);
        return config;
    }
}