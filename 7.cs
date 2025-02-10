using System;
using System.Collections.Generic;

// Abstract Class
abstract class Patient
{
    protected int patientId;
    protected string name;
    protected int age;

    public Patient(int id, string name, int age)
    {
        this.patientId = id;
        this.name = name;
        this.age = age;
    }

    public abstract double CalculateBill();

    public void GetPatientDetails()
    {
        Console.WriteLine($"Patient ID: {patientId}, Name: {name}, Age: {age}");
    }
}

// Interface
interface IMedicalRecord
{
    void AddRecord(string diagnosis, string history);
    void ViewRecords();
}

// InPatient Class
class InPatient : Patient, IMedicalRecord
{
    private double roomCharge;
    private int daysAdmitted;
    private string diagnosis;
    private string medicalHistory;

    public InPatient(int id, string name, int age, double roomCharge, int daysAdmitted)
        : base(id, name, age)
    {
        this.roomCharge = roomCharge;
        this.daysAdmitted = daysAdmitted;
    }

    public override double CalculateBill()
    {
        return roomCharge * daysAdmitted;
    }

    public void AddRecord(string diagnosis, string history)
    {
        this.diagnosis = diagnosis;
        this.medicalHistory = history;
    }

    public void ViewRecords()
    {
        Console.WriteLine($"Diagnosis: {diagnosis}, Medical History: {medicalHistory}");
    }
}

// OutPatient Class
class OutPatient : Patient, IMedicalRecord
{
    private double consultationFee;
    private string diagnosis;
    private string medicalHistory;

    public OutPatient(int id, string name, int age, double consultationFee)
        : base(id, name, age)
    {
        this.consultationFee = consultationFee;
    }

    public override double CalculateBill()
    {
        return consultationFee;
    }

    public void AddRecord(string diagnosis, string history)
    {
        this.diagnosis = diagnosis;
        this.medicalHistory = history;
    }

    public void ViewRecords()
    {
        Console.WriteLine($"Diagnosis: {diagnosis}, Medical History: {medicalHistory}");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Patient patient1 = new InPatient(101, "John Doe", 45, 2000, 5);
        patient1.GetPatientDetails();
        Console.WriteLine("Total Bill: " + patient1.CalculateBill());
        
        InPatient inPatient = (InPatient)patient1;
        inPatient.AddRecord("Pneumonia", "Diabetic patient");
        inPatient.ViewRecords();
        
        Patient patient2 = new OutPatient(102, "Jane Doe", 30, 500);
        patient2.GetPatientDetails();
        Console.WriteLine("Total Bill: " + patient2.CalculateBill());
        
        OutPatient outPatient = (OutPatient)patient2;
        outPatient.AddRecord("Flu", "No prior history");
        outPatient.ViewRecords();
    }
}
