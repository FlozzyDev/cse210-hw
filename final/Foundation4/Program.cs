using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running1 = new Running("Run - Dallin Hale", "2025-03-29 10:00AM", 20, 2);
        activities.Add(running1);

        Swimming swimming1 = new Swimming("Swim - Dallin Hale", "2025-03-29 11:00AM", 25, 16);
        activities.Add(swimming1);

        StationaryBike stationaryBike1 = new StationaryBike("Stationary Bike - Dallin Hale", "2025-03-29 1:00PM", 30, 8);
        activities.Add(stationaryBike1);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}