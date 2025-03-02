public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;
    private Random _random;

    public ListingActivity() 
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();
        _count = 0;
        LoadPrompts();
    }

    private void LoadPrompts()
    {
        _prompts = new List<string>
        {
            "Who are the people in your life that you really appreciate?",
            "What are some things you are good at in life?",
            "Which persons or groups you have helped this week?",
            "When did you feel the Holy Ghost this month?",
            "What are some things you can do to help maintain a healthy lifestyle?",
            "What are things that make you happy?",
            "What are some things you are grateful for?",
            "What are some things you are looking forward to?"
        };
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void RunListingActivity()
    {
        DisplayStartMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.WriteLine();

        GetUserResponses();
        DisplayCount();
        DisplayEndMessage();
    }

    private void GetUserResponses()
    {
        _count = 0;
        ResetStartTime();
        DateTime endTime = _startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(response))
            {
                _count++;
            }
        }
    }

    private void DisplayCount()
    {
        Console.WriteLine($"You listed {_count} items!");
    }
}