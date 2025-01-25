using System;

class Program
{
    static void Main()
    {
        int number, maxDigit = 10, index = 0;
        int[] digits = new int[maxDigit];
        
        Console.WriteLine("Enter a number: ");
        number = int.Parse(Console.ReadLine());

        while (number != 0 && index < maxDigit)
        {
            digits[index] = number % 10;
            number /= 10;
            index++;
        }

        int largest = -1, secondLargest = -1;

        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] < largest)
            {
                secondLargest = digits[i];
            }
        }

        Console.WriteLine("Largest Digit: " + largest);
        Console.WriteLine("Second Largest Digit: " + secondLargest);
    }
}
