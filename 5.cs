using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema; 

class Program
{
    static void Main()
    {
        // JSON Schema Definition
        string schemaJson = @"{
            ""type"": ""object"",
            ""properties"": {
                ""name"": { ""type"": ""string"" },
                ""email"": { ""type"": ""string"", ""format"": ""email"" },
                ""age"": { ""type"": ""integer"", ""minimum"": 18 }
            },
            ""required"": [""name"", ""email"", ""age""]
        }";

        // Sample JSON (Valid Case)
        string validJson = @"{
            ""name"": ""Tanya Sharma"",
            ""email"": ""tanya@example.com"",
            ""age"": 22
        }";

        // Sample JSON (Invalid Case)
        string invalidJson = @"{
            ""name"": ""Tanya"",
            ""email"": ""invalid-email"",
            ""age"": 16
        }";

        // Parse schema
        JSchema schema = JSchema.Parse(schemaJson);

        // Validate JSON objects
        ValidateJson(validJson, schema);
        ValidateJson(invalidJson, schema);
    }

    static void ValidateJson(string jsonData, JSchema schema)
    {
        JObject jsonObject = JObject.Parse(jsonData);

        IList<string> errorMessages;
        bool isValid = jsonObject.IsValid(schema, out errorMessages);

        Console.WriteLine("\nValidating JSON:");
        Console.WriteLine(jsonObject.ToString(Formatting.Indented));

        if (isValid)
        {
            Console.WriteLine(" JSON is valid!");
        }
        else
        {
            Console.WriteLine(" JSON is invalid! Errors:");
            foreach (var error in errorMessages)
            {
                Console.WriteLine($"  - {error}");
            }
        }
    }
}
