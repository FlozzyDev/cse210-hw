using System;

class Program
{
    static void Main(string[] args)
    {   
        // First order to which is in the USA
        var address1 = new Address("6238 Elm St", "Springfield", "IL", "USA");
        var customer1 = new Customer("Billy Smith", address1);
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Liquid Death - 8 pack", "234", 11.99f, 3));
        order1.AddProduct(new Product("Epsome Salt", "4123", 3.99f, 8));
        order1.AddProduct(new Product("AAA Battery Pack - 6 pack", "13422", 1.99f, 3));
        order1.AddProduct(new Product("DuckBoi - Duct Tape", "1234", 4.99f, 2));
        // identical order to order1 but in Canada (to show shipping cost difference)
        var address2 = new Address("8326 Oak St", "La Prairie", "QA", "Canada");
        var customer2 = new Customer("Smithy Bill", address2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Liquid Death - 8 pack", "234", 11.99f, 3));
        order2.AddProduct(new Product("Epsome Salt", "4123", 3.99f, 8));
        order2.AddProduct(new Product("AAA Battery Pack - 6 pack", "13422", 1.99f, 3));
        order2.AddProduct(new Product("DuckBoi - Duct Tape", "1234", 4.99f, 2));
        // order with different products
        var address3 = new Address("134 Yellow Brick Rd", "Mesa", "AZ", "USA");
        var customer3 = new Customer("Jane Roberts", address3);
        var order3 = new Order(customer3);
        order3.AddProduct(new Product("Ring G4 Doorbell Camera", "23431", 211.99f, 1));
        order3.AddProduct(new Product("Xtreme Shirts - Black", "1113", 13.99f, 3));
        order3.AddProduct(new Product("Nike Sock Bundle", "13422", 1.99f, 3));
        order3.AddProduct(new Product("DuckBoi - Duct Tape", "1234", 4.99f, 4));
        // identical order to order3 but in Canada (to show shipping cost difference)
        var address4 = new Address("7741 East Golf Avenue", "La Prairie", "QC", "Canada");
        var customer4 = new Customer("Maple Sapper", address4);
        var order4 = new Order(customer4);
        order4.AddProduct(new Product("Ring G4 Doorbell Camera", "23431", 211.99f, 1));
        order4.AddProduct(new Product("Xtreme Shirts - Black", "1113", 13.99f, 3));
        order4.AddProduct(new Product("Nike Sock Bundle", "13422", 1.99f, 3));
        order4.AddProduct(new Product("DuckBoi - Duct Tape", "1234", 4.99f, 4));

        order1.GetPackingLabel();
        order1.GetShippingLabel();
        order1.DisplayTotalOrderPrice();
        Console.WriteLine();

        order2.GetPackingLabel();
        order2.GetShippingLabel();
        order2.DisplayTotalOrderPrice();
        Console.WriteLine();

        order3.GetPackingLabel();
        order3.GetShippingLabel();
        order3.DisplayTotalOrderPrice();
        Console.WriteLine();

        order4.GetPackingLabel();
        order4.GetShippingLabel();
        order4.DisplayTotalOrderPrice();
        Console.WriteLine();

    }
}