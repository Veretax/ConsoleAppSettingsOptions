using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class TwoNestedValueOptions : AbstractConfigurationOptions, IConfigurationOptions<TwoNestedValueOptions>
{
    private string _stringKey1 = string.Empty;
    private int _intKey2 = 0;
    public const string TwoNestedValueName = "TwoNestedValue";

    public string StringKey1
    {
        get => _stringKey1;
        set => _stringKey1 = value;
    }

    public int IntKey2
    {
        get => _intKey2;
        set => _intKey2 = value;
    }

    //public IConfiguration GetSection(IConfiguration config)
    //{
    //    TwoNestedValueOptions options = new();
    //    var section = config.GetSection(TwoNestedValueOptions.TwoNestedValueName);

    //    if (section.Exists())
    //    {
    //        options.IntKey2 = Convert.ToInt32(section["IntKey2"]);
    //        options.StringKey1 = section["StringKey1"] ?? string.Empty;
    //        this.IntKey2 = options.IntKey2;
    //        this.StringKey1 = options.StringKey1;
    //        section.Bind(options, binder =>
    //        {
    //            binder.BindNonPublicProperties = true;
    //            //this.IntKey2 = section.GetValue<int>("IntKey2");
    //            //this.StringKey1 = section.GetValue<string>("StringKey1");
    //        });
    //    }
    //    else
    //    {
    //        options.StringKey1 = string.Empty; ;
    //        options.IntKey2 = 0;
    //        this.StringKey1 = string.Empty;
    //        this.IntKey2 = 0;
    //        section.Bind(options);
    //    }
        
    //    return config;

    //}

    public TwoNestedValueOptions BindOptions(TwoNestedValueOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        var section = Configuration.GetSection(TwoNestedValueOptions.TwoNestedValueName);

        if (section.Exists())
        {
            section.GetChildren();

            options.IntKey2 = Convert.ToInt32(section["IntKey2"]);
            options.StringKey1 = section["StringKey1"] ?? string.Empty;
            this.IntKey2 = options.IntKey2;
            this.StringKey1 = options.StringKey1;

            section.Bind(options);
        }
        else
        {
            options.StringKey1 = string.Empty; ;
            options.IntKey2 = 0;
            this.StringKey1 = string.Empty;
            this.IntKey2 = 0;
            section.Bind(options);
        }

        return options;
    }
}