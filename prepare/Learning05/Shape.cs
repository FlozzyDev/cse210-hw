public class Shape {

    protected string _color;

    public string GetColor()
    {
        return _color;
    }

    public string SetColor(string color)
    {
        _color = color;
        return _color;
    }


    public Shape(string color) {
        _color = color;
    }

    public virtual double GetArea()
    {
        return 0;
    }

}