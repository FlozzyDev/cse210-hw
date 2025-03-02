using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("|===========================================|");
        Console.WriteLine("|               MIND OVER MATTER            |");
        Console.WriteLine("|           Breathe. Reflect. Relax.        |");
        Console.WriteLine("|===========================================|");
        Console.WriteLine("This program is designed to help you relax and reflect on your thoughts.");
        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
        RelaxRating initialRelax = new RelaxRating(1);
        initialRelax.PromptForRating();

        while (true)
        {
            Console.Clear();
            DisplayMenu();
            initialRelax.DisplayRating();

            string menuOption = Console.ReadLine();
            switch (menuOption)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.RunBreathingActivity();
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.RunReflectingActivity();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.RunListingActivity();
                    break;
                case "4":
                    RelaxRating finalRelax = new RelaxRating(1); 
                    finalRelax.PromptForRating();
                    finalRelax.CompareRating(initialRelax);
                    Console.WriteLine("\n If your done looking at your results, press Enter to exit the program.");
                    Console.ReadLine();
                    Console.WriteLine("\nThanks for using Mind Over Matter! Goodbye!");
                    return;
                
                default:
                    Console.WriteLine("\n Invalid option chosen. Please select a valid option presented in the menu.");
                    Console.WriteLine("\n Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Mind Over Matter Menu \n");
        Console.WriteLine("--Please select an activity to begin: ");
        Console.WriteLine("1. Start new Breathing Activity");
        Console.WriteLine("2. Start new Reflecting Activity");
        Console.WriteLine("3. Start new Listing Activity");
        Console.WriteLine("4. Quit and get final relaxation rating");
    }

}