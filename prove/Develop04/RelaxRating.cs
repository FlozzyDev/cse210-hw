public class RelaxRating
{
    private int _relaxRating;

    public RelaxRating(int relaxRating)
    {
        _relaxRating = relaxRating;
    }

    public int GetRelaxRating()
    {
        return _relaxRating;
    }

    public void SetRelaxRating(int relaxRating)
    {
        _relaxRating = relaxRating;
    }

    public void DisplayRating()
    {
        Console.WriteLine($"\nYour initial reported relaxation level is: {_relaxRating}/10");
    }

    public void PromptForRating()
    {
        Console.WriteLine("On a scale of 1-10, how relaxed do you feel right now?");
        Console.Write("Your rating (1-10): ");
        string userInput = Console.ReadLine();
        int rating = int.Parse(userInput);
        _relaxRating = rating;
    }
    
    public void CompareRating(RelaxRating initialRating)
    {
        Console.Clear();
        Console.WriteLine("Relaxation Comparison Results \n");
        Console.WriteLine($"Your initial relaxation level was: {initialRating.GetRelaxRating()}/10");
        Console.WriteLine($"Your final relaxation level is: {_relaxRating}/10 \n");

        Console.WriteLine("=============================================");
        Console.WriteLine("          Relaxation Rating Results!         ");
        Console.WriteLine("=============================================");
        
        int change = _relaxRating - initialRating.GetRelaxRating();
        if (change > 0)
        {
            Console.WriteLine($"Your relaxation level increased by {change} points. Great job!");
        }
        else if (change < 0)
        {
            int negativeChange = -change;
            Console.WriteLine($"Your relaxation level decreased by {negativeChange} points.");
        }
        else if (change == 0)
        {
            Console.WriteLine("Your relaxation level stayed the same.");
        }
    }
}