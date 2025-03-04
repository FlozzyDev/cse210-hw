using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let's get some shapes!");

        var circle = new Circle("red", 5);
        var square = new Square("blue", 4);
        var rectangle = new Rectangle("green", 3, 6);

        List<Shape> shapes = new List<Shape> { circle, square, rectangle };

        foreach ( var shape in shapes)
        {
            Console.WriteLine($"The color of the {shape.GetType().Name.ToLower()} is {shape.GetColor()} and the area is {shape.GetArea()}");
        }
    }
}