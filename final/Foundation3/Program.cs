using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "12345");
        Address address2 = new Address("456 Elm St", "Redding", "CA", "67890");
        Address address3 = new Address("7877 Oak St", "Boulder", "CO", "13579");
        LectureEvent lecture1 = new LectureEvent("Lecture on C#", "Learn about C# programming", "3/15/2025", "10:00 AM", address1, "Lecture", "John Doe", 100);
        ReceptionEvent wedding1 = new ReceptionEvent("Wedding: Tom and Jill", "Come celebrate the marriage of Tom and Jill!", "3/15/2025", "6:00 PM", address2, "Reception", "eventrsvp@hotmail.com");
        OutdoorEvent concert1 = new OutdoorEvent("Outdoor Concert", "Live music in the park", "3/15/2025", "7:00 PM", address3, "Concert", "Sunny");

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