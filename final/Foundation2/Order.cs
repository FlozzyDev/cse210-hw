public class Order 
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private float TotalOrderPrice()
    {   
        float shippingCost = 35.00f;
        float productTotal = 0;
        foreach (Product product in _products)
        {
           productTotal += product.TotalProductPrice();
        }
        if (_customer.CustomerInUSA())
        {
            shippingCost = 5.00f;
        }
        float total = productTotal + shippingCost;
        return (float)Math.Round(total, 2);
    }

    public void DisplayTotalOrderPrice()
    {
        Console.WriteLine($"Total Order Price: ${TotalOrderPrice()}");
    }

    public void GetPackingLabel()
    {
        Console.WriteLine($"Package contains:");
        foreach (Product product in _products)
        {
            Console.WriteLine($"Product Name: {product.GetProductName()} | Product ID:{product.GetProductId()} | Quantity:{product.GetProductQuantity()}");
        }
        Console.WriteLine();
        
    }

    public void GetShippingLabel()
    {
        Console.WriteLine($"Ship to:\nCustomer: {_customer.GetCustomerName()}\nAddress:\n{_customer.GetCustomerAddress()}");
        Console.WriteLine();
    }




}