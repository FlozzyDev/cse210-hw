using System.ComponentModel.DataAnnotations;

public class Fraction {
    private int _topNumber;
    private int _bottomNumber;

    // Constrcutors
    public Fraction()
    {
    }

    public Fraction (int top)
    {
        _topNumber = top;
        _bottomNumber = 1;
    }

    public Fraction (int top, int botN)
    {
        _topNumber = top;
        _bottomNumber = botN;
    }
    // --------------------------------- Settys and Gettys
    public void SetTopNumber(int top)
    {
        _topNumber = top;
    }

    public void SetBottomNumber(int botN)
    {
        _bottomNumber = botN;
    }

    public int GetTopNumber()
    {
        return _topNumber;
    }

    public int GetBottomNumber()
    {
        return _bottomNumber;
    }
    // Display function 
    public string GetFractionString()
    {
        return $"{_topNumber}/{_bottomNumber}";
    }

    // --------------------------------- Operations
    public double GetDecimalValue()
    {
        return (double)_topNumber / _bottomNumber;
    }


}