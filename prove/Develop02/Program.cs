using System;

public class Program
{   

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
            Console.WriteLine("3 Invalid passwords. Program terminating.");
        }
    }

    public bool ValidatePassword()
    {
        for (int attempts = 0; attempts < 3; attempts++)
        {
            Console.Write("Enter password:");
            string passwordAttempt = Console.ReadLine();

            if (passwordAttempt == _password)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid password. Please try again.");
            }
        }
        return false;
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
            string choice = Console.ReadLine(); /* ------------todo---- add a new choice, delete. First need PK and we can target that row. We can only delete if load has happened at least once. */ 
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
                    journal.DisplayJournal();
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