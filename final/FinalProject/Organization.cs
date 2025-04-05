using System.Collections.Generic;
using System.Linq;
using System;

public class Organization 
{
    private string _name;
    private List<string> _availableMajors = new List<string>
    {
        "Computer Science",
        "Software Engineering",
        "Information Technology",
        "Computer Information Technology",
        "Data Science",
        "Business Management",
        "Accounting",
        "Finance",
        "Marketing",
        "Human Resource Management",
        "Psychology",
        "Sociology",
        "Social Work",
        "Elementary Education",
        "Secondary Education",
        "Exercise Physiology",
        "Biology",
        "Chemistry",
        "Physics",
        "Mathematics",
        "English",
        "History",
        "Political Science",
        "Art",
        "Music",
        "Theater",
        "Communication",
        "Journalism",
        "Family Studies",
        "Marriage and Family Studies"
    };

    private List<string> _availableDepartments = new List<string>
    {
        "Computer Science",
        "Information Technology",
        "Business",
        "Accounting",
        "Finance",
        "Marketing",
        "Management",
        "Psychology",
        "Sociology",
        "Social Work",
        "Education",
        "Exercise Science",
        "Biology",
        "Chemistry",
        "Physics",
        "Mathematics",
        "English",
        "History",
        "Political Science",
        "Art",
        "Music",
        "Theater",
        "Communication",
        "Journalism",
        "Family Studies",
        "Religious Education",
        "Languages",
        "Philosophy",
        "Economics",
        "Agriculture"
    };

    private List<string> _availableRooms = new List<string>
    {
        "A101", "A102", "A103", "A104", "A105", "A106", "A107", "A108", "A109", "A110", "A111", "A112", "A113", "A114", "A115", "A116",
        "B101", "B102", "B103", "B104", "B105", "B106", "B107", "B108", "B109", "B110", "B111", "B112", "B113", "B114", "B115", "B116",
        "C101", "C102", "C103", "C104", "C105", "C106", "C107", "C108", "C109", "C110", "C111", "C112", "C113", "C114", "C115", "C116",
        "D101", "D102", "D103", "D104", "D105", "D106", "D107", "D108", "D109", "D110", "D111", "D112", "D113", "D114", "D115", "D116",
        "E101", "E102", "E103", "E104", "E105", "E106", "E107", "E108", "E109", "E110", "E111", "E112", "E113", "E114", "E115", "E116"
    };

    public Organization(string name)
    {
        _name = name;
    }

    public string GetOrganizationDetails()
    {
        return $"Organization Name: {_name}";
    }

    public List<string> GetAvailableMajors()
    {
        return _availableMajors;
    }

    public string GetMajorByIndex(int index) // easy way for the user to enter the indedx instead of the whole name
    {
        if (index >= 0 && index < _availableMajors.Count)
        {
            return _availableMajors[index];
        }
        return null;
    }

    public List<string> GetAvailableDepartments()
    {
        return _availableDepartments;
    }

    public string GetDepartmentByIndex(int index) // easy way for the user to enter the index instead of the whole name
    {
        if (index >= 0 && index < _availableDepartments.Count)
        {
            return _availableDepartments[index];
        }
        return null;
    }

    public List<string> GetAvailableRooms()
    {
        return _availableRooms;
    }

    public string GetRoomByIndex(int index) // Like above, for when the rooms are displayed when adding a new schedule
    {
        if (index >= 0 && index < _availableRooms.Count)
        {
            return _availableRooms[index];
        }
        return null;
    }

    public bool IsRoomAvailable(string roomNumber, List<string> daysOfWeek, string startTime, string endTime, List<ClassSchedule> existingSchedules)
    {
        foreach (var schedule in existingSchedules)
        {
            if (schedule.GetRoomNumber() == roomNumber)
            {
                // Check if there's any overlap in days
                var overlappingDays = schedule.GetDaysOfWeek().Intersect(daysOfWeek);
                if (overlappingDays.Any())
                {
                    // Check if there's a time overlap
                    var scheduleStart = TimeSpan.Parse(schedule.GetStartTime()[0]);
                    var scheduleEnd = TimeSpan.Parse(schedule.GetEndTime()[0]);
                    var newStart = TimeSpan.Parse(startTime);
                    var newEnd = TimeSpan.Parse(endTime);

                    if ((newStart >= scheduleStart && newStart < scheduleEnd) ||
                        (newEnd > scheduleStart && newEnd <= scheduleEnd) ||
                        (newStart <= scheduleStart && newEnd >= scheduleEnd))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public List<string> GetAvailableRoomsForSchedule(List<string> daysOfWeek, string startTime, string endTime, List<ClassSchedule> existingSchedules)
    {
        return _availableRooms.Where(room => IsRoomAvailable(room, daysOfWeek, startTime, endTime, existingSchedules)).ToList();
    }

    public string SelectDepartment()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Select Department ===");
            Console.WriteLine("\nAvailable Departments:");
            
            var departments = GetAvailableDepartments();
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
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    public string SelectMajor()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Select Major ===");
            Console.WriteLine("\nAvailable Majors:");
            
            var majors = GetAvailableMajors();
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
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}