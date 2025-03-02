# Tutorial
## Topic
Random Class (namespace: System)

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
Random is a class that's default included inside the System namespace. It's used to do what the name says, generate a "random" number using an algorithm.

Term: Seed - A seed is the starting value that gets fed into the algorithm. As I discuss a bit later, the default constructor for Random uses the internal time as the seed, so as time passes and random is called, it will always be different. You can also give random it's starting seed value, which would mean you are taking away the "randomness" in a sense, as you will always get the same value from the same seed value. 

Constructors - Random has 2 constructors, random() and random(int32). 

Random() uses the current systems exact time as the "seed" value, or the starting place, meaning it should theoretically always be different as time passes. Also the "system time" is in milliseconds like always so it's pretty specific. 

Random(int32) means you can give it a number and this will be used as the seed. This removes the randomness, since the same seed will lead to the same result. It appears this is used for
debugging, but also this is exactly what a seed in gaming is. A player can provide the numeric ID for a procedurally generated map (such as minecraft) because this seed is simply the
baseline number the "random" generation is based on. Very cool, I was happy to learn that! 

Beware Loops! If we make multiple Random() instances really quickly (like in a loop), this can lead to the same seed being used if the internal clock doesn't advance between creations. Reading, it 
sounds like the way around this is to try and use 1 instance of random when possible, reusing it for different parts of the program. I imagine you could also add a sleep function or something
similar between instances, but I suppose at scale that would slow everything down. 



## Purpose
The purpose of Random depends on the situation it's used for. I tend to use it to "randomize" a choice, whether that's picking a random prompt or choosing a random path for a user.

## Syntax 
Random as a class can get quite complex, so my plan is to just talk about the syntax or methods that I've been using or think I will use. If I use a new one, I will try to remember to add it to this list!

Method - random.Next() - returns a "random" integer 
```
Example given: int number = random.Next(); 
```

Method - random.Next(int32, int32) - Returns a random integer between the values you pass it (min) / (max)

Quick side note on this - the min value is INCLUSIVE and the max is EXCLUSIVE, which needs some getting used to. The example below shows;

```
int placement = random.Next(5, 14)
```
This would be a random number between 5 and 13. Notice it's 13 and not 14, as 5 is included, while 14 (max) is excluded. 
```
int placement1 = random.next(0,10)
int placement2 = random.next(10,20)
```
10 only has a chance to be used 1 time, as the first number is between 0-9 and the second is between 10-19. Both have 9 possible values.



Method - random.Next(int32) - This is going to give a random number between 0 and whatever number given.

Interesting point here I found - a dice roll is 1 - 6 obviously. So the first example is an accurate dice roll, but the values are actually 0 - 5. In order to make it 1 - 6, we need to change it. 
If we want to use max, we have to add 1 to the range to push the values to 1-6. If we used the previous method, we could just do (1,7)

```
int diceRoll = random.Next(6); 
int maxDiceRoll = random.Next(6) + 1;
int rangeDiceRoll = random.Next(1,7); 
```


## Discussion
Random is extremely useful and is used quite often. I've been building a few games as web projects and I use it all the time. 

## Other Interesting Notes

Another interesting thing - there is a different more complex Random method inside of System.Security.Cryptography which should be used to generate security related objects, such as an auth token or ssh key. The method for that is RandomNumberGenerator, which is much more robust based on my light reading. Random is fine for most non-critical things it sounds like. 

## Additional Reading Material / Quick Sources
https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-9.0
