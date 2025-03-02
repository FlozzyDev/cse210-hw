public class ReflectingActivity : Activity{
    
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectingActivity()
        :base ("Reflecting","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _random = new Random();
            LoadPrompts();
            LoadQuestions();
        }
    
    private void LoadPrompts()
    {
        _prompts = new List<string>
        {
            "Think of a time you made a mistake.",
            "Think of a time you were scared.",
            "Think of a time you were proud of yourself.",
            "Think of a time you helped someone.",
            "Think of a time you were hurt.",
            "Think of a time you were angry.",
            "Think of a time you were sad.",
            "Think of a time you were happy.",
            "Think of a time you were frustrated.",
            "Think of a time you were excited.",
            "Think of a time you were selfless."
        };
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private void LoadQuestions()
    {
        _questions = new List<string>
        {
            "What did you learn from that experience?",
            "What would you do differently if you could go back?",
            "How did that experience shape you as a person?",
            "What did you learn about yourself from that experience?",
            "How did that experience change your perspective on life?",
            "What did you learn about others from that experience?",
            "How did that experience help you grow?",
            "How did that experience help you become a better person?",
            "What did you learn about your values from that experience?"
        };
    }

    private string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine($"---{GetRandomPrompt()}---");
        Console.WriteLine();
    }

    public void RunReflectingActivity()
    {
        DisplayStartMessage();
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        CountDown(3);
        Console.Clear();
        ResetStartTime();

        DateTime endTime = _startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($">---{question}");
            ShowSpinner();
            ShowSpinner();
            ShowSpinner();
            Console.WriteLine();
        }
        DisplayEndMessage();
    }




}