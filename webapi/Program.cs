using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

class EncryptionService
{
    static string key = "mySecretKey123"; // Lösenordet för att kryptera och dekryptera med Base64

    static string Encrypt(string plainText)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    static string Decrypt(string encryptedText)
    {
        try
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(encryptedBytes);
        }
        catch (FormatException)
        {
            return null; // Återge null om dekrypteringen misslyckas
        }
    }

    static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .Configure(app =>
            {
                // Endpoint för att kryptera och dekryptera texten
                app.Run(async (context) =>
                {
                    PathString path = context.Request.Path;
                    if (path.StartsWithSegments("/encrypt"))
                    {
                        string textToEncrypt = context.Request.Query["text"];
                        string encryptedText = Encrypt(textToEncrypt);

                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync(encryptedText);
                    }
                    else if (path.StartsWithSegments("/decrypt"))
                    {
                        string textToDecrypt = context.Request.Query["text"];
                        string decryptedText = Decrypt(textToDecrypt);

                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync(decryptedText);
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("Welcome to the Text Encrypter/Decrypter API!\n\n"
                                                          + "Usage:\n"
                                                          + "To encrypt: /encrypt?text=[your text]\n"
                                                          + "To decrypt: /decrypt?text=[your text]\n");
                    }
                });
            })
            .Build();

        host.Run();
    }
}
