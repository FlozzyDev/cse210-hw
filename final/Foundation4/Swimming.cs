public class Swimming : Activity
{   

    // Distance (km) = swimming laps * 50 / 1000
    // Distance (miles) = swimming laps * 50 / 1000 * 0.62
    private double _laps;

    public Swimming(string activityName, string date, double duration, double laps)
    : base(activityName, date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() // Distance (miles) = swimming laps * 50 / 1000 * 0.62
    {
        return Math.Round(_laps * 50 / 1000 * 0.62, 2);
    }

    public override double GetSpeed() // Speed (mph) = (distance / minutes) * 60
    {
        return Math.Round((GetDistance() / _duration) * 60, 2);
    }

    public override double GetPace() // Pace (min per mile) = minutes / distance
    {
        return Math.Round(_duration / GetDistance(), 2);
    }

    
    
}


