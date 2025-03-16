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
} 