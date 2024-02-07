using System;
using Xunit;

public class EncryptionService
{
    public static string Encrypt(string text)
    {
        // Flytta varje tecken i texten framåt i alfabetet med 3 steg
        char[] result = text.ToCharArray();
        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                result[i] = (char)(result[i] + 3);
                if (!char.IsLetterOrDigit(result[i]) || (char.IsUpper(text[i]) && result[i] > 'Z') || (char.IsLower(text[i]) && result[i] > 'z'))
                {
                    result[i] = (char)(result[i] - 26);
                }
            }
        }
        return new string(result);
    }

    public static string Decrypt(string text)
    {
        // Flytta varje tecken i texten bakåt i alfabetet med 3 steg
        char[] result = text.ToCharArray();
        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                result[i] = (char)(result[i] - 3);
                if (!char.IsLetterOrDigit(result[i]) || (char.IsUpper(text[i]) && result[i] < 'A') || (char.IsLower(text[i]) && result[i] < 'a'))
                {
                    result[i] = (char)(result[i] + 26);
                }
            }
        }
        return new string(result);
    }
}

public class EncryptionServiceTests
{
    [Fact]
    public void Encrypt_Decrypt_Test()
    {
        // Arrange
        string originalText = "Hello, world!";
        
        // Act
        string encryptedText = EncryptionService.Encrypt(originalText);
        string decryptedText = EncryptionService.Decrypt(encryptedText);
        
        // Assert
        Assert.NotEqual(originalText, encryptedText); // Krypterad text bör vara annorlunda än originaltexten
        Assert.Equal(originalText, decryptedText);    // Dekrypterad text bör vara samma som originaltexten
    }
}
