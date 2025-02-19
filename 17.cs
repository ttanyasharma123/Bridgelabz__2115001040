using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
    private Dictionary<string, int> voteCounts = new Dictionary<string, int>();  // Stores votes
    private SortedDictionary<string, int> sortedResults = new SortedDictionary<string, int>();  // Sorted results
    private LinkedList<KeyValuePair<string, int>> voteOrder = new LinkedList<KeyValuePair<string, int>>(); // Maintains vote order

    // Method to cast a vote
    public void CastVote(string candidate)
    {
        if (voteCounts.ContainsKey(candidate))
        {
            voteCounts[candidate]++;
        }
        else
        {
            voteCounts[candidate] = 1;
        }

        // Maintain order using LinkedList (acts like LinkedHashMap)
        voteOrder.AddLast(new KeyValuePair<string, int>(candidate, voteCounts[candidate]));
    }

    // Method to display vote counts
    public void DisplayVoteCounts()
    {
        Console.WriteLine("\nVote Counts:");
        foreach (var entry in voteCounts)
        {
            Console.WriteLine(string.Format("{0}: {1} votes", entry.Key, entry.Value));
        }
    }

    // Method to display sorted results
    public void DisplaySortedResults()
    {
        sortedResults = new SortedDictionary<string, int>(voteCounts);
        Console.WriteLine("\nSorted Results:");
        foreach (var entry in sortedResults)
        {
            Console.WriteLine(string.Format("{0}: {1} votes", entry.Key, entry.Value));
        }
    }

    // Method to display votes in order
    public void DisplayVotesInOrder()
    {
        Console.WriteLine("\nVotes in Order:");
        foreach (var entry in voteOrder)
        {
            Console.WriteLine(string.Format("{0} -> {1} votes", entry.Key, entry.Value));
        }
    }
}

class Program
{
    static void Main()
    {
        VotingSystem votingSystem = new VotingSystem();

        // Sample votes
        votingSystem.CastVote("Alice");
        votingSystem.CastVote("Bob");
        votingSystem.CastVote("Alice");
        votingSystem.CastVote("Charlie");
        votingSystem.CastVote("Bob");
        votingSystem.CastVote("Alice");

        // Display results
        votingSystem.DisplayVoteCounts();
        votingSystem.DisplaySortedResults();
        votingSystem.DisplayVotesInOrder();
    }
}
