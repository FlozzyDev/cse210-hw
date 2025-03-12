using System;

class Program
{
    static void Main(string[] args)
    {
        // varKeyword.md
        var video1 = new Video("Baby Shark Dance", "The Dark One", 30000);
        video1.AddComment(new Comment("user2342", "I hear this in my nightmares!"));
        video1.AddComment(new Comment("NotTheCIA", "I love this video, very useful to play for my friends on repeat, makes them chatty!"));
        video1.AddComment(new Comment("SmallChild1", "I love to play this for my parents 24/7!"));

        var video2 = new Video("Despacito", "Luis Fonsi", 301);
        video2.AddComment(new Comment("user2333", "Great song!"));
        video2.AddComment(new Comment("SomeGuy23", "I proposed to my wife to this song!"));
        video2.AddComment(new Comment("AverageRedditor", "I'm just hear to read the comments."));

        var video3 = new Video("The End Of Programming As We Know It", "ThePrimeTime", 4020);
        video3.AddComment(new Comment("DallinH", "I just heard about this in class!"));
        video3.AddComment(new Comment("Programmer123", "Couldn't have said it better myself!"));
        video3.AddComment(new Comment("TheOne1", "Makes sense!"));

        var video4 = new Video("Top Best Dubstep August 2012", "ThePrimeTime", 1102);
        video4.AddComment(new Comment("user22", "I miss this type of song being made."));
        video4.AddComment(new Comment("ThatLady12", "This brings back some good times!"));
        video4.AddComment(new Comment("StepDub2", "Back when Dubstep was unknown!"));
        video4.AddComment(new Comment("RoverDoverMover", "Great songs!"));
        
        video1.GetVideoInfo();
        Console.WriteLine("");
        video2.GetVideoInfo();
        Console.WriteLine("");
        video3.GetVideoInfo();
        Console.WriteLine("");
        video4.GetVideoInfo();
        Console.WriteLine("");

        
          
    }
}