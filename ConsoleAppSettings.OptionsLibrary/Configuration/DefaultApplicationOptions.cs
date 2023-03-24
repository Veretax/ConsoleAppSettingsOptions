namespace ConsoleAppSettingsOptions.Library.Configuration;

public static class DefaultApplicationOptions
{
    private static readonly string _defaultAgincourtApplicationName = "My Agincourt App";
    private static readonly string _defaultApplicationVersion = "1.0.0.0";
    private static readonly string _defaultAppSettingsFileName = "appsettings.json";
    private static readonly string[] _defaultNoModulesPresentList = new[] { "none" };
    private static readonly string _defaultMicrosoftAspNetCoreLoggingLevel = "Warning";
    private static readonly string _defaultLoggingLevel = "Information";
    private static readonly string _defaultAllowHosts = "*";
    private static readonly string _defaultOneKey = "OneKey";
    private static readonly List<string> _defaultSingleArray = new List<string>()
    {
        "default"
    };
    public static string DefaultAgincourtApplicationName => _defaultAgincourtApplicationName;

    public static string DefaultApplicationVersion => _defaultApplicationVersion;

    public static string DefaultAppSettingsFileName => _defaultAppSettingsFileName;

    public static string[] DefaultNoModulesPresentList => _defaultNoModulesPresentList;

    public static string DefaultMicrosoftAspNetCoreLoggingLevel => _defaultMicrosoftAspNetCoreLoggingLevel;

    public static string DefaultLoggingLevel => _defaultLoggingLevel;

    public static string DefaultAllowHosts => _defaultAllowHosts;

    public static string DefaultOneKey => _defaultOneKey;

    public static List<string> DefaultSingleArray => _defaultSingleArray;
}