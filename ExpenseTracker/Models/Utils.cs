
namespace ExpenseTracker.Models;

public static class Utils
{
    public static string GetAppDirectoryPath()
    {
        string appDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ExpenseTracker"
        );

        // Ensure the directory exists
        if (!Directory.Exists(appDirectory))
        {
            Directory.CreateDirectory(appDirectory);
        }

        return appDirectory;
    }

    // Returns the path to the main user data file
    public static string GetUsersFilePath()
    {
        return Path.Combine(GetAppDirectoryPath(), "user.json");
    }

}