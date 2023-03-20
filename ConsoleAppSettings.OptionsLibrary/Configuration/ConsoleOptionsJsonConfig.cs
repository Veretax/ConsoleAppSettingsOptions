using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;
using ConsoleAppSettingsOptions.Library.ExceptionMessages;

namespace ConsoleAppSettings.OptionsLibrary.Configuration;

public class ConsoleOptionsJsonConfig
{
    /// <summary>
    /// Takes a JsonConfig filepath, verifies it is there and not empty,
    /// and then returns the ConfigurationRoot.
    /// </summary>
    /// <param name="filePath">the path to the file</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException">if the file path is not found it will throw this exception.</exception>
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

    /// <summary>
    /// Checks for the existence of an Empty JsonFile 
    /// </summary>
    /// <param name="filePath">the path to the file</param>
    /// <returns>returns true if it has no elements, if it is not an empty file, and has elements then it returns false</returns>
    /// <exception cref="FileNotFoundException">if the file path is not found it will throw this exception.</exception>
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

    /// <summary>
    /// Calculates the full file path, and calls LoadJsonConfig before returning the Configuration
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static IConfiguration? OpenJsonConfigFile(string fileName)
    {
        string filePath = Path.GetFullPath(fileName);
        var config = ConsoleOptionsJsonConfig.LoadJsonConfig(filePath);

        return config;
    }

}