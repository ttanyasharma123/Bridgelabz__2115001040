using System;

class Book
{
    // Static variable shared across all books
    private static string LibraryName = "GLA Libraray";

    // Readonly property for ISBN (can only be set in constructor)
    public string ISBN { get; private set; }

    // Public properties for Title and Author
    public string Title { get; private set; }
    public string Author { get; private set; }

    // Constructor using 'this' to resolve ambiguity
    public Book(string title, string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    // Static method to display the library name
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library: " + LibraryName);
    }

    // Method to display book details
    public void DisplayBookDetails()
    {
        // Using 'is' operator to check instance type
        if (this is Book)
        {
            Console.WriteLine("Library: " + LibraryName);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine();
        }
    }

    static void Main()
    {
        // Creating books
        Book book1 = new Book("The Power of Your Subconscious Mind", "Dr. Joseph Murphy.", "97807432");
        Book book2 = new Book("To Kill a Mockingbird", " Harper Lee", "97804518");

        // Displaying library name
        Book.DisplayLibraryName();

        // Displaying book details
        book1.DisplayBookDetails();
        book2.DisplayBookDetails();
    }
}
