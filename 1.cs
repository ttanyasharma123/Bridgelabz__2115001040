using System;

class StudentNode
{
    public int RollNumber;
    public string Name;
    public int Age;
    public string Grade;
    public StudentNode Next;

    public StudentNode(int rollNumber, string name, int age, string grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
        Next = null;
    }
}

class StudentRecordSystem
{
    private StudentNode head;

    public void AddStudent(int rollNumber, string name, int age, string grade, int position = -1)
    {
        StudentNode newStudent = new StudentNode(rollNumber, name, age, grade);
        if (head == null || position == 0)
        {
            newStudent.Next = head;
            head = newStudent;
            return;
        }

        if (position == -1)
        {
            StudentNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newStudent;
        }
        else
        {
            StudentNode temp = head;
            for (int i = 1; temp != null && i < position; i++)
            {
                temp = temp.Next;
            }
            if (temp != null)
            {
                newStudent.Next = temp.Next;
                temp.Next = newStudent;
            }
            else
            {
                Console.WriteLine("Invalid position");
            }
        }
    }

    public void DeleteStudent(int rollNumber)
    {
        if (head == null) return;

        if (head.RollNumber == rollNumber)
        {
            head = head.Next;
            return;
        }

        StudentNode temp = head, prev = null;
        while (temp != null && temp.RollNumber != rollNumber)
        {
            prev = temp;
            temp = temp.Next;
        }

        if (temp == null) return;
        prev.Next = temp.Next;
    }

    public void SearchStudent(int rollNumber)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.RollNumber == rollNumber)
            {
                Console.WriteLine($"Found: Roll: {temp.RollNumber}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student not found.");
    }

    public void UpdateGrade(int rollNumber, string newGrade)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.RollNumber == rollNumber)
            {
                temp.Grade = newGrade;
                Console.WriteLine("Grade updated.");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student not found.");
    }

    public void DisplayStudents()
    {
        if (head == null)
        {
            Console.WriteLine("No student records found.");
            return;
        }
        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"Roll: {temp.RollNumber}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentRecordSystem system = new StudentRecordSystem();
        
        system.AddStudent(1, "Alice", 20, "A");
        system.AddStudent(2, "Bob", 22, "B");
        system.AddStudent(3, "Charlie", 21, "C", 1);
        
        Console.WriteLine("Student Records:");
        system.DisplayStudents();
        
        Console.WriteLine("\nSearching for Roll Number 2:");
        system.SearchStudent(2);
        
        Console.WriteLine("\nUpdating Grade of Roll Number 3 to 'A+':");
        system.UpdateGrade(3, "A+");
        system.DisplayStudents();
        
        Console.WriteLine("\nDeleting Roll Number 2:");
        system.DeleteStudent(2);
        system.DisplayStudents();
    }
}