public class BreathingActivity : Activity 
{
    public BreathingActivity()
        :base ("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {}

    public void RunBreathingActivity()
    {
        DisplayStartMessage();
        ResetStartTime();
        DateTime endTime = _startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            DisplayBreathingMessage("Breathe in...");
            DisplayBreathingMessage("Breathe out...");
            Console.WriteLine();
        }

        DisplayEndMessage();
    }

    private void DisplayBreathingMessage(string message)
    {
        Console.Write($"{message} ");
        for (int i = 4; i>= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}