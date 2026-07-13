using System;
using System.Text;
using SimpleEncryption.Libs;

namespace SimpleEncryption;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter message: ");
        string msg = Console.ReadLine() ?? "";

        if (msg == "")
        {
            Console.WriteLine("Message mustbe not empty");
            return;
        }

        Console.WriteLine("Enter key: ");
        if (int.TryParse(Console.ReadLine(), out int key))
        {
            string output = EncryptLibs.Encrypt(msg, key);
            Console.WriteLine($"Output of Encryption is: {output}");

        }
        else
        {
            Console.WriteLine("Key mustbe valid number (integer)");
        }

        // string output = EncryptLibs.Encrypt("konsole kde plasma", 3);

    }
}