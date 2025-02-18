using System;
using System.Collections.Generic;

// Step 1: Create the base class
abstract class WarehouseItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public WarehouseItem(int id, string name, double price)
    {
        ID = id;
        Name = name;
        Price = price;
    }

    public abstract void Display();
}

// Step 2: Create derived classes
class Electronics : WarehouseItem
{
    public int WarrantyPeriod { get; set; }

    public Electronics(int id, string name, double price, int warranty)
        : base(id, name, price)
    {
        WarrantyPeriod = warranty;
    }

    public override void Display()
    {
        Console.WriteLine($"[Electronics] ID: {ID}, Name: {Name}, Price: {Price}, Warranty: {WarrantyPeriod} months");
    }
}

class Groceries : WarehouseItem
{
    public DateTime ExpiryDate { get; set; }

    public Groceries(int id, string name, double price, DateTime expiry)
        : base(id, name, price)
    {
        ExpiryDate = expiry;
    }

    public override void Display()
    {
        Console.WriteLine($"[Groceries] ID: {ID}, Name: {Name}, Price: {Price}, Expiry: {ExpiryDate.ToShortDateString()}");
    }
}

class Furniture : WarehouseItem
{
    public string Material { get; set; }

    public Furniture(int id, string name, double price, string material)
        : base(id, name, price)
    {
        Material = material;
    }

    public override void Display()
    {
        Console.WriteLine($"[Furniture] ID: {ID}, Name: {Name}, Price: {Price}, Material: {Material}");
    }
}

// Step 3: Create Generic Storage Class
class Storage<T> where T : WarehouseItem
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
        Console.WriteLine($"{item.Name} added to storage.");
    }

    public void RemoveItem(int id)
    {
        var item = items.Find(i => i.ID == id);
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine($"{item.Name} removed from storage.");
        }
        else
        {
            Console.WriteLine("Item not found!");
        }
    }

    public void DisplayItems()
    {
        Console.WriteLine("\nStored Items:");
        foreach (var item in items)
        {
            item.Display();
        }
    }
}

// Step 4: Test the Implementation
class Program
{
    static void Main()
    {
        // Creating storage for different item types
        Storage<Electronics> electronicsStorage = new Storage<Electronics>();
        Storage<Groceries> groceriesStorage = new Storage<Groceries>();
        Storage<Furniture> furnitureStorage = new Storage<Furniture>();

        // Adding items
        electronicsStorage.AddItem(new Electronics(1, "Laptop", 75000, 24));
        groceriesStorage.AddItem(new Groceries(2, "Milk", 50, DateTime.Now.AddDays(10)));
        furnitureStorage.AddItem(new Furniture(3, "Chair", 2000, "Wood"));

        // Display stored items
        electronicsStorage.DisplayItems();
        groceriesStorage.DisplayItems();
        furnitureStorage.DisplayItems();
    }
}
