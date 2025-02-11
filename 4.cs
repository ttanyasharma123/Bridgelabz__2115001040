using System;

class ItemNode
{
    public string ItemName;
    public int ItemID;
    public int Quantity;
    public double Price;
    public ItemNode Next;

    public ItemNode(string itemName, int itemID, int quantity, double price)
    {
        ItemName = itemName;
        ItemID = itemID;
        Quantity = quantity;
        Price = price;
        Next = null;
    }
}

class InventoryManagementSystem
{
    private ItemNode head = null;

    public void AddItem(string itemName, int itemID, int quantity, double price, int position = -1)
    {
        ItemNode newItem = new ItemNode(itemName, itemID, quantity, price);
        if (head == null || position == 0) // Add at the beginning
        {
            newItem.Next = head;
            head = newItem;
            return;
        }

        ItemNode temp = head;
        if (position == -1) // Add at the end
        {
            while (temp.Next != null) temp = temp.Next;
            temp.Next = newItem;
        }
        else // Add at a specific position
        {
            for (int i = 0; i < position - 1 && temp.Next != null; i++)
                temp = temp.Next;
            newItem.Next = temp.Next;
            temp.Next = newItem;
        }
    }

    public void RemoveItem(int itemID)
    {
        if (head == null) return;
        if (head.ItemID == itemID)
        {
            head = head.Next;
            return;
        }

        ItemNode temp = head, prev = null;
        while (temp != null && temp.ItemID != itemID)
        {
            prev = temp;
            temp = temp.Next;
        }

        if (temp == null) return;
        prev.Next = temp.Next;
    }

    public void UpdateQuantity(int itemID, int newQuantity)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemID == itemID)
            {
                temp.Quantity = newQuantity;
                return;
            }
            temp = temp.Next;
        }
    }

    public void SearchItem(int itemID)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemID == itemID)
            {
                Console.WriteLine($"Item ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found.");
    }

    public void SearchItem(string itemName)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Item ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found.");
    }

    public void CalculateTotalValue()
    {
        double totalValue = 0;
        ItemNode temp = head;
        while (temp != null)
        {
            totalValue += temp.Price * temp.Quantity;
            temp = temp.Next;
        }
        Console.WriteLine($"Total Inventory Value: {totalValue}");
    }

    public void SortInventory(bool sortByPrice = false, bool ascending = true)
    {
        if (head == null) return;

        bool swapped;
        do
        {
            swapped = false;
            ItemNode temp = head;
            while (temp.Next != null)
            {
                bool condition = sortByPrice
                    ? (ascending ? temp.Price > temp.Next.Price : temp.Price < temp.Next.Price)
                    : (ascending ? string.Compare(temp.ItemName, temp.Next.ItemName) > 0 : string.Compare(temp.ItemName, temp.Next.ItemName) < 0);

                if (condition)
                {
                    string tempName = temp.ItemName;
                    int tempID = temp.ItemID;
                    int tempQuantity = temp.Quantity;
                    double tempPrice = temp.Price;

                    temp.ItemName = temp.Next.ItemName;
                    temp.ItemID = temp.Next.ItemID;
                    temp.Quantity = temp.Next.Quantity;
                    temp.Price = temp.Next.Price;

                    temp.Next.ItemName = tempName;
                    temp.Next.ItemID = tempID;
                    temp.Next.Quantity = tempQuantity;
                    temp.Next.Price = tempPrice;

                    swapped = true;
                }
                temp = temp.Next;
            }
        } while (swapped);
    }

    public void DisplayInventory()
    {
        ItemNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"Item ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price}");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        InventoryManagementSystem inventory = new InventoryManagementSystem();
        inventory.AddItem("Laptop", 101, 5, 700.50);
        inventory.AddItem("Mouse", 102, 10, 20.75);
        inventory.AddItem("Keyboard", 103, 8, 35.00, 0);

        Console.WriteLine("Inventory List:");
        inventory.DisplayInventory();

        Console.WriteLine("\nUpdating Quantity of Item ID 102:");
        inventory.UpdateQuantity(102, 15);
        inventory.DisplayInventory();

        Console.WriteLine("\nTotal Inventory Value:");
        inventory.CalculateTotalValue();

        Console.WriteLine("\nSorting Inventory by Price:");
        inventory.SortInventory(true);
        inventory.DisplayInventory();
    }
}
