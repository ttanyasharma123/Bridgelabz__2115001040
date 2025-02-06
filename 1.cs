using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }

    public Book(string title)
    {
        Title = title;
    }
}

class Library
{
    public List<Book> Books = new List<Book>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void ShowBooks()
    {
        foreach (var book in Books)
        {
            Console.WriteLine(book.Title);
        }
    }
}

class Program
{
    static void Main()
    {
        Book book1 = new Book("The Great Gatsby");
        Book book2 = new Book("1984");

        Library library = new Library();
        library.AddBook(book1);
        library.AddBook(book2);

        library.ShowBooks();
    }
}
