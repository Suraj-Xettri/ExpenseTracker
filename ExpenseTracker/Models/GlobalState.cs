namespace ExpenseTracker.Models;

public class GlobalState
{
    public UserModel CurrentUser { get; set; }

    public void SetCurrentUser(UserModel user)
    {
        CurrentUser = user;
    }

    public UserModel GetCurrentUser()
    {
        return CurrentUser;
    }
}
