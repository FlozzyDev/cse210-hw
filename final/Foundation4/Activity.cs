public abstract class Activity
{   
   // Distance (km) = swimming laps * 50 / 1000
   // Distance (miles) = swimming laps * 50 / 1000 * 0.62
   // Speed (mph or kph) = (distance / minutes) * 60
   // Pace (min per mile or min per km)= minutes / distance
   // Speed = 60 / pace
   // Pace = 60 / speed



    protected string _activityName;
    protected string _date;
    protected double _duration;

    public Activity(string activityName, string date, double duration)
    {
        _activityName = activityName;
        _date = date;
        _duration = duration;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
            return $"{_date} {_activityName} ({_duration} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
