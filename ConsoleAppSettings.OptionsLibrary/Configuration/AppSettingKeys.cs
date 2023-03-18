namespace ConsoleAppSettingsOptions.Library.Configuration;

public static class AppSettingKeys
{
    private static readonly string _applicationNameKey = "AppSettings:ApplicationName";
    private static readonly string _applicationVersionKey = "AppSettings:ApplicationVersion";
    private static readonly string _agincourtModulelist = "MvcOptions:ModuleList";
    private static readonly string _cacheProfile = "MvcOptions:CacheProfile";

    public static string ApplicationNameKey => _applicationNameKey;

    public static string ApplicationVersionKey => _applicationVersionKey;

    public static string AgincourtModulelist => _agincourtModulelist;

    public static string CacheProfile => _cacheProfile;
}