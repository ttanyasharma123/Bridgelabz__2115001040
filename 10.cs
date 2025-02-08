using System;

// Superclass: Person
class Person
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, ID: {Id}");
    }
}

// Interface: Worker (Simulating multiple inheritance)
interface Worker
{
    void PerformDuties();
}

// Subclass: Chef (Inherits from Person and Implements Worker)
class Chef : Person, Worker
{
    public string Specialty { get; set; }

    public Chef(string name, int id, string specialty) : base(name, id)
    {
        Specialty = specialty;
    }

    public void PerformDuties()
    {
        Console.WriteLine($"{Name} (Chef) is cooking delicious {Specialty} dishes.");
    }
}

// Subclass: Waiter (Inherits from Person and Implements Worker)
class Waiter : Person, Worker
{
    public int TablesAssigned { get; set; }

    public Waiter(string name, int id, int tablesAssigned) : base(name, id)
    {
        TablesAssigned = tablesAssigned;
    }

    public void PerformDuties()
    {
        Console.WriteLine($"{Name} (Waiter) is serving customers at {TablesAssigned} tables.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Chef chef = new Chef("Gordon", 101, "Italian");
        Waiter waiter = new Waiter("James", 102, 5);

        chef.DisplayInfo();
        chef.PerformDuties();

        waiter.DisplayInfo();
        waiter.PerformDuties();
    }
}
