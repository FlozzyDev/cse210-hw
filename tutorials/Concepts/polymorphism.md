# Tutorial
## Topic
Concept - Polymorphism

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
Polymorphism is a fundamental  concept in OOP that allows objects of different types to be treated as a common type. The word means "many forms". The general concept is that we can use new keywords to allow child/derived classes to alter what the base class gives it. For instance, we can have multiple methods for DrawShape() (same name) but we can add the overwrite keyword to allow each method to draw fundamentally different shapes using the same base class method. Or get different areas like in the learning activity. The abstract keyword also adds more to it, allowing classes or methods to be created without any actual code, which is then decided in the child class that calls it. 

- virtual - This keyword is used in the base (parent) class to indicate it can be overridden by a derived (child) class.
    - used in BASE class
    - This marks a method to say it has a base implementation, but the derived method can override it. 
- override - This is used in a derived class to allow the underlying virtual method to be altered (overridden)
    - Literally changes the implementation of the base method being called
    - The method signature MUST match EXACTLY
    - Obviously it needs the proper access modifier
    - THIS DOES NOT CREATE A NEW METHOD - it simple changes the base method into a different version of itself
- base - It refers to the base (parent) class and can be used to call methods from the base class from within the derived (child) class.
    - Same thing applies to the constructor (think "it's a" application)
- abstract - Applies to classes OR methods. 
    - An abstract class cannot be instantiated directly, it must be utilized by a child/derived class. It is a blueprint for the children to follow and an object of it cannot be created using "new". 
        - Think of "shape" as a class. You can't make a shape without knowing what it will be. So a child class of circle can be made, and it will have the methods of shape. 
    - An abstract method has no implementation (code). It must be implemented by a "non-abstract derived class". 
- Concrete - This is a "normal" class that inherits from an abstract class. These classes MUST provide implementations for all abstract methods from the parent class. 


## Purpose
The purpose appears to be similar to that of inheritance, which is for cleaner more encapsulated code that can help reduce redundancies and duplicated code. It's nice to be able to define a class at a high level and allow the children classes to create more specific methods to suit the needs that they have. It allows us to be a bit more flexible with how we write things and also lets more complex or specific code be held in the EXACT class that needs it.

## Syntax
This is just a very basic example I made when thinking of a game like Starcraft or Warcraft. But you can see we have an abstract class for a worker, and then we have a concrete class for a specialized worker, a miner. The miner class overrides the action method, but the miner still gets the base worker methods. 

```
public abstract class Worker
{
    public abstract void DoAction();

    public void CheckEnergy()
    {
        Console.WriteLine("The action is done. Checking energy levels...");
    }

    public void OutOfEnergy()
    {
        Console.WriteLine("The worker has run out of energy. They must rest immediately.");
    }

    public void Sleep()
    {
        Console.WriteLine("The worker is resting. Come back later.");
    }
}

public class Miner : Worker 
{
    public override void DoAction()
    {
        Console.WriteLine("The Miner strikes the mineral with his pickaxe!");
    }
}

var worker = new Miner();
worker.DoAction();
worker.CheckEnergy();
worker.OutOfEnergy();
worker.Sleep();
```

## Discussion
I added this more as a resource for myself that I can look at on the fly in case I question the syntax or concept again.

## Other Interesting Notes
