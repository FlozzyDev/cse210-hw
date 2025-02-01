using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal() /* moved logic over to Entry and now we call that method here foreach then display the mood avg at the end*/
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
        var (averageMood, entryCount) = GetAverageMood();
        Console.WriteLine($"\nAverage mood rating: {averageMood:F1} across {entryCount} entries");
    }

    public (double averageMood, int entryCount) GetAverageMood() /* Talked to Brother Burton about this, not Ai - told me to add a comment */
    {
        int entryCount = _entries.Count;
        if (entryCount == 0)
        {
            return (0, 0);
        }
        double total = _entries.Sum(entry => entry.GetMoodRating()); /* Talked to Brother Burton about this, not AI. Trying to practice/find uses for LINQ */
        return (total / entryCount, entryCount);
    }

    public void SaveJournal(string filePath)
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to save.");
            return;
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.FormatEntry());
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadJournal(string filePath) /* I really would like to call this after DisplayMainMenu() since it's easy to overwrite save if you create a new entry and then save prior to loading... it hurts to leave this  */
    {
        try
        {
            _entries.Clear();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Entry entry = new Entry();
                    entry.ParseEntry(line);
                    _entries.Add(entry);
                }
                Console.WriteLine("Journal loaded successfully!");
            }
            else
            {
                Console.WriteLine("No journal file found.");
            }
        }
        catch (Exception ex) /* --------todo - need to add a check for the file to see if it's empty or not. Maybe catch some other use cases */ 
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public int GetEntryCount() /* adding so user can see prior to save/display */ 
    {
        return _entries.Count;
    }

    public int GetFileEntryCount() /* --------todo - want to add a similar count to load to pre-check the file when display loads - placeholder name for now */ 
    {
        return 0;
    }

}