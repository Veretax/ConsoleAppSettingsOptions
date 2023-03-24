using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class PackageOptions : AbstractConfigurationOptions, IConfigurationOptions<PackageOptions>
{
    public const string PackageOptionsName = "Packages";

    private List<string> _packages = new List<string>();

    public List<string> Packages
    {
        get => _packages;
        set => _packages = value;
    }

    public PackageOptions BindOptions(PackageOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        IConfigurationSection section = Configuration.GetSection(PackageOptionsName);
        if (section.Exists())
        {
            if (section.Path != null)
            {
                this.Packages = section.Get<List<string>>() ?? new List<string>();
                options.Packages = this.Packages;
            }
            section.Bind(options);
        }
        else
        {
            this.Packages = DefaultApplicationOptions.DefaultPackageOptionsArray;
            options.Packages = this.Packages;
            section.Bind(options);
        }

        return options;
    }
}