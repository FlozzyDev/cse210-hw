public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Data data) // Talked to Brother Burton about this and he said it was fine that I changed the constructor. 
    {
        string verseText = data.GetColumnC().Trim();

        if (verseText.Contains('-'))
        {
            string[] verses = verseText.Split('-');
            _reference = new Reference(data.GetColumnA().Trim(), int.Parse(data.GetColumnB().Trim()), int.Parse(verses[0].Trim()), int.Parse(verses[1].Trim()));
        }
        else
        {
            _reference = new Reference(data.GetColumnA().Trim(), int.Parse(data.GetColumnB().Trim()), int.Parse(verseText.Trim()));
        }

        _words = new List<Word>();
        string[] wordList = data.GetColumnD().Trim().Split(' ');
        foreach (string word in wordList)
        {
            _words.Add(new Word(word));
        }
    }

    public (int visibleWords, int wordsToHide) GetWordCount() // find visible words and base the number of words to hide on that
    {
        int visibleWords = 0;
        foreach (Word word in _words)
        {
            if (!word.HideStatus())
            {
                visibleWords++;
            }
        }

        int wordsToHide = 0;
        if (visibleWords <= 3)
        {
            wordsToHide = visibleWords;
        }
        else if (visibleWords <= 15)
        {
            wordsToHide = 3;
        }
        else if (visibleWords <= 25)
        {
            wordsToHide = 5;
        }
        else
        {
            wordsToHide = 8;
        }

        return (visibleWords, wordsToHide);
    }

    public void HideRandomWords(int hideNumber)
    {

        Random random = new Random();
        int wordsHidden = 0;

        while (wordsHidden < hideNumber)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].HideStatus())
            {
                _words[index].HideWord();
                wordsHidden++;
            }
        }
    }

    public string GetTextDisplay()
    {
        string text = "";
        foreach (Word word in _words)
        {
            text += word.GetWord() + " ";
        }
        return _reference.GetReference() + text;
    }

    public bool AllTextHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.HideStatus())
            {
                return false;
            }
        }
        return true;
    }


}