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

    public int GetHideCount()
    {
        int nonHiddenWord = 0;
        foreach (Word word in _words)
        {
            if (!word.HideStatus())
            {
                nonHiddenWord++;
            }
        }

        if (nonHiddenWord > 25 )
        {
            return nonHiddenWord / 4;
        }
        else if (nonHiddenWord > 15)
        {
            return nonHiddenWord  / 5;
        }
        else if (nonHiddenWord > 10)
        {
            return nonHiddenWord  / 3;
        }
        else if (nonHiddenWord > 4)
        {
            return nonHiddenWord  / 2;
        }
        else
        {
            return 1;
        }

        

        
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