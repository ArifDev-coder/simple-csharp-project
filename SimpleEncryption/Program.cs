using System;
using System.Text;
using SimpleEncryption.Libs;

namespace SimpleEncryption;

class Program
{
    public static void Main()
    {
        string output = EncryptLibs.Encrypt("konsole kde plasma", 3);

        Console.WriteLine(output);
    }
}