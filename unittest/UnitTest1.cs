using System;
using Xunit;
public class EncryptionService
{
    public static string Encrypt(string text)
    {
        // Implementera din krypteringslogik här
        return text; // Placeholder
    }

    public static string Decrypt(string text)
    {
        // Implementera din dekrypteringslogik här
        return text; // Placeholder
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
