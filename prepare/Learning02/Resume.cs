

public class Resume 
{

    public string _name;
    public List<Job> _jobs = new List<Job>();


    public Resume() 
    {
    }

    public void DisplayResume()
    {
        Console.WriteLine($"Resume for: {_name}");
        Console.WriteLine("Work Experience: ");

        foreach (Job job in _jobs)
        {
            job.DisplayJob();
        }
    }


}

