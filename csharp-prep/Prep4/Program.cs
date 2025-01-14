using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a series of numbers.. Type 0 when you are finished entering. ");
        bool continueAsking = true;
        List<int> numbersList = new List<int>();

        do 
        {
            Console.Write("Enter a number: ");
            int newNumber = int.Parse(Console.ReadLine());
            
            if (newNumber < 0)
            {
                numbersList.Add(newNumber);
                continueAsking = true;
            }

            else if (newNumber > 0)
            {
                numbersList.Add(newNumber);
                continueAsking = true;
            }

            else 
            {
                continueAsking = false;
            }

        } while (continueAsking == true);

        int sumList = numbersList.Sum();
        int listCount = numbersList.Count();

        float averageList = 0;
            if (numbersList.Count > 0)
            {
            averageList = (float)sumList / listCount;
            }

        int largestNumber = numbersList.Max();
        numbersList.Sort();

        Console.WriteLine($"The sum is: {sumList}");
        Console.WriteLine($"The average is: {averageList}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The sorted list is: ");
        foreach (int number in numbersList)
        {
            Console.WriteLine(number);
        }
        
    }
}