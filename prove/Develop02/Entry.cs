public class Entry
{
    public string _prompt;
    public string _entry;
    public string _date;
    public string _moodString;
    public int _moodRating;

    public void WriteEntry(string prompt, string entry, int moodRating)
    {
        _prompt = prompt;
        _entry = entry;
        _date = DateTime.Now.ToString("yyyy-MM-dd"); /* --------todo - need to see how much of a pain adding the time would be in case multiple entries in a day */ 
        _moodString ="Your mood rating that entry:";
        _moodRating = moodRating;
    }

    public string FormatEntry()
    {
        return $"{_date}|{_prompt}|{_entry}|{_moodString}|{_moodRating}";
    }
    
    public void DisplayEntry() /* After class I realized I didn't have this method in the Entry class(was just all in Journal), moved it over so it's a bit more modular */
    {
            string[] parts = FormatEntry().Split('|');
            Console.WriteLine($"\nDate: {parts[0]} - Prompt: {parts[1]} \nYour response: {parts[2]}\n{parts[3]} {parts[4]}");
    }

    public void ParseEntry(string formattedEntry)
    {
        string[] parts = formattedEntry.Split('|');
        if (parts.Length == 5)
        {
            _date = parts[0];
            _prompt = parts[1];
            _entry = parts[2];
            _moodString = parts[3];
            _moodRating = int.Parse(parts[4]);
        }
    }

    public int GetMoodRating() 
    {
        return _moodRating;
    }

    public int GetPK() /* --------todo - need to add a primary key to each entry - it needs to increment from max of whatever the highest key (in list or in journal.txt)*/
    {
        return 0;
    }
}