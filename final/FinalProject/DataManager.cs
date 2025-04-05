public class DataManager
{
    private string _internalUsersFile = "internal_users.csv";
    private string _internalCoursesFile = "internal_courses.csv";
    private string _internalSchedulesFile = "internal_schedules.csv";
    private string _lastUsedIdFile = "DataFile/last_id.csv";
    private int _lastUserId = 0;
    private int _lastScheduleId = 0;

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
            File.WriteAllText(_lastUsedIdFile, "last_used_id,last_schedule_id\n0,0");
        }
    }

    private void LoadLastUsedIds()
    {
        try
        {
            if (File.Exists(_lastUsedIdFile))
            {
                var lines = File.ReadAllLines(_lastUsedIdFile);
                if (lines.Length > 1)
                {
                    var values = lines[1].Split(',');
                    _lastUserId = int.Parse(values[0]);
                    _lastScheduleId = int.Parse(values[1]);
                }
            }

            // Find highest schedule ID from existing schedules to ensure we don't have gaps
            if (File.Exists(_internalSchedulesFile))
            {
                var schedules = GetAllSchedules();
                if (schedules.Count > 0)
                {
                    var highestId = schedules
                        .Select(s => s.GetScheduleId())
                        .Where(id => id.StartsWith("SCH"))
                        .Select(id => int.Parse(id.Substring(3)))
                        .Max();
                    _lastScheduleId = Math.Max(_lastScheduleId, highestId);
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
            File.WriteAllText(_lastUsedIdFile, $"last_used_id,last_schedule_id\n{_lastUserId},{_lastScheduleId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating last used ID: {ex.Message}");
        }
    }

    public string GenerateUserId()
    {
        _lastUserId++;
        UpdateLastUsedId();
        return $"U{_lastUserId:D4}"; // add leading zeroes to make it 4 digits
    }

    public string GenerateScheduleId()
    {
        _lastScheduleId++;
        UpdateLastUsedId();
        return $"SCH{_lastScheduleId:D3}"; // add leading zeroes to make it 3 digits
    }

    private List<string[]> ReadCSV(string filepath)
    {
        List<string[]> data = new List<string[]>();
        try
        {
            using (var reader = new StreamReader(filepath))
            {
                // Skip header
                reader.ReadLine();
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = new List<string>();
                    var inQuotes = false;
                    var currentValue = "";
                    
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '"')
                        {
                            inQuotes = !inQuotes;
                        }
                        else if (line[i] == ',' && !inQuotes)
                        {
                            values.Add(currentValue);
                            currentValue = "";
                        }
                        else
                        {
                            currentValue += line[i];
                        }
                    }
                    values.Add(currentValue); // Add the last value
                    
                    data.Add(values.ToArray());
                }
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

    private string FormatTime(string time)
    {
        try
        {
            // Split the time into hours and minutes
            var parts = time.Split(':');
            if (parts.Length != 2) return time;

            // Parse hours and minutes
            if (!int.TryParse(parts[0], out int hours) || !int.TryParse(parts[1], out int minutes))
                return time;

            // Ensure hours are between 0-23 and minutes are between 0-59
            hours = Math.Clamp(hours, 0, 23);
            minutes = Math.Clamp(minutes, 0, 59);

            // Format as HH:MM
            return $"{hours:D2}:{minutes:D2}";
        }
        catch
        {
            return time;
        }
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
                string scheduleId = GenerateScheduleId(); // Generate a new schedule ID
                string courseId = row[0];
                string roomNumber = row[1];
                List<string> daysOfWeek = row[2].Trim('"').Split(',').ToList();
                string startTime = FormatTime(row[3]);
                string endTime = FormatTime(row[4]);

                ClassSchedule schedule = new ClassSchedule(scheduleId, courseId, roomNumber, daysOfWeek, new List<string> { startTime }, new List<string> { endTime });
                schedules.Add(schedule);

                writer.WriteLine($"{scheduleId},{courseId},{roomNumber},\"{string.Join(",", daysOfWeek)}\",{startTime},{endTime}");
            }
        }
        return schedules;
    }

    // Import courses from import CSV and create internal CSV
    public List<Course> ImportCourses(string filepath)
    {
        List<Course> courses = new List<Course>();
        List<string[]> data = ReadCSV(filepath);
        List<User> existingUsers = GetAllUsers(); // Get all users to look up teacher IDs

        using (StreamWriter writer = new StreamWriter(_internalCoursesFile, true))
        {
            foreach (string[] row in data)
            {
                string courseId = row[0];
                string courseName = row[1];
                string teacherName = row[2];  // This is actually the teacher's full name
                
                // Find the teacher's ID by their full name
                var teacher = existingUsers.FirstOrDefault(u => 
                    $"{u.GetFirstName()} {u.GetLastName()}" == teacherName && 
                    u is Teacher);
                
                string teacherId = teacher?.GetUserId() ?? "Unknown";  // Use the actual teacher ID
                
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

    public void AddUser(User user)
    {
        using (StreamWriter writer = new StreamWriter(_internalUsersFile, true))
        {
            if (user is Teacher teacher)
            {
                writer.WriteLine($"{user.GetUserId()},{user.GetFirstName()},{user.GetLastName()},{user.GetEmail()},teacher,{teacher.GetDepartment()},");
            }
            else if (user is Student student)
            {
                writer.WriteLine($"{user.GetUserId()},{user.GetFirstName()},{user.GetLastName()},{user.GetEmail()},student,NULL,{student.GetMajor()}");
            }
        }
    }

    public void AddCourse(Course course)
    {
        using (StreamWriter writer = new StreamWriter(_internalCoursesFile, true))
        {
            writer.WriteLine($"{course.GetCourseId()},{course.GetCourseName()},{course.GetTeacherId()}");
        }
    }

    public void AddSchedule(ClassSchedule schedule)
    {
        using (StreamWriter writer = new StreamWriter(_internalSchedulesFile, true))
        {
            string startTime = FormatTime(schedule.GetStartTime()[0]);
            string endTime = FormatTime(schedule.GetEndTime()[0]);
            writer.WriteLine($"{schedule.GetScheduleId()},{schedule.GetCourseId()},{schedule.GetRoomNumber()},\"{string.Join(",", schedule.GetDaysOfWeek())}\",{startTime},{endTime}");
        }
    }
} 