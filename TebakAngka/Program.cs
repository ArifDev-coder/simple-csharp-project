using System;

namespace TebakAngka;

class Program
{
    public static void Main()
    {
        bool isPlayAgain = true;
        while (isPlayAgain)
        {
            PlayGame();
            isPlayAgain = AskPlayAgain();
        }
    }

    public static void PlayGame()
    {
        int num = Random.Shared.Next(1, 101);

        Console.WriteLine($"\nTebak Angka 1-100");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                if (answer == num)
                {
                    Console.WriteLine($"Tebakanmu benar: {num}");
                    break;
                }
                else if (answer < num)
                {
                    Console.WriteLine("Angka terlalu kecil");
                }
                else if (answer > num)
                {
                    Console.WriteLine("Angka Terlalu Besar");
                }
            }
            else
            {
                Console.WriteLine("Tolong masukkan Angka dengan benar (1-100)");
            }
        }
    }

    public static bool AskPlayAgain()
    {
        Console.WriteLine("Main lagi? (y/n)");
        if (Console.ReadLine()?.ToLower() == "y") return true;
        else
        {
            Console.WriteLine("\nTerima Kasih sudah bermain");
            return false;
        }
    }
}