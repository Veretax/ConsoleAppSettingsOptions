namespace ConsoleAppSettingsOptions.Library.Exceptions;

public class FileNotFoundExceptionMessage
{
    public const string DefaultFileNotFoundExceptionMessage = "The config file does not exist.";


    public static string GetFileNotFoundExceptionMessage(string filePath)
    {
        string msg = $"{DefaultFileNotFoundExceptionMessage} (Parameter '{filePath}')";
        return msg;

    }

}