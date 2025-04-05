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
                    AddDataMenu();
                    break;
                case "3":
                    ViewDataMenu();
                    break;
                case "4":
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
        Console.WriteLine("2. Add Data");
        Console.WriteLine("3. View Data");
        Console.WriteLine("4. Exit");
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

    private static void AddDataMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Add Data ===");
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. Add New Course");
            Console.WriteLine("3. Add Course Schedule");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewUser();
                    break;
                case "2":
                    var course = new Course("", "", ""); // Temporary values, will be set in AddNewCourse
                    course.AddNewCourse(_dataManager);
                    PressEnterToContinue();
                    break;
                case "3":
                    var schedule = new ClassSchedule("", "", "", new List<string>(), new List<string>(), new List<string>()); // Temporary values
                    schedule.AddNewSchedule(_dataManager, _orgBYU);
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

    private static void AddNewUser()
    {
        Console.Clear();
        Console.WriteLine("=== Add New User ===");
        Console.WriteLine("1. Add Teacher");
        Console.WriteLine("2. Add Student");
        Console.WriteLine("3. Return to Previous Menu");
        Console.Write("\nPlease select an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                new Teacher(null, null, null, null, "teacher", null).AddNewUser(_dataManager, _orgBYU);
                break;
            case "2":
                new Student(null, null, null, null, "student", null).AddNewUser(_dataManager, _orgBYU);
                break;
            case "3":
                return;
            default:
                Console.WriteLine("\nInvalid option. Please try again.");
                PressEnterToContinue();
                break;
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
            Console.WriteLine("1. View Specific User Data");
            Console.WriteLine("2. List All Users");
            Console.WriteLine("3. Return to Previous Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter User ID: ");
                    string userId = Console.ReadLine();
                    var user = _dataManager.GetAllUsers().Find(u => u.GetUserId() == userId);
                    if (user != null)
                        user.DisplayUserDetails();
                    else
                        Console.WriteLine("\nUser not found.");
                    PressEnterToContinue();
                    break;
                case "2":
                    User.ListAllUsers(_dataManager);
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
            Console.WriteLine("1. View Course Roster");
            Console.WriteLine("2. View Specific Course Schedules");
            Console.WriteLine("3. Return to Previous Menu");
            Console.Write("\nPlease select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Course.ListAllCourses(_dataManager);
                    break;
                case "2":
                    Console.Write("\nEnter Course ID: ");
                    string courseId = Console.ReadLine();
                    var course = _dataManager.GetAllCourses().Find(c => c.GetCourseId() == courseId);
                    if (course != null)
                        course.DisplaySchedules(_dataManager.GetAllSchedules());
                    else
                        Console.WriteLine("\nCourse not found.");
                    PressEnterToContinue();
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

    private static void PressEnterToContinue()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}