using System;

class Patient
{
    // Static variable shared by all patients
    public static string HospitalName = "City General Hospital";

    // Static variable to keep track of the total number of patients
    private static int totalPatients = 0;

    // Readonly variable for Patient ID (Cannot be modified after assignment)
    public readonly int PatientID;

    // Instance variables
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Ailment { get; private set; }

    // Constructor using 'this' to initialize variables
    public Patient(int patientID, string name, int age, string ailment)
    {
        this.PatientID = patientID;
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;

        // Increment total patient count
        totalPatients++;
    }

    // Static method to get the total number of patients
    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients Admitted: " + totalPatients);
    }

    // Method to display patient details, using 'is' operator
    public void DisplayPatientDetails()
    {
        if (this is Patient)
        {
            Console.WriteLine("Patient ID: " + PatientID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Ailment: " + Ailment);
            Console.WriteLine("Hospital: " + HospitalName);
            Console.WriteLine("--------------------------");
        }
    }

    // Destructor to decrement patient count when an object is destroyed
    ~Patient()
    {
        totalPatients--;
    }
}

// Main class to test the Patient class
class Program
{
    static void Main()
    {
        // Creating Patient objects
        Patient patient1 = new Patient(101, "Akash", 30, "Fever");
        Patient patient2 = new Patient(102, "Deepak", 45, "Diabetes");

        // Displaying patient details
        patient1.DisplayPatientDetails();
        patient2.DisplayPatientDetails();

        // Display total patients
        Patient.GetTotalPatients();
    }
}
