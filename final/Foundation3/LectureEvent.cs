public class LectureEvent : Event 
{
    private string _speaker;
    private int _capacity;

    public LectureEvent(string eventTitle, string description, string date, string time, Address address, string type, string speaker, int capacity) 
        : base(eventTitle, description, date, time, address, type)  
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public void GetLectureDetails()
    {
        FullDetails();
        Console.WriteLine("Speaker: " + _speaker);
        Console.WriteLine("Capacity: " + _capacity);
    }



}