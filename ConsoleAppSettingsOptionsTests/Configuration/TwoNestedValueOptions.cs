using ConsoleAppSettingsOptions.Library.Options;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Tests.Configuration;

public class TwoNestedValueOptions
{
    public const string TwoNestedValueName = "TwoNestedValue";
    public string StringKey1 { get; set; }
    public int IntKey2 { get; set; }

    internal object GetSection(IConfiguration? config)
    {
        TwoNestedValueOptions options = new();

        config.GetSection(TwoNestedValueName)
            .Bind(options);
        return config;
    }
}