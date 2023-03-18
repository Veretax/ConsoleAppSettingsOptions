using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;
using ConsoleAppSettingsOptions.Library.Exceptions;

namespace ConsoleAppSettings.OptionsLibrary.Configuration;

public class ConsoleOptionsJsonConfig
{
    public static IConfigurationRoot? LoadJsonConfig(string filePath)
    {
        if (File.Exists(filePath))
        {
            if (ConsoleOptionsJsonConfig.IsEmptyJsonFile(filePath))
            {
                return new ConfigurationManager();
            }

            var config =  new ConfigurationBuilder()
                .AddJsonFile(filePath).Build();

            return config;
        }
        else
        {
            string errorMsg = FileNotFoundExceptionMessage.GetFileNotFoundExceptionMessage(filePath);
            // The file does not exist
            throw new FileNotFoundException(errorMsg, filePath);
        }
        
    }

    

    public static bool IsEmptyJsonFile(string filePath)
    {
        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read the contents of the file into a string
            string fileContents = File.ReadAllText(filePath);

            // Parse the JSON data from the file
            JsonElement configElement = JsonDocument.Parse(fileContents).RootElement;

            // Check if the config object is empty
            if (configElement.ValueKind == JsonValueKind.Object && !configElement.EnumerateObject().Any())
            {
                // The config file is empty
                return true;
            }
            else
            {
                // The config file is not empty
                return false;
            }
        }
        else
        {
            // The file does not exist
            throw new FileNotFoundException("The config file does not exist.", filePath);
        }
    }

}