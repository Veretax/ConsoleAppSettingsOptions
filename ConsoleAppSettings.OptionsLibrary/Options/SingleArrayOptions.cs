using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class SingleArrayOptions : AbstractConfigurationOptions, IConfigurationOptions<SingleArrayOptions>
{
    public const string SingleArrayOptionsName = "SingleArrayOptions";

    private List<string> _options = new List<string>();

    public List<string> Options
    {
        get => _options;
        set => _options = value;
    }

    public SingleArrayOptions BindOptions(SingleArrayOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        IConfigurationSection section = Configuration.GetSection(SingleArrayOptionsName);
        if (section.Exists())
        {
            if (section.Path != null)
            {
                this.Options = section.Get<List<string>>() ?? new List<string>();
                options.Options = this.Options;
            }
            section.Bind(options);
        }
        else
        {
            this.Options = DefaultApplicationOptions.DefaultSingleArray;
            options.Options = this.Options;
            section.Bind(options);
        }

        return options;
    }
}