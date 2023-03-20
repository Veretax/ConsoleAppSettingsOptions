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
            section.Value = defaultValue?.ToString();
            section.Bind(this.Key,this.Value);
        }
        return section;
    }
    
}