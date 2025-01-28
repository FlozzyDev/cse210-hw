using System;

public class Program
{   

    /* todo - need to add 3 attempts and only fail after 3 failures - maybe add a hint at 2*/ 
    private string _password = "Zion"; /* Don't tell anyone! */ 

    public static void Main(string[] args)
    {
        Program program = new Program();
        if (program.ValidatePassword())
        {
            program.DisplayMainMenu();
        }
        else
        {
            Console.WriteLine("Invalid password. Program terminating.");
        }
    }

    public bool ValidatePassword()
    {
        Console.Write("Enter password: ");
        string input = Console.ReadLine();
        return input == _password;
    }

    public void DisplayMainMenu()
    {
        Journal journal = new Journal();
        bool programOn = true;

        while (programOn)
        {
            Console.WriteLine("\n1. Write new entry");
            Console.WriteLine($"2. Display entries ({journal.GetEntryCount()})");
            Console.WriteLine($"3. Save journal ({journal.GetEntryCount()})");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine(); /* user can choose 1 of 5 options */ 
            switch (choice)
            {
                case "1":
                    Entry newEntry = new Entry();
                    Prompt prompt = new Prompt();
                    string randomPrompt = prompt.GeneratePrompt();
                    
                    Console.WriteLine($"\nPrompt: {randomPrompt}");
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();
                    
                    int moodRating;
                    bool validRating = false;
                    do {
                        Console.Write("Enter a rating for your mood(1-10): ");
                        validRating = int.TryParse(Console.ReadLine(), out moodRating) && moodRating >= 1 && moodRating <= 10; /* user can only enter a number between 1 and 10, if not they get looped */
                        if (!validRating) Console.WriteLine("Please enter a number between 1 and 10");
                    } while (!validRating);

                    newEntry.WriteEntry(randomPrompt, entryText, moodRating);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!");
                    break;
                    
                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    journal.SaveJournal("journal.txt");
                    break;

                case "4":
                    journal.LoadJournal("journal.txt"); 
                    break;

                case "5":
                    programOn = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}