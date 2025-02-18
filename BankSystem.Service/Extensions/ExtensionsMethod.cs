namespace BankSystem.Service.Extensions;

public static class ExtensionsMethod
{
    public static string ConvertFileToBase64(this byte[] fileBytes)
    {
        return Convert.ToBase64String(fileBytes);
    }

    // Extension method to determine the file type (MIME type)
    public static string GetFileType(this byte[] fileBytes)
    {
        // Determine file type based on the file signature (magic numbers)
        if (fileBytes.Length < 4)
            return "application/octet-stream"; // Default MIME type for unknown files

        // Check for PDF
        if (fileBytes[0] == 0x25 && fileBytes[1] == 0x50 && fileBytes[2] == 0x44 && fileBytes[3] == 0x46)
            return "application/pdf";

        // Check for JPG
        if (fileBytes[0] == 0xFF && fileBytes[1] == 0xD8 && fileBytes[2] == 0xFF)
            return "image/jpeg";

        // Check for PNG
        if (fileBytes[0] == 0x89 && fileBytes[1] == 0x50 && fileBytes[2] == 0x4E && fileBytes[3] == 0x47)
            return "image/png";

        // Default to binary stream if type is unknown
        return "application/octet-stream";
    }
}
