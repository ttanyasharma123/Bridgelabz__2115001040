using System;
using System.IO;

class ImageByteArrayExample
{
    static void Main()
    {
        // Provide valid image paths
        string sourceImagePath = @"C:\Users\tanya\Desktop\source_image.jpg";  
        string destinationImagePath = @"C:\Users\tanya\Desktop\copied_image.jpg";

        try
        {
            // Convert image to byte array
            byte[] imageBytes = ConvertImageToByteArray(sourceImagePath);
            Console.WriteLine("Image successfully converted to byte array.");

            // Write byte array back to new image file
            SaveByteArrayAsImage(destinationImagePath, imageBytes);
            Console.WriteLine($"Image saved successfully at: {destinationImagePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine("File error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    // Convert image to byte array
    static byte[] ConvertImageToByteArray(string imagePath)
    {
        if (!File.Exists(imagePath))
        {
            throw new FileNotFoundException("Source image file not found.");
        }

        return File.ReadAllBytes(imagePath); // Read entire file into a byte array
    }

    // Convert byte array back to image
    static void SaveByteArrayAsImage(string outputPath, byte[] imageBytes)
    {
        File.WriteAllBytes(outputPath, imageBytes); // Write byte array to file
    }
}


