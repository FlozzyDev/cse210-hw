using System;

class Program
{
    static void Main(string[] args)
    {
        Data data = new Data();
        data.LoadData("scriptures.csv");
        bool menuScreen = true;
        while (menuScreen == true)
        {
            Console.WriteLine("Pick the data type you want to load, or quit the program.");
            Console.WriteLine("1. Scriptures");
            Console.WriteLine("2. Quit");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Data randomScripture = data.getRandomData();
                Scripture scripture = new Scripture(randomScripture);

                Console.Clear();
                Console.WriteLine(scripture.GetTextDisplay());

                while (true)
                {
                    (int visibleCount, int wordsToHide) = scripture.GetWordCount();
                    Console.WriteLine("Total visible words left: " + visibleCount);
                    Console.WriteLine("Press enter to hide " + wordsToHide + " words or type 'end' to stop memorization session.");
                    string scriptureinput = Console.ReadLine();

                    if (scriptureinput == "end")
                    {
                        break;
                    }

                    scripture.HideRandomWords(wordsToHide);
                    Console.Clear();

                    Console.WriteLine(scripture.GetTextDisplay());

                    if (scripture.AllTextHidden())
                    {
                        Console.WriteLine("All words hidden!");
                        break;
                    }

                }
            }
            else if (input == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}