using System;
using System.Collections.Generic;

public class Student : User
{
    private string _major;
    private List<string> _enrolledCourses;

    public Student(string userId, string firstName, string lastName, string email, string role, string major) 
        : base(userId, firstName, lastName, email, role)
    {
        _major = major;
        _enrolledCourses = new List<string>();
    }

    public override void DisplayUserDetails()
    {
        base.DisplayUserDetails();
        Console.WriteLine($"Major: {_major}");
    }

    public void EnrollCourse(string courseId) // TODO - Need to add ability for students to enroll
    {
        _enrolledCourses.Add(courseId);
    }

    public List<string> GetEnrolledCourses() // TODO - Need to add ability for students to enroll
    {
        return _enrolledCourses;
    }

    public string GetMajor()
    {
        return _major;
    }

    public override void AddNewUser(DataManager dataManager, Organization organization)
    {
        string studentId = dataManager.GenerateUserId();
        Dictionary<string, string> studentData = new Dictionary<string, string>();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Add New Student ===");
            
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            
            string major = SelectMajor(organization);

            studentData = new Dictionary<string, string>
            {
                { "Student ID", studentId },
                { "First Name", firstName },
                { "Last Name", lastName },
                { "Email", email },
                { "Major", major }
            };

            if (ConfirmDataEntry("Add New Student", studentData))
            {
                Student newStudent = new Student(studentId, firstName, lastName, email, "student", major);
                dataManager.AddUser(newStudent);
                Console.WriteLine("\nStudent added successfully!");
                PressEnterToContinue();
                break;
            }
        }
    }

    private string SelectMajor(Organization organization)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Select Major ===");
            Console.WriteLine("\nAvailable Majors:");
            
            var majors = organization.GetAvailableMajors();
            for (int i = 0; i < majors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {majors[i]}");
            }
            
            Console.Write("\nEnter the number of your major: ");
            if (int.TryParse(Console.ReadLine(), out int selection) && selection > 0 && selection <= majors.Count)
            {
                return majors[selection - 1];
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