using System;

class TicketNode
{
    public int TicketID;
    public string CustomerName;
    public string MovieName;
    public string SeatNumber;
    public DateTime BookingTime;
    public TicketNode Next;

    public TicketNode(int ticketID, string customerName, string movieName, string seatNumber)
    {
        TicketID = ticketID;
        CustomerName = customerName;
        MovieName = movieName;
        SeatNumber = seatNumber;
        BookingTime = DateTime.Now;
        Next = null;
    }
}

class TicketReservationSystem
{
    private TicketNode head;

    public void AddTicket(int ticketID, string customerName, string movieName, string seatNumber)
    {
        TicketNode newTicket = new TicketNode(ticketID, customerName, movieName, seatNumber);
        if (head == null)
        {
            head = newTicket;
            head.Next = head;
        }
        else
        {
            TicketNode temp = head;
            while (temp.Next != head)
            {
                temp = temp.Next;
            }
            temp.Next = newTicket;
            newTicket.Next = head;
        }
    }

    public void RemoveTicket(int ticketID)
    {
        if (head == null) return;
        
        TicketNode temp = head, prev = null;
        do
        {
            if (temp.TicketID == ticketID)
            {
                if (prev != null)
                {
                    prev.Next = temp.Next;
                    if (temp == head)
                        head = temp.Next;
                }
                else
                {
                    TicketNode last = head;
                    while (last.Next != head)
                        last = last.Next;
                    
                    if (head.Next == head)
                        head = null;
                    else
                    {
                        head = head.Next;
                        last.Next = head;
                    }
                }
                return;
            }
            prev = temp;
            temp = temp.Next;
        } while (temp != head);
    }

    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }
        
        TicketNode temp = head;
        do
        {
            Console.WriteLine($"Ticket ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}, Time: {temp.BookingTime}");
            temp = temp.Next;
        } while (temp != head);
    }

    public void SearchTicket(string query)
    {
        if (head == null) return;
        
        TicketNode temp = head;
        bool found = false;
        do
        {
            if (temp.CustomerName.Contains(query, StringComparison.OrdinalIgnoreCase) || temp.MovieName.Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Ticket Found - ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}");
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);
        
        if (!found) Console.WriteLine("No matching ticket found.");
    }

    public int CountTickets()
    {
        if (head == null) return 0;
        
        int count = 0;
        TicketNode temp = head;
        do
        {
            count++;
            temp = temp.Next;
        } while (temp != head);
        
        return count;
    }
}

class Program
{
    static void Main()
    {
        TicketReservationSystem system = new TicketReservationSystem();
        
        system.AddTicket(1, "Alice", "Inception", "A1");
        system.AddTicket(2, "Bob", "Interstellar", "B2");
        system.AddTicket(3, "Charlie", "Inception", "C3");
        
        Console.WriteLine("Current Tickets:");
        system.DisplayTickets();
        
        Console.WriteLine("\nSearching for 'Inception':");
        system.SearchTicket("Inception");
        
        Console.WriteLine("\nTotal Tickets Booked: " + system.CountTickets());
        
        system.RemoveTicket(2);
        Console.WriteLine("\nAfter Removing Ticket 2:");
        system.DisplayTickets();
    }
}
