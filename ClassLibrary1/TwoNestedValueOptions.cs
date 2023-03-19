using Microsoft.Extensions.Configuration;

namespace ClassLibrary1;

public class TwoNestedValueOptions
{
    public const string TwoNestedValueName = "TwoNestedValue";
    public string StringKey1 { get; set; }
    public int IntKey2 { get; set; }

    public IConfiguration GetSection(IConfiguration? config)
    {
        TwoNestedValueOptions options = new();
        var section = config.GetSection(TwoNestedValueName);

        if (section.Exists())
        {
            section
                .Bind(options, binder => {
                    binder.BindNonPublicProperties = true; // Include private properties
                    binder.OnPropertyValidating += (ctx) => {
                        // Use default values for missing keys
                        if (ctx.Value == null)
                        {
                            switch (ctx.Property.Name)
                            {
                                case "StringKey1":
                                    ctx.Value = string.Empty;
                                    break;
                                case "IntValue2":
                                    ctx.Value = 0;
                                    break;
                            }
                        }
                    };
                });
        }
        else
        {
            StringKey1 = string.Empty;
            IntKey2 = 0;
            options.StringKey1 = StringKey1;
            options.IntKey2 = IntKey2;
            section.Bind(options);
        }

        return config;

    }
}