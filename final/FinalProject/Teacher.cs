public class Teacher : User
{
    private string _department;

    public Teacher(string userId, string firstName, string lastName, string email, string role, string department)
        : base(userId, firstName, lastName, email, role)
    {
        _department = department;
    }

    public override void DisplayUserDetails()
    {
        base.DisplayUserDetails();
        Console.WriteLine($"Department: {_department}");
    }

    public string GetDepartment()
    {
        return _department;
    }
} 