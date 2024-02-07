using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/encrypt", (HttpContext context) =>
{
    string textToEncrypt = context.Request.Query["text"];
    string encryptedText = Encrypt(textToEncrypt);
    return Results.Text(encryptedText);
});

app.MapGet("/decrypt", (HttpContext context) =>
{
    string textToDecrypt = context.Request.Query["text"];
    string? decryptedText = Decrypt(textToDecrypt);

    if (decryptedText != null)
    {
        return Results.Text(decryptedText);
    }
    else
    {
        return Results.Text("Decryption failed.");
    }
});

app.MapGet("/", () =>
{
    return Results.Text("Welcome to the Text Encrypter/Decrypter API!\n\n"
                        + "Usage:\n"
                        + "To encrypt: /encrypt?text=[your text]\n"
                        + "To decrypt: /decrypt?text=[your text]\n");
});

app.Run();

static string Encrypt(string plainText)
{
    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    return Convert.ToBase64String(plainTextBytes);
}

static string? Decrypt(string encryptedText)
{
    try
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        return Encoding.UTF8.GetString(encryptedBytes);
    }
    catch (FormatException)
    {
        return null; // Return null if decryption fails
    }
}