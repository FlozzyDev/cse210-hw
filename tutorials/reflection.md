# Tutorial
## Topic
Reflection

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Dallin Hale

## Overview
Reflection is a feature that allows the program access with metadata during runtime. This seems to be a fairly advanced feature, but I'm adding a quick tutorial that I can add to more if I find any other use cases for it (I doubt). For now, I was looking to find an easy way to get a class name without adding a name attribute and found this. Keep in mind, I am aware that this is probably not a valid way of doing things and at scale this is probably really bad for performance / not what this is supposed to be used for!

## Purpose
So reading about it, it appears much of the use cases for it is for dynamic variables or possible external code with plugins and whatnot. I initially went down the road of the dynamic keyword and I am confident that I won't touch that thing anytime soon. 

But for my own purposes, the only real purpose I had was to get and print the name of a class during each iteration of a foreach loop! Again, this is more for fun than anything! 

## Syntax
As I have stated previously, I just wanted to create this in reference to using this in learning 05! 

```
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
```

## Discussion
Yeah not much to discuss as far as how I used it. The more I read, the more I am confident I will never use this feature besides VERY niche cases like this where I wanted to pull some of the metadata for fun. 

## Other Interesting Notes

So I found quite a few really interesting things going down this rabbit hole! Firstly, I got a little better understanding of memory management and learned a bit more of the differences in runtime code. It sounds like this at scale would be much harder on performance since it skips the compiler, which makes the code a bit more sketchy since it could end up causing an error. I assume when this is used, there's a ton of error checking you need to build in. 

I have a little experience in building plugins using Javascript, mainly for a program called Figma, and it sounds like this is something that's used when making plugins. It seems related to the dynamic keyword, which appears to be a bit of a wild card that allows code to skip the compile type checks. This is way over my head, but it sounds like this is what you need to do in order to get your code to compile so it can interact with external code outside of the system. 

I went down another rabbit hole regarding memory management and how the stack/heap works. So based on that, it sounds like some of the performance is related to how this interacts with the call stack. It sounds like normally when code is compiled, the compiler builds "optimized instructions" using the exact method signatures. But since these things are being called after compile, they are outside of those instructions and it instead needs to dynamically generate new instructions. I didn't get too deep, but it sounds like this requires the call stack to be totally rebuilt, which I assume at scale is painful. 