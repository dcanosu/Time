namespace Backend;

public class Time
{
    private int _hour;
    private int _minute;
    private int _millisecond;
    private int _second;

    private const int MillisecondsPerSecond = 1000;
    private const int SecondsPerMinute = 60;
    private const int MinutesPerHour = 60;
    private const int HoursPerDay = 24;

    private const int SecondsPerHour = SecondsPerMinute * MinutesPerHour; // 3600 seconds in an hour
    private const int MillisecondsPerMinute = SecondsPerMinute * MillisecondsPerSecond; // 60000 milliseconds in a minute
    private const int MillisecondsPerHour = SecondsPerHour * MillisecondsPerSecond; // 3600000 milliseconds in an hour
    private const int MillisecondsPerDay = HoursPerDay * MillisecondsPerHour; // 86400000 milliseconds in a day

    public Time()
    {
        _hour = 0;
        _millisecond = 0;
        _minute = 0;
        _second = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    public int Hour 
    { 
        get => _hour; 
        set => _hour = ValidHour(value); 
    }

    public int Minute 
    { 
        get => _minute; 
        set => _minute = ValidMinute(value); 
    }

    public int Second 
    { 
        get => _second; 
        set => _second = ValidSecond(value); 
    }

    public int Millisecond 
    { 
        get => _millisecond; 
        set => _millisecond = ValidMillisecond(value); 
    }
    public int ToMinutes()
    {
        return (Hour * MinutesPerHour) + Minute;
    }

    public int ToSeconds()
    {
        return (Hour * SecondsPerHour) + (Minute * SecondsPerMinute) + Second;
    }
    public int ToMilliseconds()
    {
        return (Hour * MillisecondsPerHour) + (Minute * MillisecondsPerMinute) + (Second * MillisecondsPerSecond) + Millisecond;
    }
    public bool IsOtherDay(Time time)
    {
        int totalMilliseconds = ToMilliseconds() + time.ToMilliseconds();
        return totalMilliseconds >= MillisecondsPerDay;
    }

    public Time Add(Time time)
    {
        int millisecond = Millisecond + time.Millisecond;
        int extraSecond = millisecond / MillisecondsPerSecond;
        millisecond %= MillisecondsPerSecond;

        int second = Second + time.Second + extraSecond;
        int extraMinute = second / SecondsPerMinute;
        second %= SecondsPerMinute;

        int minute = Minute + time.Minute + extraMinute;
        int extraHour = minute / MinutesPerHour;
        minute %= MinutesPerHour;

        int hour = Hour + time.Hour + extraHour;
        hour %= HoursPerDay;

        return new Time(hour, minute, second, millisecond);
    }

    public override string ToString()
    {
        int hour12 = Hour % 12;
        string period = Hour < 12 ? "AM" : "PM";

        return $"{hour12:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }

    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
            throw new ArgumentOutOfRangeException(paramName: null, $"The hour: {hour} is not valid.");
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
            throw new System.ArgumentOutOfRangeException(paramName: null, $"The minute: {minute} is not valid.");
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
            throw new System.ArgumentOutOfRangeException(paramName: null, $"The second: {second} is not valid.");
        return second;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
            throw new System.ArgumentOutOfRangeException(paramName: null, $"The millisecond: {millisecond} is not valid.");
        return millisecond;
    }
}