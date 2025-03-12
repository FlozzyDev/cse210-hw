using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("510 S Center St. (Room 346)", "Rexburg", "ID", "83460");
        Address address2 = new Address("859 S Yellowstone Hwy #1002", "Rexburg", "ID", "83440");
        Address address3 = new Address("S 2nd W & 3rd W,", "Rexburg", "ID", "83440");
        LectureEvent lecture1 = new LectureEvent("Lecture on C#", "Learn about C# programming", "3/15/2025", "10:00 AM", address1, "Lecture", "John Doe", 100);
        ReceptionEvent wedding1 = new ReceptionEvent("Wedding: Tom and Jill", "Come (if you RSVP'ed) and celebrate the marriage of Tom and Jill!", "3/15/2025", "3:00 PM", address2, "Reception", "eventrsvp@hotmail.com");
        OutdoorEvent concert1 = new OutdoorEvent("Outdoor Concert: Porter Park Polka", "Live music in the park, come dance!", "3/15/2025", "7:00 PM", address3, "Concert", "Cloudy");

        Console.WriteLine("----------Upcoming Events for 3/15/2025!----------");
        Console.WriteLine();

        Console.WriteLine("1st Event Standard Details -----------------");
        lecture1.GetStandardDetails();
        Console.WriteLine();
        Console.WriteLine("1st Event Full Details -----------------");
        lecture1.GetLectureDetails();
        Console.WriteLine();
        Console.WriteLine("1st Event Short Description -----------------");
        lecture1.GetShortDescription();
        Console.WriteLine();

        Console.WriteLine("2nd Event Standard Details -----------------");
        wedding1.GetStandardDetails();
        Console.WriteLine();
        Console.WriteLine("2nd Event Full Details -----------------");
        wedding1.GetReceptionDetails();
        Console.WriteLine();
        Console.WriteLine("2nd Event Short Description -----------------");
        wedding1.GetShortDescription();
        Console.WriteLine();

        Console.WriteLine("3rd Event Standard Details -----------------");
        concert1.GetStandardDetails();
        Console.WriteLine();
        Console.WriteLine("3rd Event Full Details -----------------");
        concert1.GetOutdoorDetails();
        Console.WriteLine();
        Console.WriteLine("3rd Event Short Description -----------------");
        concert1.GetShortDescription();
        Console.WriteLine();

    }
}