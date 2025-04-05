public class Running : Activity
{
    private double _distance;

    public Running(string activityName, string date, double duration, double distance)
    : base(activityName, date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return Math.Round((_distance / _duration) * 60, 2);    
    }

    public override double GetPace()
    {
        return Math.Round(_duration / _distance, 2);
    }

}

