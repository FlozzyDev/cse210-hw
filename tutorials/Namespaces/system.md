# Tutorial
## Topic
System - Namespace

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
The system namespace is super basic, but I feel like it has some advanced things that we haven't gone over that I've been trying to use. As I use them or plan to use them, I'm going to try and document those here. But the overview of system is it's a default namespace that includes many useful things, such as Console, DateTime, ect. Using System is what we need to put at the top (although I don't think it's needed in modern systems like the other defaults)

## Purpose
System has very basic but very useful functions and the purposes vary wildly. I will list the ones I use and research below:

## Syntax 

### DateTime
DateTime allows a user to get specific date/time and has additional methods to manipulate it.\

To get the current date and time
```
DateTime now = DateTime.Now: 
```

To add time (such as with the mindfullness app). So a user provides a duration which is added to startTime, giving us a future endTime. 
```
DateTime endTime = DateTime.Now.AddSeconds(_duration)
```
### Console 
I'm going to simply list console as it's self explanatory
Console.Clear() - Clears the console
Console.Write / Console.WriteLine - We know this 

### Thread
Thread is super cool but I'm fairly confident that there is better things to use. I'm using it in mindfulness to try and create the animations, but I learned that this isn't the best to use since it literally stops the program when I use the Thread.Sleep.

Thread.Sleep - As mentioned, used in mindfullness - stops the program and waits for n time to go by. This is from the activity.cs where I put the spinner they all use. 
```
var spinnerChars = new List<string> { "|", "/", "-", "\\" }; // varKeyword.md
        foreach (var s in spinnerChars)
        {   
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
```

## Discussion
This file isn't the most advanced for now but I plan to take some time and try and document some additional methods I want to use or understand better. Threading for instance is something I want to spend more time on. This isn't finished, more of just a placeholder I want to fill out more. 

## Other Interesting Notes

## Additional Reading Material / Quick Sources
https://learn.microsoft.com/en-us/dotnet/api/system?view=net-9.0
https://www.youtube.com/watch?v=TUmHDa6joEs
