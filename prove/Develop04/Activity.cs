public class Activity {
    protected string _name;
    protected string _description;
    protected int _duration;
    protected DateTime _startTime;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _startTime = DateTime.Now;
    }

    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session?");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner();
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner();
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} second of a {_name} activity. Returning to the main menu...");
        ShowSpinner();
        Console.Clear();
    }

    protected void ShowSpinner()
    {
        var spinnerChars = new List<string> { "|", "/", "-", "\\" }; // varKeyword.md
        foreach (var s in spinnerChars)
        {   
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void CountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void ResetStartTime()
    {
        _startTime = DateTime.Now;
    }
}