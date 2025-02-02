using System;

class NumberChecker
{
    // Method to find the count of digits in the number
    public static int CountDigits(int number)
    {
        return number.ToString().Length;
    }

    // Method to store the digits of the number in a digits array
    public static int[] StoreDigits(int number)
    {
        string numString = number.ToString();
        int[] digits = new int[numString.Length];
        for (int i = 0; i < numString.Length; i++)
        {
            digits[i] = int.Parse(numString[i].ToString());
        }
        return digits;
    }

    // Method to check if the number is a Duck number
    public static bool IsDuckNumber(int number)
    {
        int[] digits = StoreDigits(number);
        foreach (int digit in digits)
        {
            if (digit != 0)
            {
                return true; // Duck number has at least one non-zero digit
            }
        }
        return false;
    }

    // Method to check if the number is an Armstrong number
    public static bool IsArmstrongNumber(int number)
    {
        int[] digits = StoreDigits(number);
        int sum = 0;
        int numDigits = digits.Length;
        
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, numDigits);
        }

        return sum == number;
    }

    // Method to find the largest and second largest elements in the digits array
    public static int[] FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue, secondLargest = Int32.MinValue;
        foreach (int digit in digits)
        {
            if (digit > largest)
            {
                secondLargest = largest;
                largest = digit;
            }
            else if (digit > secondLargest && digit != largest)
            {
                secondLargest = digit;
            }
        }
        return new int[] { largest, secondLargest };
    }

    // Method to find the smallest and second smallest elements in the digits array
    public static int[] FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue, secondSmallest = Int32.MaxValue;
        foreach (int digit in digits)
        {
            if (digit < smallest)
            {
                secondSmallest = smallest;
                smallest = digit;
            }
            else if (digit < secondSmallest && digit != smallest)
            {
                secondSmallest = digit;
            }
        }
        return new int[] { smallest, secondSmallest };
    }

    // Main method to test the utility methods
    public static void Main()
    {
        int number = 153; // Example number

        // Find the count of digits
        int digitCount = CountDigits(number);
        Console.WriteLine("Count of digits: " + digitCount);

        // Store the digits in an array
        int[] digits = StoreDigits(number);
        Console.WriteLine("Digits: " + string.Join(", ", digits));

        // Check if the number is a Duck number
        bool isDuck = IsDuckNumber(number);
        Console.WriteLine("Is Duck Number: " + isDuck);

        // Check if the number is an Armstrong number
        bool isArmstrong = IsArmstrongNumber(number);
        Console.WriteLine("Is Armstrong Number: " + isArmstrong);

        // Find the largest and second largest digits
        int[] largestAndSecondLargest = FindLargestAndSecondLargest(digits);
        Console.WriteLine("Largest: " + largestAndSecondLargest[0] + ", Second Largest: " + largestAndSecondLargest[1]);

        // Find the smallest and second smallest digits
        int[] smallestAndSecondSmallest = FindSmallestAndSecondSmallest(digits);
        Console.WriteLine("Smallest: " + smallestAndSecondSmallest[0] + ", Second Smallest: " + smallestAndSecondSmallest[1]);
    }
}
