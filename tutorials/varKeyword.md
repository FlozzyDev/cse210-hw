# Tutorial
## Topic
Var - Keyword
I also go over a few other generic terms I went over and learned while learning about this. 

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
The var keyword allows variables to gain the data type that is "inferred" by allowing the compiler to decide the data type based on the expression it was given. This is different from what we normally do, when we explicitly state what a variable type is. The variable is still strongly typed, it's type is not defined until it's compiled. I realize this is a fairly niche thing to use right now, but I like the way it reads and feels for variables like lists or in use in loops. 

Some rules to remember: 

Variables must be immediately initialized - meaning the variable needs to be given a value and cannot have a value that is defined later in the program. This is because it creates a logic loop where the compiler wants to provide a type to the variable, but needs the value to provide the type, but the value can only be given once the type is defined, ect, ect. Hence logic loop. 

Var can be used in local variables inside of method, but NOT for fields, parameters, or return types - I think it's easier to provide examples, so I will create a few in the syntax section using the mindfulness app activity methods.

Var cannot be initialized with null (null has no type).

Var cannot change type after it's declared

NOT ALLOWED!
```
var x = 10;
x = "hello";
```

Some more examples:
```
var x = 100; <--- This is good! It's easy to see it's an int.
var y = 101.10 <----- Good! It's a double.
var z; <---- BAD! Z needs to be given a value if var is to be used. 
var xyz = valueNotYetGiven; <---- Depends... has this been defined previously? Is this a method that provides a value? Or is it undefined/null?  
```

## Purpose
I personally view var as just a time saving tool and also it seems to make programs a bit more readable and reduces writing redundant code. It has a precise use of allowing a way of declaring "anonymous types", and this opened up a massive rabbit hole I fell in to learn about those. In short, anonymous types is another data structure, VERY similar to tuples but with distinct differences (read-only, also has an inferred type at compile, used for temporary data storage). They are primarily used in LINQ, which I will cover what I know more in-depth later. So without that specific use case, var to me is more of a quality of life tool that I like to use for variables like lists. 

A good example for readability and time saving sake would be around LINQ's grouping or really any LINQ expressions. Also some LINQ expressions can be hard to even understand what the end result will be that var is nice to have as it will determine it. Maybe that's a bad way of looking at it, since that's me admitting that I would be unclear what exactly my query would be returning, but I in my experience sometimes queries get messy very quickly... Below is just making IEnumerable not horrible to look at. 

Without var 
```
IEnumerable<IGrouping<string, Customer>> customersByCity = customers.GroupBy(c => c.City);
```

With var 
```
var customersByCity = customers.GroupBy(c => c.City);
```

I could provide more LINQ specific uses, but even in our class projects, var seems like a nice tool to clean up some of the ugly code c# seems to produce, such as declaring a list when making a new list instance. 

Without var
```
List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
```

With var
```
var spinnerChars = new List<string> { "|", "/", "-", "\\" };
```

It's not a huge change, but I do like the way it looks much more as it feels more like a proper sentence. 

## Syntax

I provided a few examples above, but I wanted to take some of my current methods and apply var to them to document for myself when I can and can't use it. 

### May use it: Local variable inside of a method

```
protected void ShowSpinner()
{
    var spinnerChars = new List<string> { "|", "/", "-", "\\" };
    
    foreach (string s in spinnerChars)
    {
        Console.Write(s);
        Thread.Sleep(1000);
        Console.Write("\b\b");
    }
}
```
### May NOT use it: Inside of class fields
This is live (works)
```
protected string _name;
protected string _description;
protected int _duration;
protected DateTime _startTime;
```
This is wrong - The reason has to do with how compilers work with classes and memory, but I didn't fully understand. I do however understand it's not allowed! 
```
protected var _name;
protected var _description;
protected var _duration;
protected var _startTime;
```
### May NOT use it: Method parameters

```
protected Activity(var name, var description)
{
    _name = name;
    _description = description;
    _startTime = DateTime.Now;
}
```

### May NOT use it: Return types

```
protected var GetActivityDuration()
{
    return _duration;
}
```

## Discussion
From spending a few hours reading about and watching videos about this and a few other topics, I can see that it is useful to know but seems pretty niche for the level I am at. I'm going to try to use it a little bit, but I don't think it will be super useful to me until I start getting into LINQ more and I'm not sure how much I will get into it with this class. That said, it was extremely helpful to step through this since it opened up many other terms. I think going over var is also really good for me to get a grasp on implicit/explicit and really understand strongly typed vs weakly. It also led me to learn a bit more about compilers and understand at least a bit more on the logical steps it takes and what it's doing / responsible for. 

## Other Interesting Notes
Researching this and LINQ was honestly incredibly useful and fun as it forced me to learn a lot of other terms and information regarding c# in general. So I'll write out some basics here, but I may do a separate page for some (properties has enough for one surely)

Fields - A field is just a class level variable. We have been calling them class attributes, but it appears they are called fields when they are specific to a class. 

Properties - Similar to field, we have gone over this but we didn't really reference them as properties explicably. getter/setter/init - provides some sort of ability to read/write/compute the value of a field. Getter = read, setter = write, while an init provides an initial write and then becomes read-only. The book definition is a property "combines aspects of a field and method". Also worth noting, the setter is a good place to validate information instead of making a specific method for it. 

Value vs expression - This may be silly but I went down a rabbit hole to fully understand this. From my reading, it appears that not all expressions are values but all values are expressions. An expression is, well really many things that can eventually be evaluated to become a value. It can be one or multiple values, variables, operators, and or entire functions that will produce a value. A value is the final result of an expression. They are the simplest form of an expression, they evaluate to literally themselves. 3 (value), while 1 + 2 = 3 (expression).  I just needed to make sure this is clear since expression/value seem to be something that's easy to use interchangeable (a var type is decided based on the expression assigned to a variable at compile time).



## Additional Reading Material / Quick Sources
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables
https://stackoverflow.com/questions/4307467/what-does-var-mean-in-c
https://stackoverflow.com/questions/34647121/want-to-distinguish-between-value-and-expression
https://www.youtube.com/watch?v=oHXzGYR1NIs - var explained / a use case
https://www.youtube.com/watch?v=_EB1f0-aVv0 - Fields basics
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
https://www.youtube.com/watch?v=y-MBp2y9t1U - property basics
https://www.youtube.com/watch?v=8FmE_-QXg3Y - getter/setter basics (validation)



