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

    public void EnrollCourse(string courseId)
    {
        _enrolledCourses.Add(courseId);
    }

    public List<string> GetEnrolledCourses()
    {
        return _enrolledCourses;
    }

    public string GetMajor()
    {
        return _major;
    }
} 