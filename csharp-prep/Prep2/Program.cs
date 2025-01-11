using System;

class Program
{
    static void Main(string[] args)
    {
        // Get the grade from the user in a string
        Console.Write("What is your grade? ");
        string stringGrade = Console.ReadLine();

        // initialize secondNumber and gradeSign
        int secondNumber = 0;
        string gradeSign = null;

        // Find the 2nd digit in the grade and verify if we need to add + or -
        if (stringGrade.Length == 2)
        {
            char secondChar = stringGrade[1];
            secondNumber = int.Parse(secondChar.ToString());


            if (secondNumber >= 7)
            {
                gradeSign = "+";
            }

            else if (secondNumber <= 3)
            {
                gradeSign ="-";
            }

            else 
            {
                gradeSign = null;
            }
        }

        //Convert string to a letter grade. Create more variables we will be using
        int numberGrade = int.Parse(stringGrade);
        string letterGrade;
        string passFail;

        // Compare the int grade to find the LetterGrade
        if (numberGrade > 90)
            {
                letterGrade = "A";
            }

        else if (numberGrade > 80)
            {
                letterGrade = "B";
            }

        else if (numberGrade > 70)
            {
                letterGrade = "C";
            }

        else if (numberGrade > 60)
            {
                letterGrade = "D";
            }

        else
            {
                letterGrade = "F";
            }


        // Verify the user is over or under 70, then print pass/fail and the grade. 
        if (numberGrade >= 70)
            {
                passFail = "passed";
            }
        else
            {
                passFail = "failed";
            }


        // Check if they have an A, if so we remove gradeSign
        if (letterGrade == "A" && gradeSign == "+")
        {
            gradeSign = null;
        }

        if (letterGrade == "F" && gradeSign != null)
        {
            gradeSign = null;
        }

        //Print the final outcome
        Console.WriteLine($"You {passFail} the class. The letter grade your receieved: {letterGrade}{gradeSign} ");
    }
}