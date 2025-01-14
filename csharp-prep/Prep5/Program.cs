using System;
using System.Xml.XPath;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        double favoriteNumber = PromptUserNumber();
        double squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome ()
    {
        Console.WriteLine("Welcome to the program!");

    }

    static string PromptUserName ()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
        
    }

    static double PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return double.Parse(Console.ReadLine());

    }

    static double SquareNumber(double favoriteNumber)
    {
        double numberSquared = Math.Pow(favoriteNumber, 2);
        return numberSquared;
    }

    static void DisplayResult(string username, double squarednumber)
    {
        Console.WriteLine($"{username}, the square of your number is {squarednumber}. ");
    }


}