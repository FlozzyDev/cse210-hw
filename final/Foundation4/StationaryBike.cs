public class StationaryBike : Activity
{ 
    private double _speed;

    public StationaryBike(string activityName, string date, double duration, double speed)
    : base(activityName, date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return Math.Round((_speed * _duration) / 60, 2);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return Math.Round(60 / _speed, 2);
    }

}

