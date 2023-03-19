using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class GenericSingleKeyOption<T>
{
    public string OptionName = "GenericOptionName";
    private string _key;
    private T _value;

    public T OptionValue { get; set; }

    public string Key => _key;

    public T Value
    {
        get => _value;
        set => _value = value;
    }

    public GenericSingleKeyOption(string singleKeyName)
    {
        OptionName = singleKeyName;
        _key = singleKeyName;
    }

    public IConfigurationSection GetSection(IConfiguration config, T defaultValue)
    {
        IConfigurationSection section = config.GetSection(Key);
        if (section.Exists())
        {
            section.Bind(this);
        }
        else
        {
            Value = defaultValue;
        }
        return section;
    }

    /// <summary>
    /// Gets the Configuration Section for the AllowedHostsName
    /// </summary>
    /// <param name="config">The configuration option</param>
    /// <param name="defaultValue">The default object to use in the event the section does not exist</param>
    /// <returns>the configuration after processing the section</returns>
    //public IConfiguration GetSection<T>(IConfiguration config, object defaultValue) where T : class
    //{
    //    GenericSingleKeyOption<T> options;
    //    options = new GenericSingleKeyOption<T>(this.OptionName);

    //    IConfigurationSection section = config.GetSection(OptionName);
    //    if (section.Exists())
    //    {
    //        section.Bind(options);
    //    }
    //    else
    //    {
    //        OptionValue = defaultValue;
    //    }
    //    return config;

    //}
}