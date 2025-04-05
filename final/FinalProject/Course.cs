using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    private string _courseId;
    private string _courseName;
    private string _teacherId;


    public Course(string courseId, string courseName, string teacherId)
    {
        _courseId = courseId;
        _courseName = courseName;
        _teacherId = teacherId;
    }

    public override string ToString()
    {
        return $"Course ID: {_courseId}, Course Name: {_courseName}, Teacher ID: {_teacherId}";
    }

    public string GetCourseId()
    {
        return _courseId;
    }

    public string GetCourseName()
    {
        return _courseName;
    }

    public string GetTeacherId()
    {
        return _teacherId;
    }

    public void AddNewCourse(DataManager dataManager)
    {
        var teachers = dataManager.GetAllUsers().Where(u => u is Teacher).ToList();
        if (teachers.Count == 0)
        {
            Console.WriteLine("\nNo teachers available. Please add a teacher first.");
            return;
        }

        Console.Write("Enter Course ID: ");
        string courseId = Console.ReadLine();
        
        Console.Write("Enter Course Name: ");
        string courseName = Console.ReadLine();

        Console.WriteLine("\nAvailable Teachers:");
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"{teacher.GetUserId()} - {teacher.GetFirstName()} {teacher.GetLastName()}");
        }

        Console.Write("\nEnter Teacher ID: ");
        string teacherId = Console.ReadLine();

        if (teachers.Any(t => t.GetUserId() == teacherId))
        {
            Course newCourse = new Course(courseId, courseName, teacherId);
            dataManager.AddCourse(newCourse);
            Console.WriteLine("\nCourse added successfully!");
        }
        else
        {
            Console.WriteLine("\nInvalid Teacher ID.");
        }
    }

    public void DisplaySchedules(List<ClassSchedule> schedules)
    {
        var courseSchedules = schedules.Where(s => s.GetCourseId() == this.GetCourseId());
        
        Console.WriteLine($"\nSchedules for Course: {this.GetCourseId()} - {this.GetCourseName()}");
        foreach (var schedule in courseSchedules)
        {
            Console.WriteLine($"\nSchedule ID: {schedule.GetScheduleId()}");
            Console.WriteLine($"Room: {schedule.GetRoomNumber()}");
            Console.WriteLine($"Days: {string.Join(", ", schedule.GetDaysOfWeek())}");
            Console.WriteLine($"Time: {schedule.GetStartTime()[0]} - {schedule.GetEndTime()[0]}");
        }
    }

    public static void ListAllCourses(DataManager dataManager)
    {
        Console.Clear();
        var courses = dataManager.GetAllCourses();
        var users = dataManager.GetAllUsers();

        Console.WriteLine("\nCourse Roster:");
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses available. Please import data.");
        }
        else
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"\nCourse: {course.GetCourseId()} - {course.GetCourseName()}");
                var teacher = users.Find(u => u.GetUserId() == course.GetTeacherId());
                Console.WriteLine($"Teacher: {teacher?.GetFirstName()} {teacher?.GetLastName()}");
            }
        }
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
} 