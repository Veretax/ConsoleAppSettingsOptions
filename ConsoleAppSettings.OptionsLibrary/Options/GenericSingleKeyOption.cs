using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class GenericSingleKeyOption<T>
{
    private string _key;
    private T _value;
    
    public string Key => _key;

    public T Value
    {
        get => _value;
        set => _value = value;
    }

    public GenericSingleKeyOption(string singleKeyName)
    {
        _key = singleKeyName;
    }

    public IConfigurationSection GetSection(IConfiguration config, T defaultValue)
    {
        GenericSingleKeyOption<T> options = new GenericSingleKeyOption<T>(this.Key);
        IConfigurationSection section = config.GetSection(Key);
        if (section.Exists())
        {
            section.Bind(this);
        }
        else
        {
            options.Value = defaultValue;
            this.Value = defaultValue;
            section.Value = defaultValue.ToString();
            section.Bind(this.Key,this.Value);
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