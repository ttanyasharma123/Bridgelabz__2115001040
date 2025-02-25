using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


class CSVEncryptDecrypt
{
    static readonly string encryptionKey = "MySecretKey12345"; // Key must be 16, 24, or 32 bytes


    static void Main()
    {
        string csvFilePath = "employees_encrypted.csv";


        // Sample employee data
        List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 101, Name = "Alice", Email = "alice@example.com", Salary = "50000" },
            new Employee { ID = 102, Name = "Bob", Email = "bob@example.com", Salary = "60000" },
            new Employee { ID = 103, Name = "Charlie", Email = "charlie@example.com", Salary = "70000" }
        };


        // Encrypt and write to CSV
        WriteEncryptedCSV(csvFilePath, employees);


        // Read and decrypt CSV
        ReadDecryptedCSV(csvFilePath);
    }


    static void WriteEncryptedCSV(string filePath, List<Employee> employees)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write header
            writer.WriteLine("ID,Name,Email,Salary");


            // Write encrypted data
            foreach (var emp in employees)
            {
                string encryptedEmail = Encrypt(emp.Email);
                string encryptedSalary = Encrypt(emp.Salary);


                writer.WriteLine($"{emp.ID},{emp.Name},{encryptedEmail},{encryptedSalary}");
            }
        }


        Console.WriteLine($"Encrypted CSV file generated: {filePath}");
    }


    static void ReadDecryptedCSV(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: CSV file not found!");
            return;
        }


        Console.WriteLine("\nDecrypted Data from CSV:");
        using (StreamReader reader = new StreamReader(filePath))
        {
            string header = reader.ReadLine(); // Read header
            Console.WriteLine(header);


            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');


                string decryptedEmail = Decrypt(fields[2]);
                string decryptedSalary = Decrypt(fields[3]);


                Console.WriteLine($"{fields[0]},{fields[1]},{decryptedEmail},{decryptedSalary}");
            }
        }
    }


    static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            aes.IV = new byte[16]; // Initialization Vector (IV) should be the same for encryption and decryption


            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }


    static string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            aes.IV = new byte[16]; // Same IV as used in encryption


            using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}


// Employee Class
class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Salary { get; set; }
}




