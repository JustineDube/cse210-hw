using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    protected Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public int LengthMinutes => _lengthMinutes;

    // Abstract methods for polymorphism
    public abstract double GetDistance();  // in miles
    public abstract double GetSpeed();     // in mph
    public abstract double GetPace();      // in min per mile

    // Virtual method for summary
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_lengthMinutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}
