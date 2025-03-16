public abstract class User 
{
    private string _userId;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _role;

    public User(string userId, string firstName, string lastName, string email, string role)
    {
        _userId = userId;
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _role = role;
    }

    public virtual void DisplayUserDetails()
    {
        Console.WriteLine($"User ID: {_userId}");
        Console.WriteLine($"Name: {_firstName} {_lastName}");
        Console.WriteLine($"Email: {_email}");
        Console.WriteLine($"Role: {_role}");
    }

    public string GetUserId()
    {
        return _userId;
    }

    public string GetFirstName()
    {
        return _firstName;
    }

    public string GetLastName()
    {
        return _lastName;
    }

    public string GetEmail()
    {
        return _email;
    }

    public string GetRole()
    {
        return _role;
    }

} 