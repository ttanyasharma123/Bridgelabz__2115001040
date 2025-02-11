using System;
using System.Collections.Generic;

class UserNode
{
    public int UserID;
    public string Name;
    public int Age;
    public List<int> FriendIDs;
    public UserNode Next;

    public UserNode(int userID, string name, int age)
    {
        UserID = userID;
        Name = name;
        Age = age;
        FriendIDs = new List<int>();
        Next = null;
    }
}

class SocialMediaNetwork
{
    private UserNode head;

    public void AddUser(int userID, string name, int age)
    {
        UserNode newUser = new UserNode(userID, name, age);
        if (head == null)
        {
            head = newUser;
        }
        else
        {
            UserNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newUser;
        }
    }

    public void AddFriendConnection(int userID1, int userID2)
    {
        UserNode user1 = FindUserByID(userID1);
        UserNode user2 = FindUserByID(userID2);
        if (user1 != null && user2 != null && userID1 != userID2)
        {
            if (!user1.FriendIDs.Contains(userID2)) user1.FriendIDs.Add(userID2);
            if (!user2.FriendIDs.Contains(userID1)) user2.FriendIDs.Add(userID1);
        }
    }

    public void RemoveFriendConnection(int userID1, int userID2)
    {
        UserNode user1 = FindUserByID(userID1);
        UserNode user2 = FindUserByID(userID2);
        if (user1 != null && user2 != null)
        {
            user1.FriendIDs.Remove(userID2);
            user2.FriendIDs.Remove(userID1);
        }
    }

    public void FindMutualFriends(int userID1, int userID2)
    {
        UserNode user1 = FindUserByID(userID1);
        UserNode user2 = FindUserByID(userID2);
        if (user1 != null && user2 != null)
        {
            List<int> mutualFriends = user1.FriendIDs.FindAll(id => user2.FriendIDs.Contains(id));
            Console.WriteLine("Mutual Friends:");
            foreach (int id in mutualFriends)
            {
                Console.WriteLine(id);
            }
        }
    }

    public void DisplayFriends(int userID)
    {
        UserNode user = FindUserByID(userID);
        if (user != null)
        {
            Console.WriteLine($"Friends of {user.Name}:");
            foreach (int id in user.FriendIDs)
            {
                Console.Write(id + " ");
            }
            Console.WriteLine();
        }
    }

    public UserNode FindUserByID(int userID)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.UserID == userID) return temp;
            temp = temp.Next;
        }
        return null;
    }

    public void SearchUser(string name)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"User Found: {temp.Name}, Age: {temp.Age}, UserID: {temp.UserID}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("User not found.");
    }

    public void CountFriends()
    {
        UserNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Name} has {temp.FriendIDs.Count} friends.");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        SocialMediaNetwork network = new SocialMediaNetwork();
        network.AddUser(1, "Avni", 25);
        network.AddUser(2, "Bobo", 30);
        network.AddUser(3, "Chahat", 22);

        network.AddFriendConnection(1, 2);
        network.AddFriendConnection(1, 3);
        network.AddFriendConnection(2, 3);
        
        Console.WriteLine("Friend List:");
        network.DisplayFriends(1);
        network.DisplayFriends(2);
        network.DisplayFriends(3);
        
        Console.WriteLine("\nMutual Friends between Avni and Bobo:");
        network.FindMutualFriends(1, 2);
        
        Console.WriteLine("\nFriend Counts:");
        network.CountFriends();
    }
}
