using System;

class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
    public Movie Next { get; set; }
    public Movie Prev { get; set; }

    public Movie(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
        Next = null;
        Prev = null;
    }
}

class MovieManagement
{
    private Movie head;
    private Movie tail;

    public MovieManagement()
    {
        head = null;
        tail = null;
    }

    public void AddMovie(string title, string director, int year, double rating, int position = -1)
    {
        Movie newMovie = new Movie(title, director, year, rating);
        if (head == null)
        {
            head = tail = newMovie;
        }
        else if (position == 0)
        {
            newMovie.Next = head;
            head.Prev = newMovie;
            head = newMovie;
        }
        else if (position == -1)
        {
            tail.Next = newMovie;
            newMovie.Prev = tail;
            tail = newMovie;
        }
        else
        {
            Movie temp = head;
            int index = 0;
            while (temp != null && index < position - 1)
            {
                temp = temp.Next;
                index++;
            }
            if (temp != null)
            {
                newMovie.Next = temp.Next;
                newMovie.Prev = temp;
                if (temp.Next != null)
                    temp.Next.Prev = newMovie;
                temp.Next = newMovie;
                if (newMovie.Next == null)
                    tail = newMovie;
            }
        }
    }

    public void RemoveMovie(string title)
    {
        Movie temp = head;
        while (temp != null && temp.Title != title)
            temp = temp.Next;

        if (temp == null)
            return;

        if (temp.Prev != null)
            temp.Prev.Next = temp.Next;
        else
            head = temp.Next;

        if (temp.Next != null)
            temp.Next.Prev = temp.Prev;
        else
            tail = temp.Prev;
    }

    public void SearchMovie(string director = "", double rating = -1)
    {
        Movie temp = head;
        while (temp != null)
        {
            if ((director != "" && temp.Director == director) || (rating != -1 && temp.Rating == rating))
                Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.Year}, Rating: {temp.Rating}");
            temp = temp.Next;
        }
    }

    public void UpdateRating(string title, double newRating)
    {
        Movie temp = head;
        while (temp != null)
        {
            if (temp.Title == title)
            {
                temp.Rating = newRating;
                return;
            }
            temp = temp.Next;
        }
    }

    public void DisplayMovies(bool reverse = false)
    {
        Movie temp = reverse ? tail : head;
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Title}, Director: {temp.Director}, Year: {temp.Year}, Rating: {temp.Rating}");
            temp = reverse ? temp.Prev : temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        MovieManagement mm = new MovieManagement();
        mm.AddMovie("Inception", "Karan Johar ", 2010, 8.8);
        mm.AddMovie("Interstellar", "Christopher Nolan", 2014, 8.6, 0);
        mm.AddMovie("Titanic", "James Cameron", 1997, 7.8, 1);

        Console.WriteLine("Movies List:");
        mm.DisplayMovies();

        Console.WriteLine("\nUpdating Titanic's rating...");
        mm.UpdateRating("Titanic", 8.2);
        mm.DisplayMovies();

        Console.WriteLine("\nSearching for movies by Christopher Nolan:");
        mm.SearchMovie(director: "Christopher Nolan");

        Console.WriteLine("\nRemoving Interstellar...");
        mm.RemoveMovie("Interstellar");
        mm.DisplayMovies();
    }
}
