using System;
using System.Collections.Generic;
using System.Linq;

public class ClassSchedule
{
    private string _scheduleId;
    private string _courseId;
    private string _roomNumber;
    private List<string> _daysOfWeek;
    private List<string> _startTime;
    private List<string> _endTime;

    public ClassSchedule(string scheduleId, string courseId, string roomNumber, 
                        List<string> daysOfWeek, List<string> startTime, List<string> endTime)
    {
        _scheduleId = scheduleId;
        _courseId = courseId;
        _roomNumber = roomNumber;
        _daysOfWeek = daysOfWeek;
        _startTime = startTime;
        _endTime = endTime;
    }

    public string GetScheduleId()
    {
        return _scheduleId;
    }

    public string GetCourseId()
    {
        return _courseId;
    }

    public string GetRoomNumber()
    {
        return _roomNumber;
    }

    public List<string> GetDaysOfWeek()
    {
        return _daysOfWeek;
    }

    public List<string> GetStartTime()
    {
        return _startTime;
    }

    public List<string> GetEndTime()
    {
        return _endTime;
    }

    public override string ToString()
    {
        return $"Schedule ID: {_scheduleId}, Course ID: {_courseId}, Room: {_roomNumber}";
    }

    public void AddNewSchedule(DataManager dataManager, Organization organization)
    {
        var courses = dataManager.GetAllCourses();
        if (courses.Count == 0)
        {
            Console.WriteLine("\nNo courses available. Please add a course first.");
            return;
        }

        Console.WriteLine("\nAvailable Courses:");
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.GetCourseId()} - {course.GetCourseName()}");
        }

        Console.Write("\nEnter Course ID: ");
        string courseId = Console.ReadLine();

        var selectedCourse = courses.Find(c => c.GetCourseId() == courseId);
        if (selectedCourse != null)
        {
            Console.WriteLine("\nEnter Days of Week (comma-separated, e.g., Monday,Wednesday,Friday):");
            string daysInput = Console.ReadLine();
            List<string> daysOfWeek = daysInput.Split(',').Select(d => d.Trim()).ToList();

            Console.WriteLine("\nEnter times in HH:MM format (24-hour)");
            Console.Write("Enter Start Time (HH:MM): ");
            string startTime = Console.ReadLine();
            Console.Write("Enter End Time (HH:MM): ");
            string endTime = Console.ReadLine();

            if (!IsValidTimeFormat(startTime) || !IsValidTimeFormat(endTime))
            {
                Console.WriteLine("\nInvalid time format. Please use HH:MM format (24-hour).");
                return;
            }

            var availableRooms = organization.GetAvailableRoomsForSchedule(
                daysOfWeek, 
                startTime, 
                endTime, 
                dataManager.GetAllSchedules()
            );

            if (availableRooms.Count > 0)
            {
                string roomNumber = SelectRoom(availableRooms);
                
                ClassSchedule newSchedule = new ClassSchedule(
                    dataManager.GenerateScheduleId(),
                    courseId,
                    roomNumber,
                    daysOfWeek,
                    new List<string> { startTime },
                    new List<string> { endTime }
                );

                dataManager.AddSchedule(newSchedule);
                Console.WriteLine("\nSchedule added successfully!");
            }
            else
            {
                Console.WriteLine("\nNo rooms available for the selected schedule. Please try different days or times.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid Course ID.");
        }
    }

    private string SelectRoom(List<string> availableRooms)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Select Room ===");
            Console.WriteLine("\nAvailable Rooms:");
            
            for (int i = 0; i < availableRooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableRooms[i]}");
            }
            
            Console.Write("\nEnter the number of your room: ");
            if (int.TryParse(Console.ReadLine(), out int selection) && selection > 0 && selection <= availableRooms.Count)
            {
                return availableRooms[selection - 1];
            }
            
            Console.WriteLine("\nInvalid selection. Please try again.");
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    private bool IsValidTimeFormat(string time)
    {
        try
        {
            var parts = time.Split(':');
            if (parts.Length != 2) return false;

            if (!int.TryParse(parts[0], out int hours) || !int.TryParse(parts[1], out int minutes))
                return false;

            return hours >= 0 && hours < 24 && minutes >= 0 && minutes < 60;
        }
        catch
        {
            return false;
        }
    }
} 