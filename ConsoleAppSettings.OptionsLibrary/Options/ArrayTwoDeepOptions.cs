using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class ArrayTwoDeepOptions : AbstractConfigurationOptions, IConfigurationOptions<ArrayTwoDeepOptions>
{
    public const string ArrayTwoDeepName = "ArrayTwoDeepOptions";

    private PackageOptions _packages = new PackageOptions();

    public PackageOptions Packages
    {
        get => _packages;
        set => _packages = value;
    }

    public ArrayTwoDeepOptions BindOptions(ArrayTwoDeepOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        IConfigurationSection section = Configuration.GetSection(ArrayTwoDeepName);
        if (section.Exists())
        {
            if (section.Path != null)
            {
                this.Packages = section.Get<PackageOptions>() ?? new PackageOptions();
                options.Packages = this.Packages;
            }
            section.Bind(options);
        }
        else
        {
            this.Packages = new PackageOptions();
            this.Packages.Packages = DefaultApplicationOptions.DefaultPackageOptionsArray;
            options.Packages = this.Packages;
            section.Bind(options);
        }

        return options;
    }
}