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
} 