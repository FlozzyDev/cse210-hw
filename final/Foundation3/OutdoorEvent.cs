public class OutdoorEvent : Event
{
    private string _weather;

    public OutdoorEvent(string eventTitle, string description, string date, string time, Address address, string type, string weather) 
        : base(eventTitle, description, date, time, address, type)
    {
        _weather = weather;
    }

    public void GetOutdoorDetails()
    {
        FullDetails();
        Console.WriteLine($"The Weather will be: {_weather}");
    }
}