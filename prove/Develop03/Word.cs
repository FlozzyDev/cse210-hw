public class Word 
{
    private string _content;
    private bool _isHidden;

    public Word(string content)
    {
        _content = content;
        _isHidden = false;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public bool HideStatus()
    {
        return _isHidden;
    }

    public string GetWord()
    {
        if (_isHidden)
        {
            return "____";
        }
        else
        {
            return _content;
        }
    }

    


}