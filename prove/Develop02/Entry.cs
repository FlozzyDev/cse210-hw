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
        _date = DateTime.Now.ToString("yyyy-MM-dd"); /* todo - need to see how much of a pain adding the time would be in case multiple entries in a day */ 
        _moodString ="Your mood rating that entry:";
        _moodRating = moodRating;
    }


    public string FormatEntry() /* used when saving in format */ 
    {
        return $"{_date}|{_prompt}|{_entry}|{_moodString}|{_moodRating}";
    }


    public void ParseEntry(string formattedEntry) /* When loading the journal, this will parse the entry back into format */
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
}