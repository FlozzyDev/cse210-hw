public class ReceptionEvent : Event
{
    private string _email;

    public ReceptionEvent(string eventTitle, string description, string date, string time, Address address, string type, string email) 
        : base(eventTitle, description, date, time, address, type)  
    {
        _email = email;
    }

    public void GetReceptionDetails()
    {
        FullDetails();
        Console.WriteLine("Please send RSVP to: " + _email);
    }
}