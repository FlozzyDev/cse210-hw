using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Apple";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._company = "Microsft";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2012;
        job2._endYear = 2025;

        Resume resume1 = new Resume();
        resume1._name = "Dallin Hale";

        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        
        resume1.DisplayResume();


    }
}
