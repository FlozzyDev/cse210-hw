using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            string[] parts = entry.FormatEntry().Split('|');
            Console.WriteLine($"\nDate: {parts[0]} - Prompt: {parts[1]} \nYour response: {parts[2]}\n{parts[3]} {parts[4]}");
        }
        var (averageMood, entryCount) = GetAverageMood();
        Console.WriteLine($"\nAverage mood rating: {averageMood:F1} across {entryCount} entries");
    }


    public (double averageMood, int entryCount) GetAverageMood() /* used a tuple, not sure if that's okay. I didn't want to make a whole class for mood and this worked with LINQ*/
    {
        int entryCount = _entries.Count;
        if (entryCount == 0)
        {
            return (0, 0);
        }
        double total = _entries.Sum(entry => entry.GetMoodRating()); /* going to try and get used to using LINQ/lambda more in this and future programs */
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

    public void LoadJournal(string filePath)
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }



    public int GetEntryCount() /* adding so user can see prior to save/display */ 
    {
        return _entries.Count;
    }

    public int GetFileEntryCount() /* want to add a similar count to load to pre-check the file when display loads - placeholder name for now */ 
    {
        return 0;
    }

}