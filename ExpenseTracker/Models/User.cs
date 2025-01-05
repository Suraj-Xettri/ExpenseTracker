namespace ExpenseTracker.Models;

public class UserModel

{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Currency { get; set; }
    public InflowModel Inflow { get; set; } = new InflowModel();
    public OutflowModel Outflow { get; set; } = new OutflowModel();
    public DebtsModel Debts { get; set; } = new DebtsModel();
}

public class InflowModel
{
    public List<string> Credit { get; set; } = new List<string>();
    public List<string> Gain { get; set; } = new List<string>();
    public List<string> Budget { get; set; } = new List<string>();
}

public class OutflowModel
{
    public List<string> Debit { get; set; } = new List<string>();
    public List<string> Spending { get; set; } = new List<string>();
    public List<string> Expenses { get; set; } = new List<string>();
}

public class DebtsModel
{
    public List<string> Debt { get; set; } = new List<string>();
    public List<string> ClearedDebt { get; set; } = new List<string>();
    public List<string> PendingDebt { get; set; } = new List<string>();
}
