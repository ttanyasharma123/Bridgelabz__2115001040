using System;
using System.Collections.Generic;
using System.Linq;

// Step 1: Define Abstract JobRole Class
abstract class JobRole
{
    public string RoleName { get; set; }
    public List<string> RequiredSkills { get; set; }
    public int MinimumExperience { get; set; }

    public JobRole(string roleName, List<string> requiredSkills, int minExperience)
    {
        RoleName = roleName;
        RequiredSkills = requiredSkills;
        MinimumExperience = minExperience;
    }

    public abstract void DisplayRequirements();
}

// Step 2: Implement Specific Job Roles
class SoftwareEngineer : JobRole
{
    public SoftwareEngineer() : base("Software Engineer",
        new List<string> { "C#", "Algorithms", "OOP", "Problem Solving" }, 2) { }

    public override void DisplayRequirements()
    {
        Console.WriteLine($"Role: {RoleName} | Required Skills: {string.Join(", ", RequiredSkills)} | Min Exp: {MinimumExperience} years");
    }
}

class DataScientist : JobRole
{
    public DataScientist() : base("Data Scientist",
        new List<string> { "Python", "Machine Learning", "Statistics", "Data Analysis" }, 3) { }

    public override void DisplayRequirements()
    {
        Console.WriteLine($"Role: {RoleName} | Required Skills: {string.Join(", ", RequiredSkills)} | Min Exp: {MinimumExperience} years");
    }
}

// Step 3: Create a Generic Resume Class
class Resume<T> where T : JobRole
{
    public string CandidateName { get; set; }
    public int Experience { get; set; }
    public List<string> Skills { get; set; }
    public T JobAppliedFor { get; set; }

    public Resume(string name, int experience, List<string> skills, T jobRole)
    {
        CandidateName = name;
        Experience = experience;
        Skills = skills;
        JobAppliedFor = jobRole;
    }

    public void DisplayResume()
    {
        Console.WriteLine($"\nCandidate: {CandidateName} | Applying for: {JobAppliedFor.RoleName}");
        Console.WriteLine($"Experience: {Experience} years | Skills: {string.Join(", ", Skills)}");
    }

    public bool MatchesRequirements()
    {
        return Experience >= JobAppliedFor.MinimumExperience &&
               JobAppliedFor.RequiredSkills.All(skill => Skills.Contains(skill));
    }
}

// Step 4: Implement Resume Screening Class
class ResumeScreening
{
    private List<object> resumes = new List<object>();

    public void AddResume<T>(Resume<T> resume) where T : JobRole
    {
        resumes.Add(resume);
        Console.WriteLine($"{resume.CandidateName}'s resume added for {resume.JobAppliedFor.RoleName}.");
    }

    public void ProcessResumes()
    {
        Console.WriteLine("\nScreening Resumes...");
        foreach (var resume in resumes)
        {
            if (resume is Resume<SoftwareEngineer> softwareResume)
            {
                softwareResume.DisplayResume();
                Console.WriteLine(softwareResume.MatchesRequirements()
                    ? "Resume Passed Screening!"
                    : "Resume Rejected.");
            }
            else if (resume is Resume<DataScientist> dataScienceResume)
            {
                dataScienceResume.DisplayResume();
                Console.WriteLine(dataScienceResume.MatchesRequirements()
                    ? "Resume Passed Screening!"
                    : "Resume Rejected.");
            }
        }
    }
}

// Step 5: Test the Implementation
class Program
{
    static void Main()
    {
        // Define Job Roles
        SoftwareEngineer softwareRole = new SoftwareEngineer();
        DataScientist dataRole = new DataScientist();

        // Create Resumes
        Resume<SoftwareEngineer> resume1 = new Resume<SoftwareEngineer>("Alice", 3, new List<string> { "C#", "Algorithms", "OOP" }, softwareRole);
        Resume<SoftwareEngineer> resume2 = new Resume<SoftwareEngineer>("Bob", 1, new List<string> { "Java", "Problem Solving" }, softwareRole);
        Resume<DataScientist> resume3 = new Resume<DataScientist>("Charlie", 4, new List<string> { "Python", "Machine Learning", "Statistics", "Data Analysis" }, dataRole);
        Resume<DataScientist> resume4 = new Resume<DataScientist>("David", 2, new List<string> { "Python", "Excel" }, dataRole);

        // Create Screening System
        ResumeScreening screeningSystem = new ResumeScreening();
        screeningSystem.AddResume(resume1);
        screeningSystem.AddResume(resume2);
        screeningSystem.AddResume(resume3);
        screeningSystem.AddResume(resume4);

        // Process Resumes
        screeningSystem.ProcessResumes();
    }
}
