public class Product 
{
    private string _name;
    private string _productId;
    private float _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, float price, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = price;
        _quantity = quantity;
    }

    public string GetProductName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public string GetProductQuantity()
    {
        return _quantity.ToString();
    }

    public float TotalProductPrice()
    {
        return _pricePerUnit * _quantity;
    }
}