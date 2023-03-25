using ConsoleAppSettingsOptions.Library.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppSettingsOptions.Library.Options;

public class ComplexPackageOptions : AbstractConfigurationOptions, IConfigurationOptions<ComplexPackageOptions>
{
    public const string ComplexPackageOptionsName = "Packages";

    private string _name = String.Empty;
    private List<string> _items = new List<string>();

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public List<string> Items
    {
        get => _items;
        set => _items = value;
    }

    public ComplexPackageOptions BindOptions(ComplexPackageOptions options)
    {
        if (Configuration == null)
        {
            return options;
        }

        IConfigurationSection section = Configuration.GetSection(ComplexPackageOptionsName);
        if (section.Exists())
        {
            string nameAttribute = "Name";
            string itemsAttribute = "Items";
                
            this.Name = section.GetSection(nameAttribute).Get<string>();
            this.Items = section.GetSection(itemsAttribute).Get<List<string>>() ?? new List<string>();
            options.Name = this.Name;
            options.Items = this.Items;
            //section.Bind(options); // If you bind, you may end up with duplicate key values here 
        }
        else
        {
            this.Name = DefaultApplicationOptions.DefaultComplexPackageOptionName;
            this.Items = DefaultApplicationOptions.DefaultComplexPackageItems;
            options.Name = this.Name;
            options.Items = this.Items;
            section.Bind(options);
        }

        return options;
    }
}