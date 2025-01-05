using System.Data;
using System.Text.Json;
namespace ExpenseTracker.Models;

public static class UserService
{
    private static GlobalState _globalState = new GlobalState(); // You can pass this instance globally in your app

    private static void SaveUser(List<UserModel> users)
    {
        string appDataDirectoryPath = Utils.GetAppDirectoryPath();
        string appUsersFilePath = Utils.GetUsersFilePath();

        if (!Directory.Exists(appDataDirectoryPath))
        {
            Directory.CreateDirectory(appDataDirectoryPath);
        }

        var json = JsonSerializer.Serialize(users);
        File.WriteAllText(appUsersFilePath, json);
    }

    public static List<UserModel> GetAll()
    {
        string appUsersFilePath = Utils.GetUsersFilePath();
        if (!File.Exists(appUsersFilePath))
        {
            return new List<UserModel>();
        }

        var json = File.ReadAllText(appUsersFilePath);

        return JsonSerializer.Deserialize<List<UserModel>>(json);
    }

    public static List<UserModel> Create(Guid userId, string username, string password, string email, string currency)
    {
        List<UserModel> users = GetAll();
        bool usernameExists = users.Any(x => x.UserName == username);

        if (usernameExists)
        {
            throw new Exception("Username already exists.");
        }

        users.Add(
            new UserModel
            {
                UserName = username,
                Password = password,
                Email = email,
                Currency = currency  
            }
        );
        SaveUser(users);
        return users;
    }

    public static UserModel GetById(Guid id)
    {
        List<UserModel> users = GetAll();
        return users.FirstOrDefault(x => x.Id == id);
    }


    public static UserModel Login(string username, string password)
    {
        var loginErrorMessage = "Invalid username or password.";
        List<UserModel> users = GetAll();
        UserModel user = users.FirstOrDefault(x => x.UserName == username);

        if (user == null)
        {
            throw new Exception(loginErrorMessage);
        }

        bool passwordIsValid = (password == user.Password);

        if (!passwordIsValid)
        {
            throw new Exception(loginErrorMessage);
        }
        // Set the current user globally
        _globalState.SetCurrentUser(user);
        return user;
    }


}
