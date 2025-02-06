using System;
using System.Collections.Generic;

class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        ProductName = name;
        Price = price;
    }

    public void ShowProductDetails()
    {
        Console.WriteLine("  - " + ProductName + " (₹" + Price + ")");
    }
}

class Order
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public double TotalAmount { get; private set; }

    public Order(int orderId, Customer customer)
    {
        OrderId = orderId;
        Customer = customer;
        Products = new List<Product>(); // Aggregation: Order contains Products
        TotalAmount = 0;
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
        TotalAmount += product.Price;
    }

    // Show order details
    public void ShowOrderDetails()
    {
        Console.WriteLine("\nOrder ID: " + OrderId + " | Customer: " + Customer.CustomerName);
        Console.WriteLine("Products:");
        foreach (var product in Products)
        {
            product.ShowProductDetails();
        }
        Console.WriteLine("Total Amount: ₹" + TotalAmount);
    }
}

class Customer
{
    public string CustomerName { get; set; }
    public List<Order> Orders { get; set; }

    public Customer(string name)
    {
        CustomerName = name;
        Orders = new List<Order>(); // Association: Customer has multiple Orders
    }

    // Place an order
    public Order PlaceOrder(int orderId)
    {
        Order newOrder = new Order(orderId, this);
        Orders.Add(newOrder);
        Console.WriteLine("\n" + CustomerName + " placed a new order (Order ID: " + orderId + ").");
        return newOrder;
    }

    // Show order history
    public void ShowOrderHistory()
    {
        Console.WriteLine("\nOrder history for " + CustomerName + ":");
        foreach (var order in Orders)
        {
            order.ShowOrderDetails();
        }
    }
}

class Program
{
    static void Main()
    {
        // Create products
        Product laptop = new Product("Laptop", 90000);
        Product phone = new Product("Smartphone", 59000);
        Product headphones = new Product("Headphones", 19900);

        // Create customers
        Customer alice = new Customer("Aman");
        Customer bob = new Customer("Rahul");

        // Alice places an order
        Order order1 = alice.PlaceOrder(101);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);

        // Bob places an order
        Order order2 = bob.PlaceOrder(102);
        order2.AddProduct(phone);

        // Alice places another order
        Order order3 = alice.PlaceOrder(103);
        order3.AddProduct(phone);
        order3.AddProduct(laptop);

        // Show order histories
        alice.ShowOrderHistory();
        bob.ShowOrderHistory();
    }
}
