using System;
using System.Collections.Generic;
using System.Linq;

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

    public abstract void AddNewUser(DataManager dataManager, Organization organization);

    protected bool ConfirmDataEntry(string title, Dictionary<string, string> data)
    {
        Console.Clear();
        Console.WriteLine($"=== {title} ===");
        Console.WriteLine("\nPlease review your entries:");
        foreach (var entry in data)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        
        Console.WriteLine("\nIs this information correct?");
        Console.WriteLine("1. Yes, save the data");
        Console.WriteLine("2. No, go back and edit");
        Console.Write("\nPlease select an option: ");
        
        string choice = Console.ReadLine();
        return choice == "1";
    }

    public static void ListAllUsers(DataManager dataManager)
    {
        var users = dataManager.GetAllUsers();
        if (users.Count == 0)
        {
            Console.WriteLine("\nNo users available. Please import data.");
            return;
        }

        Console.Clear();
        Console.WriteLine("\nAll Users:");
        Console.WriteLine("Teachers:");
        foreach (var user in users.Where(u => u is Teacher))
        {
            Console.WriteLine($"{user.GetUserId()} - {user.GetFirstName()} {user.GetLastName()} ({user.GetEmail()})");
        }

        Console.WriteLine("\nStudents:");
        foreach (var user in users.Where(u => u is Student))
        {
            Console.WriteLine($"{user.GetUserId()} - {user.GetFirstName()} {user.GetLastName()} ({user.GetEmail()})");
        }
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
} 