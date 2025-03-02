# Tutorial
## Topic
Constructors

## Author
Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Brother Burton

## Overview
Constructors are a way that you can specify the things that should happen when a new object is created.

## Purpose
The main purpose of a constructor is to set up initial values for each of the member variables of a class. These values can be passed in as parameters or default values can be used.

## Syntax
Constructors are defined similar to member functions, except that they have no return value, and the name must match the class name exactly. The following is an example of a constructor for a `Person` class.

```
public class Person
{
    private string _name;

    public Person(string newName)
    {
        _name = newName;
    }
}
```

You call the constructor when you use the `new` keyword to create the object, like this:

```
Person p = new Person("John");
```

## Discussion
As you can see, constructors can be quite useful when using classes. They make it so that you don't have to worry about variables being unassigned, and they allow you to run additional code, such as if you need to obtain values to add to a list.

## Other Interesting Notes
You can have more than one constructor for a class, in case you want to have constructors that accept different parameters such as `Person()`, `Person(name)`, and `Person(firstName, lastName)`.

The program determines which one to call based on what you pass to the constructor.