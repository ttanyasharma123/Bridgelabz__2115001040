using System;
using System.Collections.Generic;
using System.Linq;

class Policy : IComparable<Policy>
{
    public string PolicyNumber { get; set; }
    public string CoverageType { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Policy(string policyNumber, string coverageType, DateTime expiryDate)
    {
        PolicyNumber = policyNumber;
        CoverageType = coverageType;
        ExpiryDate = expiryDate;
    }

    public override bool Equals(object obj)
    {
        return obj is Policy && ((Policy)obj).PolicyNumber == this.PolicyNumber;
    }

    public override int GetHashCode()
    {
        return PolicyNumber.GetHashCode();
    }

    public int CompareTo(Policy other)
    {
        return ExpiryDate.CompareTo(other.ExpiryDate); // Sorting by Expiry Date
    }

    public override string ToString()
    {
        return string.Format("{0} - {1} - Expires on: {2:yyyy-MM-dd}", PolicyNumber, CoverageType, ExpiryDate);
    }
}

class InsurancePolicyManager
{
    private HashSet<Policy> uniquePolicies = new HashSet<Policy>();
    private SortedSet<Policy> sortedPolicies = new SortedSet<Policy>(); // Sorted by Expiry Date
    private Dictionary<string, List<Policy>> coverageTypeMap = new Dictionary<string, List<Policy>>();
    private Dictionary<string, int> policyCounts = new Dictionary<string, int>(); // To track duplicates

    public void AddPolicy(Policy policy)
    {
        if (uniquePolicies.Add(policy))
        {
            sortedPolicies.Add(policy);

            // Maintain coverage type mapping
            if (!coverageTypeMap.ContainsKey(policy.CoverageType))
                coverageTypeMap[policy.CoverageType] = new List<Policy>();
            coverageTypeMap[policy.CoverageType].Add(policy);

            // Track duplicate policies
            if (policyCounts.ContainsKey(policy.PolicyNumber))
                policyCounts[policy.PolicyNumber]++;
            else
                policyCounts[policy.PolicyNumber] = 1;
        }
    }

    public List<Policy> GetAllUniquePolicies()
    {
        return uniquePolicies.ToList();
    }

    public List<Policy> GetPoliciesExpiringSoon()
    {
        DateTime now = DateTime.Now;
        DateTime threshold = now.AddDays(30);
        return sortedPolicies.Where(p => p.ExpiryDate <= threshold).ToList();
    }

    public List<Policy> GetPoliciesByCoverageType(string coverageType)
    {
        return coverageTypeMap.ContainsKey(coverageType) ? coverageTypeMap[coverageType] : new List<Policy>();
    }

    public List<Policy> GetDuplicatePolicies()
    {
        return uniquePolicies.Where(p => policyCounts[p.PolicyNumber] > 1).ToList();
    }
}

class Program
{
    static void Main()
    {
        InsurancePolicyManager policyManager = new InsurancePolicyManager();

        // Sample Policies
        policyManager.AddPolicy(new Policy("P001", "Health", DateTime.Now.AddDays(25)));
        policyManager.AddPolicy(new Policy("P002", "Auto", DateTime.Now.AddDays(60)));
        policyManager.AddPolicy(new Policy("P003", "Home", DateTime.Now.AddDays(15)));
        policyManager.AddPolicy(new Policy("P004", "Health", DateTime.Now.AddDays(90)));
        policyManager.AddPolicy(new Policy("P001", "Health", DateTime.Now.AddDays(25))); // Duplicate

        // Display Results
        Console.WriteLine("\nAll Unique Policies:");
        foreach (var policy in policyManager.GetAllUniquePolicies())
            Console.WriteLine(policy);

        Console.WriteLine("\nPolicies Expiring Soon:");
        foreach (var policy in policyManager.GetPoliciesExpiringSoon())
            Console.WriteLine(policy);

        Console.WriteLine("\nHealth Policies:");
        foreach (var policy in policyManager.GetPoliciesByCoverageType("Health"))
            Console.WriteLine(policy);

        Console.WriteLine("\nDuplicate Policies:");
        foreach (var policy in policyManager.GetDuplicatePolicies())
            Console.WriteLine(policy);
    }
}
