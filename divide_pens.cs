using System;

class DividePens
{
    static void Main()
    {
        
        int totalPens = 14;
        int numberOfStudents = 3;
        
        
        int pensPerStudent = totalPens / numberOfStudents;
        int remainingPens = totalPens % numberOfStudents;

        
        Console.WriteLine("The Pen Per Student is " + pensPerStudent + " and the remaining pen not distributed is " + remainingPens);
    }
}

