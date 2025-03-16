# Tutorial
## Topic
Static Keyword

## Author

Author name: Dallin Hale

## Overview
The Static keyword is a keyword that specifies that something belongs to itself, meaning it is not an instance. They can be used in Classes, Fields, Methods, Properties, or Constructors. This is very limiting, but that's a good thing since we want the static things to be very specific and do a specific job. A normal non-static member belongs to the specific INSTANCE while a static member belongs to the CLASS (or type) itself. They are used when you don't need to make multiple objects of something and just need to create 1 of something (such as a counter or global setting).

## Purpose
Static allows something to be used repeatedly and have the same data / access / memory. They are very efficient for thing such as utility functions or any object that you would want to share resources. It's an easy way to have constant methods or values since there is only one of itself and it simply just does it's job. Global settings and global variables that need to be constant would be created using static, since you don't want those having multiple copies of itself. 

## Syntax
The syntax of static is very similar with other keywords. It's added before whatever you are applying it to. 
Classes - public static class MathEquations - Such as a utility class that we just need to call specifically. It can't be instantiated and all it's members are static. 
Fields - public static int TotalCount = 0; - In case we want to make sure we only have 1 counter
Methods - public static int Add(int a, int b) - Similar to the class, but to show a specific method we could call when we need to add things. We don't need instances of it. 

Below is a "utility class" that we want to make static as we only need to call it and not make multiple instances. The method inside doesn't need anything but the input, then produces the output. Perfect for static.
```
public static class StringHelper
{
    public static string Capitalize(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
            
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
```

```
string name = "joseph";
string capitalized = StringHelper.Capitalize(name);
```

## Discussion
There's much more to go into with static but I think this is a good general overview for now. I think it's worth noting that static elements seem to be an easy way to introduce bugs or mess up your program since changes can be global and testing would be harder. Since they live for the duration of the program, I imagine it puts a strain on memory and performance. 

## Other Interesting Notes
