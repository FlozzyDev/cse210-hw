public class DataManager
{
    private string _internalUsersFile = "internal_users.csv";
    private string _internalCoursesFile = "internal_courses.csv";
    private string _internalSchedulesFile = "internal_schedules.csv";
    private string _lastUsedIdFile = "DataFile/last_used_id.csv";
    private int _lastUserId = 0;

    public DataManager()
    {
        InitializeInternalFiles();
        LoadLastUsedIds();
    }

    private void InitializeInternalFiles()
    {
        if (!File.Exists(_internalUsersFile))
        {
            File.WriteAllText(_internalUsersFile, "userId,firstName,lastName,email,role,department,major\n");
        }
        if (!File.Exists(_internalCoursesFile))
        {
            File.WriteAllText(_internalCoursesFile, "courseId,courseName,teacherId,studentIds\n");
        }
        if (!File.Exists(_internalSchedulesFile))
        {
            File.WriteAllText(_internalSchedulesFile, "scheduleId,courseId,roomNumber,daysOfWeek,startTime,endTime\n");
        }
        if (!File.Exists(_lastUsedIdFile))
        {
            File.WriteAllText(_lastUsedIdFile, "last_used_id\n0");
        }
    }

    private void LoadLastUsedIds()
    {
        try
        {
            // just a file to store the PK for users
            if (File.Exists(_lastUsedIdFile))
            {
                var lines = File.ReadAllLines(_lastUsedIdFile);
                if (lines.Length > 1)
                {
                    _lastUserId = int.Parse(lines[1]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading last used IDs: {ex.Message}");
        }
    }

    private void UpdateLastUsedId()
    {
        try
        {
            // update the PK file with the last used ID
            File.WriteAllText(_lastUsedIdFile, $"last_used_id\n{_lastUserId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating last used ID: {ex.Message}");
        }
    }

    private string GenerateUserId()
    {
        _lastUserId++;
        UpdateLastUsedId();
        return $"U{_lastUserId:D4}"; // add leading zeroes to make it 4 digits
    }

    private List<string[]> ReadCSV(string filepath)
    {
        List<string[]> data = new List<string[]>();
        try
        {
            string[] lines = File.ReadAllLines(filepath);
            for (int i = 1; i < lines.Length; i++)
            {
                data.Add(lines[i].Split(','));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        return data;
    }

    public List<User> ImportUsers(string filepath)
    {
        List<User> users = new List<User>();
        List<string[]> data = ReadCSV(filepath);

        using (StreamWriter writer = new StreamWriter(_internalUsersFile, true))
        {
            foreach (string[] row in data)
            {
                string userId = GenerateUserId();
                string firstName = row[0];
                string lastName = row[1];
                string email = row[2];
                string role = row[3];

                if (role.ToLower() == "teacher")
                {
                    string department = row[4];
                    Teacher teacher = new Teacher(userId, firstName, lastName, email, role, department);
                    users.Add(teacher);
                    writer.WriteLine($"{userId},{firstName},{lastName},{email},teacher,{department},");
                }
                else if (role.ToLower() == "student")
                {
                    string major = row[5];
                    Student student = new Student(userId, firstName, lastName, email, role, major);
                    users.Add(student);
                    writer.WriteLine($"{userId},{firstName},{lastName},{email},student,NULL,{major}"); // NULL for department
                }
            }
        }
        return users;
    }

    // Import ClassSchedules from import CSV and create internal CSV
    public List<ClassSchedule> ImportSchedules(string filepath)
    {
        List<ClassSchedule> schedules = new List<ClassSchedule>();
        List<string[]> data = ReadCSV(filepath);

        using (StreamWriter writer = new StreamWriter(_internalSchedulesFile, true))
        {
            foreach (string[] row in data)
            {
                string scheduleId = row[0];
                string courseId = row[1];
                string roomNumber = row[2];
                List<string> daysOfWeek = new List<string>(row[3].Trim('"').Split(','));
                List<string> startTime = new List<string> { row[4] };
                List<string> endTime = new List<string> { row[5] };

                ClassSchedule schedule = new ClassSchedule(scheduleId, courseId, roomNumber, daysOfWeek, startTime, endTime);
                schedules.Add(schedule);

                string daysOfWeekStr = $"\"{string.Join(",", daysOfWeek)}\"";
                writer.WriteLine($"{scheduleId},{courseId},{roomNumber},{daysOfWeekStr},{startTime[0]},{endTime[0]}");
            }
        }
        return schedules;
    }

    // Import courses from import CSV and create internal CSV
    public List<Course> ImportCourses(string filepath)
    {
        List<Course> courses = new List<Course>();
        List<string[]> data = ReadCSV(filepath);

        using (StreamWriter writer = new StreamWriter(_internalCoursesFile, true))
        {
            foreach (string[] row in data)
            {
                string courseId = row[0];
                string courseName = row[1];
                string teacherId = row[2];
                Course course = new Course(courseId, courseName, teacherId);
                courses.Add(course);

                writer.WriteLine($"{courseId},{courseName},{teacherId}");
            }
        }
        return courses;
    }

    // Get all users from internal CSV
    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();
        List<string[]> data = ReadCSV(_internalUsersFile);

        foreach (string[] row in data)
        {
            string userId = row[0];
            string firstName = row[1];
            string lastName = row[2];
            string email = row[3];
            string role = row[4];

            if (role.ToLower() == "teacher")
            {
                string department = row[5];
                users.Add(new Teacher(userId, firstName, lastName, email, role, department));
            }
            else if (role.ToLower() == "student")
            {
                string major = row[6];
                users.Add(new Student(userId, firstName, lastName, email, role, major));
            }
        }
        return users;
    }

    // Get all courses from internal CSV
    public List<Course> GetAllCourses()
    {
        List<Course> courses = new List<Course>();
        List<string[]> data = ReadCSV(_internalCoursesFile);

        foreach (string[] row in data)
        {
            string courseId = row[0];
            string courseName = row[1];
            string teacherId = row[2];
            courses.Add(new Course(courseId, courseName, teacherId));
        }
        return courses;
    }

    // Get all schedules from internal CSV
    public List<ClassSchedule> GetAllSchedules()
    {
        List<ClassSchedule> schedules = new List<ClassSchedule>();
        List<string[]> data = ReadCSV(_internalSchedulesFile);

        foreach (string[] row in data)
        {
            string scheduleId = row[0];
            string courseId = row[1];
            string roomNumber = row[2];
            List<string> daysOfWeek = new List<string>(row[3].Trim('"').Split(','));
            List<string> startTime = new List<string> { row[4] };
            List<string> endTime = new List<string> { row[5] };

            schedules.Add(new ClassSchedule(scheduleId, courseId, roomNumber, 
                                         daysOfWeek, startTime, endTime));
        }
        return schedules;
    }
} 