using System;
using System.Collections.Generic;

class Hospital
{
    public string HospitalName { get; set; }
    public List<Doctor> Doctors { get; set; }
    public List<Patient> Patients { get; set; }

    public Hospital(string name)
    {
        HospitalName = name;
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
    }

    // Add a doctor to the hospital
    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
    }

    // Add a patient to the hospital
    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);
    }

    // Show hospital details
    public void ShowHospitalDetails()
    {
        Console.WriteLine("Hospital: " + HospitalName);

        Console.WriteLine("  Doctors:");
        foreach (var doctor in Doctors)
        {
            Console.WriteLine("    " + doctor.DoctorName);
        }

        Console.WriteLine("  Patients:");
        foreach (var patient in Patients)
        {
            Console.WriteLine("    " + patient.PatientName);
        }
    }
}

class Doctor
{
    public string DoctorName { get; set; }
    public List<Patient> Patients { get; set; }

    public Doctor(string name)
    {
        DoctorName = name;
        Patients = new List<Patient>(); // Many-to-Many relationship
    }

    // Doctor consults a patient
    public void Consult(Patient patient)
    {
        if (!Patients.Contains(patient))
        {
            Patients.Add(patient);
            patient.Doctors.Add(this);
        }
        Console.WriteLine("Dr. " + DoctorName + " is consulting " + patient.PatientName);
    }

    // Show patients consulted by the doctor
    public void ShowPatients()
    {
        Console.WriteLine("Dr. " + DoctorName + " has consulted:");
        foreach (var patient in Patients)
        {
            Console.WriteLine("  - " + patient.PatientName);
        }
    }
}

class Patient
{
    public string PatientName { get; set; }
    public List<Doctor> Doctors { get; set; }

    public Patient(string name)
    {
        PatientName = name;
        Doctors = new List<Doctor>(); // Many-to-Many relationship
    }

    // Show doctors who have consulted the patient
    public void ShowDoctors()
    {
        Console.WriteLine("Patient " + PatientName + " has been consulted by:");
        foreach (var doctor in Doctors)
        {
            Console.WriteLine("  - Dr. " + doctor.DoctorName);
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a hospital
        Hospital hospital = new Hospital("City Hospital");

        // Create doctors
        Doctor doctor1 = new Doctor("Ram");
        Doctor doctor2 = new Doctor("Garvut");

        // Create patients
        Patient patient1 = new Patient("Abhi");
        Patient patient2 = new Patient("Ravi");

        // Add doctors and patients to the hospital
        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);
        hospital.AddPatient(patient1);
        hospital.AddPatient(patient2);

        // Doctors consulting patients (Many-to-Many relationship)
        doctor1.Consult(patient1);
        doctor1.Consult(patient2);
        doctor2.Consult(patient1);

        Console.WriteLine(); // Space for readability

        // Show details of consultations
        doctor1.ShowPatients();
        doctor2.ShowPatients();

        Console.WriteLine(); // Space for readability

        patient1.ShowDoctors();
        patient2.ShowDoctors();
    }
}
