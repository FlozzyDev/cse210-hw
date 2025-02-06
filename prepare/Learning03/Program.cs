using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(5);
        Fraction frac3 = new Fraction(5, 6);

        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac3.GetFractionString());

        frac1.SetTopNumber(10);
        frac1.SetBottomNumber(20);

        frac2.SetTopNumber(5);
        frac2.SetBottomNumber(8);

        frac3.SetTopNumber(7);
        frac3.SetBottomNumber(9);

        Console.WriteLine(frac1.GetFractionString() + " This is the new one we will get value for");
        Console.WriteLine(frac2.GetFractionString() + " This is the new one we will get value for");
        Console.WriteLine(frac3.GetFractionString() + " This is the new one we will get value for");

        Console.WriteLine(frac1.GetDecimalValue());
        Console.WriteLine(frac2.GetDecimalValue());
        Console.WriteLine(frac3.GetDecimalValue());

    }
}