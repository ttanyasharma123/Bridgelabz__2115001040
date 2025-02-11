using System;

class BookNode
{
    public string Title;
    public string Author;
    public string Genre;
    public int BookID;
    public bool IsAvailable;
    public BookNode Next;
    public BookNode Prev;

    public BookNode(string title, string author, string genre, int bookID, bool isAvailable)
    {
        Title = title;
        Author = author;
        Genre = genre;
        BookID = bookID;
        IsAvailable = isAvailable;
        Next = null;
        Prev = null;
    }
}

class LibraryManagementSystem
{
    private BookNode head = null;
    private BookNode tail = null;

    public void AddBook(string title, string author, string genre, int bookID, bool isAvailable, int position = -1)
    {
        BookNode newBook = new BookNode(title, author, genre, bookID, isAvailable);
        if (head == null || position == 0) // Add at the beginning
        {
            newBook.Next = head;
            if (head != null) head.Prev = newBook;
            head = newBook;
            if (tail == null) tail = head;
            return;
        }
        
        if (position == -1) // Add at the end
        {
            tail.Next = newBook;
            newBook.Prev = tail;
            tail = newBook;
        }
        else // Add at a specific position
        {
            BookNode temp = head;
            for (int i = 0; i < position - 1 && temp.Next != null; i++)
                temp = temp.Next;
            newBook.Next = temp.Next;
            if (temp.Next != null) temp.Next.Prev = newBook;
            temp.Next = newBook;
            newBook.Prev = temp;
        }
    }

    public void RemoveBook(int bookID)
    {
        if (head == null) return;
        if (head.BookID == bookID)
        {
            head = head.Next;
            if (head != null) head.Prev = null;
            else tail = null;
            return;
        }
        
        BookNode temp = head;
        while (temp != null && temp.BookID != bookID)
            temp = temp.Next;
        
        if (temp == null) return;
        if (temp.Next != null) temp.Next.Prev = temp.Prev;
        if (temp.Prev != null) temp.Prev.Next = temp.Next;
    }

    public void SearchBook(string query)
    {
        BookNode temp = head;
        while (temp != null)
        {
            if (temp.Title.Equals(query, StringComparison.OrdinalIgnoreCase) || temp.Author.Equals(query, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Book ID: {temp.BookID}, Title: {temp.Title}, Author: {temp.Author}, Genre: {temp.Genre}, Available: {temp.IsAvailable}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Book not found.");
    }

    public void UpdateAvailability(int bookID, bool status)
    {
        BookNode temp = head;
        while (temp != null)
        {
            if (temp.BookID == bookID)
            {
                temp.IsAvailable = status;
                return;
            }
            temp = temp.Next;
        }
    }

    public void DisplayBooks(bool reverse = false)
    {
        BookNode temp = reverse ? tail : head;
        while (temp != null)
        {
            Console.WriteLine($"Book ID: {temp.BookID}, Title: {temp.Title}, Author: {temp.Author}, Genre: {temp.Genre}, Available: {temp.IsAvailable}");
            temp = reverse ? temp.Prev : temp.Next;
        }
    }

    public int CountBooks()
    {
        int count = 0;
        BookNode temp = head;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }
}

class Program
{
    static void Main()
    {
        LibraryManagementSystem library = new LibraryManagementSystem();
        library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 101, true);
        library.AddBook("1984", "George Orwell", "Dystopian", 102, false);
        library.AddBook("To Kill a Mockingbird", "Harper Lee", "Classic", 103, true, 0);
        
        Console.WriteLine("Library Inventory:");
        library.DisplayBooks();
        
        Console.WriteLine("\nSearching for '1984':");
        library.SearchBook("1984");
        
        Console.WriteLine("\nUpdating Availability of Book ID 102:");
        library.UpdateAvailability(102, true);
        library.DisplayBooks();
        
        Console.WriteLine("\nTotal Books in Library: " + library.CountBooks());
    }
}
