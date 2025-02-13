using System;

class Program
{
    static void Main(string[] args)
    {   
        Data data = new Data();
        data.LoadData("scriptures.csv");

        Data randomScripture = data.getRandomData();
        Scripture scripture = new Scripture(null, null); // Pretty sure I am missing something very obvious to get this to work without having to make an instance here first.
        scripture = scripture.CreateWithData(randomScripture);

        Console.Clear();
        Console.WriteLine(scripture.GetTextDisplay());

        while (true)
        {
            Console.WriteLine("Press Enter to hide, or type quit to exit");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            int hideCount = scripture.GetHideCount();
            scripture.HideRandomWords(hideCount);
            Console.Clear();

            Console.WriteLine(scripture.GetTextDisplay());

            if (scripture.AllTextHidden())
            {
                Console.WriteLine("All words hidden!");
                break;
            }
        }

    }
}