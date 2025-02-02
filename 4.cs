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

    // Method to reverse the digits array
    public static int[] ReverseDigits(int[] digits)
    {
        int[] reversed = new int[digits.Length];
        for (int i = 0; i < digits.Length; i++)
        {
            reversed[i] = digits[digits.Length - 1 - i];
        }
        return reversed;
    }

    // Method to compare two arrays and check if they are equal
    public static bool CompareArrays(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length) return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i]) return false;
        }
        return true;
    }

    // Method to check if a number is a palindrome using the Digits array
    public static bool IsPalindrome(int number)
    {
        int[] digits = StoreDigits(number);
        int[] reversed = ReverseDigits(digits);

        return CompareArrays(digits, reversed);
    }

    // Method to check if a number is a duck number using the digits array
    public static bool IsDuckNumber(int number)
    {
        int[] digits = StoreDigits(number);

        // A duck number has a non-zero digit in it and starts with a non-zero digit
        foreach (int digit in digits)
        {
            if (digit == 0)
            {
                return true;
            }
        }
        return false;
    }

    // Main method to test the utility methods
    public static void Main()
    {
        int number = 1021; // Example number for testing

        // Count of digits
        int digitCount = CountDigits(number);
        Console.WriteLine("Count of digits: " + digitCount);

        // Store the digits in an array
        int[] digits = StoreDigits(number);
        Console.WriteLine("Digits: " + string.Join(", ", digits));

        // Reverse the digits array
        int[] reversedDigits = ReverseDigits(digits);
        Console.WriteLine("Reversed Digits: " + string.Join(", ", reversedDigits));

        // Check if the number is a palindrome
        bool isPalindrome = IsPalindrome(number);
        Console.WriteLine("Is Palindrome: " + isPalindrome);

        // Check if the number is a Duck number
        bool isDuckNumber = IsDuckNumber(number);
        Console.WriteLine("Is Duck Number: " + isDuckNumber);
    }
}
