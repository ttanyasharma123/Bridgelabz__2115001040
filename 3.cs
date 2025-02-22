using System;
using System.Text.RegularExpressions;

public class HexColorValidator
{
    // Validates a hex color code (e.g., #FFA500)
    public bool IsValidHexColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return false;

        // Regex Explanation:
        // ^#  → Must start with "#"
        // [0-9A-Fa-f]{6}  → Followed by exactly 6 hexadecimal characters
        string pattern = "^#[0-9A-Fa-f]{6}$";
        return Regex.IsMatch(color, pattern);
    }
}




.test case

using System;
using System.Text.RegularExpressions;

public class HexColorValidator
{
    // Validates a hex color code (e.g., #FFA500)
    public bool IsValidHexColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return false;

        // Regex Explanation:
        // ^#  → Must start with "#"
        // [0-9A-Fa-f]{6}  → Followed by exactly 6 hexadecimal characters
        string pattern = "^#[0-9A-Fa-f]{6}$";
        return Regex.IsMatch(color, pattern);
    }
}

