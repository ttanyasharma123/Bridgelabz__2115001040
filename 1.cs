using System;

class Animal  // Parent Class
{
    public virtual void MakeSound() // Virtual method
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal  // Derived Class
{
    public override void MakeSound() // Overriding the method
    {
        Console.WriteLine("Dog barks: Woof! Woof!");
    }
}

class Program
{
    static void Main()
    {
        Animal myAnimal = new Animal();
        myAnimal.MakeSound();  // Calls Animal's method

        Dog myDog = new Dog();
        myDog.MakeSound();  // Calls Dog's overridden method

        Animal refDog = new Dog();
        refDog.MakeSound(); // Calls Dog's method due to polymorphism
    }
}

