# Tutorial
## Topic
LINQ - Language Integrated Query

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
I'm pumped to write this one! So LINQ is probably the think I want to learn the most about right now in C#. I really enjoy SQL and use it everyday at work. I also have messed around a little with go-jet (helped by coworkers) to make minor edits to some automatic reports we generate.

Firstly - when using we will want to add "using System.Linq;" at the top with the other namespaces. I read that this isn't necessary since .NET 6 which it added the "global usings" feature that includes a bunch of common namespaces (including linq) whenever a file is created, but I suppose it's good practice. There are additional namespaces such as Linq.Expressions, or Xml.Linq, but I won't be looking at those for now. 

LINQ adds different query functionalities to C#, allowing fast and easy data manipulation and data retrieval. The two basic types of queries are using method syntax or query syntax explained more below. If you know the syntax, it allows for fairly easy searching / formatting / sorting / aggregating that is also pretty readable and simple. Instead of taking time to build out logic to sort or sum something, you can use these methods. 

Something to keep in mind is LINQ is specifically used for groups (collections) of data. So lists, arrays, dictionaries, sets, and of course actual database data (still need to learn more on that).


## Purpose
Some of the core methods (also below) are super useful and are very nice to use for basic functions, such as using the sum function. In the first assignment, I added a mood rating that each entry had. Then I created a function that took each entry and added the 

## Syntax

Method Syntax - Now how I understand it is this is a lambda function (in-line function) that uses LINQ as a framework. I know that is a very simple way of explaining it and I need to at some point sit down and really define the different between parameters / expression / delegates and whatnot, but for now I will keep it simple to that. 

```
var query = collection.Where(item => item.Property > 10);
```

Query Syntax - similar to SQL
```
var query = from item in collection
            where item.Property > 10
            select item;
```

I don't think I will use the actual query syntax in this class, so for now I'm going to stick with the previously mentioned method syntax. The basic breakdown is:

```
var result = collection.Method(parameter => expression)
```

var = I made a tutorial about this, but it is a keyword that enables the type to be inferred by the compiler. 
result = the variable name that will store whatever this method returns
collection = The data, but specifically a group of data like a list or array
method() - One of the LINQ methods (see below)
parameter - A name chosen to represent a specific item from the collection. Just used within the lambda, similar to a loop variable.
=> - lambda operator - separates the parameter from the expression it will be applied to
expression - what will be applied to each parameter 


### Common Methods

1. Where - Just like in SQL, filters the results off the condition given. This cases looking at bools and returning the true or false values. 

```
var hiddenWords = _words.Where(w => w.HideStatus()); 
var non-members = people.Where(p => !p.IsMember);
```
2. OfType - Filters based on the type, so in this case just getting the words from the Scripture object. 

```
var wordObjects = _scripture.GetElements().OfType<Word>(); 
```
3. OrderBy - Again, like SQL. Order By a specific property, in this case the length of the words. 

```
var wordsByLength = _words.OrderBy(w => w.GetWord().Length);
```

4. ThenBy - If this in SQL, I don't use it so this is cool! It seems like the AND to where, but for order by. Or like adding a second sort in excel. In this case, order by hide status forst and then by word length.

```
var sortWords = _words.OrderBy(w => w.HideStatus()).ThenBy(w => w.GetWord().Length);
```
5. GroupBy - Like SQL, grouping by a specific key

```
var wordsByStatus = _words.GroupBy(w => w.HideStatus());
```

6. First - Returns the first element that meets the condition - thought this was very cool! So technically in the scripture memorizer, if I wanted to cause the words to disappear in order from first to last, I could use this to keep returning the first hidden word, hide it, and then call it again. 

```
var firstHiddenWord = _words.First(w => w.HideStatus());
```

7. Any - Can check to see if elements match a specific condition. In this case, it will be true if any word is over 10 length.

```
bool longWords = _words.Any(w => w.GetWord().Length >10);
```

8. Count - Fairly simple, used to count things meeting a condition (like SQL). So here, similar to the last one but we will count the number of words over 10 length. 

```
int visibleCount = _words.Count(w => w.GetWord().length > 10);
```

9. sum/min/max/average - The classic 4 operations we can use. So sticking with the length of words...

```
int maxLength = _words.Max(w => w.GetWords().Length);
int minLength = _words.Max(w => w.GetWords().Length);
double avgLength = _words.Average(w => w.GetWords().Length);
int sumLength = _words.Sum(w => w.GetWords().Length);
```


## Discussion
Random is extremely useful and is used quite often. I've been building a few games as web projects and I use it all the time. 

## Other Interesting Notes

Anonymous types -I'm just throwing this here since I was looking at var/LINQ and came across it - but tuples seem VERY similar to anonymous types and I want to make sure I make the dinstinction between them. Anonymous types are different in that they are read-only, appear to be specific to LINQ, and a few other aspects such as being accessed via the name and the type always being infered. I'm obviously not super knowledgeable around them, but they appear to be similar to a SQL CTE, expect they are used only once.


## Additional Reading Material / Quick Sources
https://learn.microsoft.com/en-us/dotnet/csharp/linq/
https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/anonymous-types
