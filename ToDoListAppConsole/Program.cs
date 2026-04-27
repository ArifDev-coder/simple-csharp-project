using System;

class Program
{
    private List<string> UserToDo { get; set; } 
    private List<string> UserToDo2;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Tambah Tugas Baru.");
            Console.WriteLine("2. Hapus Tugas");
            Console.WriteLine("3. Melihat Semua Tugas");
            Console.WriteLine("Pilih opsi [1, 2, 3] atau keluar [q]");

            if (int.TryParse(Console.ReadLine(), out int usrOpt))
            {
                switch (usrOpt)
                {
                    case 1:
                        Console.WriteLine("Masukkan Tugas Baru");
                        string newUserToDo = Console.ReadLine;

                }
            }
        }
    }
}