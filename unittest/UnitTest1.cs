using System;
using Xunit;

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
