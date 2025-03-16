class Program
{
    private static DataManager _dataManager = new DataManager();
    private static Organization _orgBYU = new Organization("Brigham Young University - Idaho");

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            DisplayMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ImportDataMenu();
                    break;
                case "2":
                    ViewDataMenu();
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("\nThank you for using the system. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    PressEnterToContinue();
                    break;
            }
        }
    }

    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine($"=== School Management System ===");
        Console.WriteLine($"{_orgBYU.GetOrganizationDetails()}");
        Console.WriteLine("1. Import Data");
        Console.WriteLine("2. View Data");
        Console.WriteLine("3. Exit");
        Console.Write("\nPlease select an option: ");
    }

    private static void ImportDataMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Import Data ===");
            Console.WriteLine("1. Import Users");
            Console.WriteLine("2. Import Courses");
            Console.WriteLine("3. Import Class Schedules");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _dataManager.ImportUsers("DataFile/UsersImport.csv");
                    Console.WriteLine("\nUsers imported successfully!");
                    PressEnterToContinue();
                    break;
                case "2":
                    _dataManager.ImportCourses("DataFile/CoursesImport.csv");
                    Console.WriteLine("\nCourses imported successfully!");
                    PressEnterToContinue();
                    break;
                case "3":
                    _dataManager.ImportSchedules("DataFile/ClassSchedulesImport.csv");
                    Console.WriteLine("\nClass schedules imported successfully!");
                    PressEnterToContinue();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    PressEnterToContinue();
                    break;
            }
        }
    }

    private static void ViewDataMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== View Data ===");
            Console.WriteLine("1. User Data");
            Console.WriteLine("2. Course Data");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewUserDataMenu();
                    break;
                case "2":
                    ViewCourseDataMenu();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    PressEnterToContinue();
                    break;
            }
        }
    }

    private static void ViewUserDataMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== User Data ===");
            Console.WriteLine("1. View Specific User Data and Schedule");
            Console.WriteLine("2. List All Users");
            Console.WriteLine("3. Return to Previous Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter User ID: ");
                    string userId = Console.ReadLine();
                    ViewUserDetails(userId);
                    break;
                case "2":
                    ListAllUsers();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    PressEnterToContinue();
                    break;
            }
        }
    }

    private static void ViewCourseDataMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Course Data ===");
            Console.WriteLine("1. View Course Roster (All Courses)");
            Console.WriteLine("2. View Specific Course Schedules");
            Console.WriteLine("3. Return to Previous Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListAllCourses();
                    break;
                case "2":
                    Console.Write("\nEnter Course ID: ");
                    string courseId = Console.ReadLine();
                    ViewCourseSchedules(courseId);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    PressEnterToContinue();
                    break;
            }
        }
    }

    private static void ViewUserDetails(string userId)
    {
        Console.Clear();
        var users = _dataManager.GetAllUsers();
        var user = users.Find(u => u.GetUserId() == userId);

        if (user == null)
        {
            Console.WriteLine($"\nUser with ID {userId} not found.");
            PressEnterToContinue();
            return;
        }

        Console.WriteLine($"\nUser Details for {userId}:");
        Console.WriteLine($"Name: {user.GetFirstName()} {user.GetLastName()}");
        Console.WriteLine($"Email: {user.GetEmail()}");
        Console.WriteLine($"Role: {user.GetRole()}");

        if (user is Teacher teacher)
        {
            Console.WriteLine($"Department: {teacher.GetDepartment()}");
        }
        else if (user is Student student)
        {
            Console.WriteLine($"Major: {student.GetMajor()}");
        }

        PressEnterToContinue();
    }

    private static void ListAllUsers()
    {
        Console.Clear();
        var users = _dataManager.GetAllUsers(); // varKeyword.md
        
        Console.WriteLine("\nAll Users:");
        Console.WriteLine("Teachers:");
        foreach (var user in users.Where(u => u is Teacher)) // linq.md -- using a where "clause" to find all teachers
        {
            Console.WriteLine($"{user.GetUserId()} - {user.GetFirstName()} {user.GetLastName()} ({user.GetEmail()})");
        }

        Console.WriteLine("\nStudents:");
        foreach (var user in users.Where(u => u is Student)) // linq.md -- using a where "clause" to find all students
        {
            Console.WriteLine($"{user.GetUserId()} - {user.GetFirstName()} {user.GetLastName()} ({user.GetEmail()})");
        }

        PressEnterToContinue();
    }

    private static void ListAllCourses()
    {
        Console.Clear();
        var courses = _dataManager.GetAllCourses(); // varKeyword.md
        var users = _dataManager.GetAllUsers(); // varKeyword.md 

        Console.WriteLine("\nCourse Roster:");
        foreach (var course in courses)
        {
            Console.WriteLine($"\nCourse: {course.GetCourseId()} - {course.GetCourseName()}");
            var teacher = users.Find(u => u.GetUserId() == course.GetTeacherId());
            Console.WriteLine($"Teacher: {teacher?.GetFirstName()} {teacher?.GetLastName()}");
        }

        PressEnterToContinue();
    }

    private static void ViewCourseSchedules(string courseId)
    {
        Console.Clear();
        var courses = _dataManager.GetAllCourses();
        var schedules = _dataManager.GetAllSchedules();
        var course = courses.Find(c => c.GetCourseId() == courseId); // linq.md  

        if (course == null)
        {
            Console.WriteLine($"\nCourse with ID {courseId} not found.");
            PressEnterToContinue();
            return;
        }

        Console.WriteLine($"\nSchedules for Course: {course.GetCourseId()} - {course.GetCourseName()}");
        var courseSchedules = schedules.Where(s => s.GetCourseId() == courseId);

        foreach (var schedule in courseSchedules)
        {
            Console.WriteLine($"\nSchedule ID: {schedule.GetScheduleId()}");
            Console.WriteLine($"Room: {schedule.GetRoomNumber()}");
            Console.WriteLine($"Days: {string.Join(", ", schedule.GetDaysOfWeek())}");
            Console.WriteLine($"Time: {schedule.GetStartTime()[0]} - {schedule.GetEndTime()[0]}");
        }

        PressEnterToContinue();
    }

    private static void PressEnterToContinue()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}