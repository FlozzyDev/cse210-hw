# Tutorial
## Topic
Luples - Data Structure

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
Tuples are a lightweight data structure that allows a person to group multiple elements together. It's considered "lightweight" because it allows a way to return specific data without needing to make an entire class for this purpose. A common use case (and what I used one for) is to return 2 items from a single method, such as in my "GetWordCount()" function from the scripture assignment that returned both (int visibleWords, int wordsToHide). 

Tuples can be created by either making one via a constructor or a method. 

They can store both simple and complex data types, such as multiple arrays or a mixture of different types. 

It sounds like it's best practice to limit them to 8 elements, but even that would be probably not be very clean and may indicate a class would be better.

## Purpose
Typically tuples are used for simple and related data that an internal method is returning. It's a temporary grouping of data that can be used for easy data transfer between methods that keeps things more simple. They are fast and easy to create but have drawbacks such as needing all elements passed (or explicate discarded), or how the position of the data matters a great deal and not the name. Tuples are generally "deconstructed" after they move data, as it's easier to manage individual variables instead of constantly referring to the more complicated tuples. I personally view it to a ZIP file, where data is compressed into a ZIP folder for transport but needs to be unpacked (deconstructed) once it arrives. They are temporary and very useful, but easy to make things more complicated if you don't use them right. They are much more complex than this, but I'm just doing a basic overview of how I personally view them after my research. 


## Syntax

Constructor - One way to create a tuple

```
(string name, int age, bool isMember) memberDetails = ("Dallin", 30, true);
```

Method - Another way to create a tuple 

```
public (string name, int age, bool isMember) GetMemberDetails ()
{
    return ("Dallin", 30, true);
}
```

Deconstruction - In the above, once the tuple is made I would want to pass it to the program and then assign those variables. It should be noted that tuples assign based on position, so it's important to make sure the variables are in the proper order. 

```
string memberName;
int memberAge;
bool isActive;

(memberName, memberAge, isActive) = GetMemberDetails();
```

## Discussion
Tuples are very useful and I would like to get used to using them as often as I can. As I said previously, tuples are pretty complex the more I read about them and I understand that my ZIP analogy is a very simple way at looking at them. I also understand that this probably isn't the best data type to rely on since it has quite a few drawbacks and really needs to just be used as a temporary tool, not something to store complex data long-term. 

## Other Interesting Notes
In the deconstruction example above, if I wanted to only return the 1st and 3rd elements, I would need to use an "_" to indicate I wanted to discard the second element. If I don't, it won't compile. This type of complexity is why tuples and deconstruction are so common. See below!

Anonymous types -I'm just throwing this here since I was looking at var/LINQ and came across it - but tuples seem VERY similar to anonymous types and I want to make sure I make the distinction between them. Anonymous types are different in that they are read-only, appear to be specific to LINQ, and a few other aspects such as being accessed via the name and the type always being inferred. I'm obviously not super knowledgeable around them, but they appear to be similar to a SQL CTE, expect they are used only once.

```
string memberName;
bool isActive;

(memberName, _, isActive) = GetMemberDetails();
```

## Additional Reading Material / Quick Sources
https://www.youtube.com/watch?v=QC6hpl2iU0c -- quick 10 min intro 
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
