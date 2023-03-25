using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class MultiNestedSingleArrayOptions : AbstractConfigurationOptions, IConfigurationOptions<MultiNestedSingleArrayOptions>
{
    public const string MultiNestedSingleArrayName = "MultiNestedSingleArray";

    private List<ComplexPackageOptions> _packages = new List<ComplexPackageOptions>();

    public List<ComplexPackageOptions> Packages
    {
        get => _packages;
        set => _packages = value;
    }

    public MultiNestedSingleArrayOptions BindOptions(MultiNestedSingleArrayOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }
        ComplexPackageOptions complexOptions = new ComplexPackageOptions();

        IConfigurationSection section = Configuration.GetSection(MultiNestedSingleArrayName);
        if (section.Exists())
        {
            string packagesAttribute = "Packages";

            this.Packages = new List<ComplexPackageOptions>();
            this.Packages = section.GetSection(ComplexPackageOptions.ComplexPackageOptionsName).Get<List<ComplexPackageOptions>>();

            options.Packages = this.Packages;
            //section.Bind(options); // If you bind, you may end up with duplicate key values here
        }
        else
        {
            complexOptions.Name = DefaultApplicationOptions.DefaultComplexPackageOptionName;
            complexOptions.Items = DefaultApplicationOptions.DefaultComplexPackageItems;

            this.Packages.Add(complexOptions);
            //options.Packages.Add(complexOptions); // If you add the just created defaults to options, it ends up with duplicates.  Even if options don't exist.
            //section.Bind(options);  // If you bind this, then you get duplicated items, don't do this
        }

        return options;
    }
}