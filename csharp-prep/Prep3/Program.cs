using System;

class Program
{
    static void Main(string[] args)
    {   
        string response = null;
        string playAgain = "yes";
        
        do
        {   
            int guessCount = 0;
            int currentGuess = 1;
            Random magicGenerator = new Random();
            int magicNumber = magicGenerator.Next(1,100);
            Console.WriteLine("Your job is to guess the number!");

            do
            {   
                Console.Write("What is your guess? ");
                currentGuess = int.Parse(Console.ReadLine());

                if (currentGuess > magicNumber)
                {   
                    guessCount += 1;
                    Console.WriteLine("Lower.");
                }

                else if (currentGuess < magicNumber)
                {   
                    guessCount += 1;
                    Console.WriteLine("Higher. ");
                }

                else 
                {
                    guessCount += 1;
                    Console.WriteLine("You are correct!");
                    Console.WriteLine($"It took you {guessCount} attempts!");
                    Console.WriteLine("Do you want to play again? Please type yes or no: ");
                    response = Console.ReadLine();
                    playAgain = response.ToLower();
                }
                    
            } 
            while (currentGuess != magicNumber);
        }
        while (playAgain == "yes");
        
        if (playAgain != "yes")
        {
            Console.WriteLine ("Goodbye ");
            return;
        }
    }
}