using System;   
public class Event
{
    private string _eventTitle;
    private string _description;
    private string _date;
    private string _time;
    private string _address;
    private string _type;

    public Event(string eventTitle, string description, string date, string time, Address address, string type)
    {
        _eventTitle = eventTitle;
        _description = description;
        _date = date;
        _time = time;
        _address = address.GetAddress();
        _type = type;
    }

    public void GetStandardDetails()
    {
        Console.WriteLine("Event Title: " + _eventTitle);
        Console.WriteLine("Description: " + _description);
        Console.WriteLine("Date: " + _date);
        Console.WriteLine("Time: " + _time);
        Console.WriteLine("Address: " + _address);
    }

    public void FullDetails()
    {
        GetStandardDetails();
        Console.WriteLine("Event Type: " + _type);
    }


    public void GetShortDescription()
    {   
        Console.WriteLine("Event Type: " + _type);
        Console.WriteLine("Event Title: " + _eventTitle);
        Console.WriteLine("Date: " + _date);
    }

}