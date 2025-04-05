using System;
using System.Collections.Generic;

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

    public override void AddNewUser(DataManager dataManager, Organization organization)
    {
        string teacherId = dataManager.GenerateUserId();
        Dictionary<string, string> teacherData = new Dictionary<string, string>();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Add New Teacher ===");
            
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            
            string department = SelectDepartment(organization);

            teacherData = new Dictionary<string, string>
            {
                { "Teacher ID", teacherId },
                { "First Name", firstName },
                { "Last Name", lastName },
                { "Email", email },
                { "Department", department }
            };

            if (ConfirmDataEntry("Add New Teacher", teacherData))
            {
                Teacher newTeacher = new Teacher(teacherId, firstName, lastName, email, "teacher", department);
                dataManager.AddUser(newTeacher);
                Console.WriteLine("\nTeacher added successfully!");
                PressEnterToContinue();
                break;
            }
        }
    }

    private string SelectDepartment(Organization organization)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Select Department ===");
            Console.WriteLine("\nAvailable Departments:");
            
            var departments = organization.GetAvailableDepartments();
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {departments[i]}");
            }
            
            Console.Write("\nEnter the number of your department: ");
            if (int.TryParse(Console.ReadLine(), out int selection) && selection > 0 && selection <= departments.Count)
            {
                return departments[selection - 1];
            }
            
            Console.WriteLine("\nInvalid selection. Please try again.");
            PressEnterToContinue();
        }
    }

    private void PressEnterToContinue()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
} 