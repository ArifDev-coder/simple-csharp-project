using System;

class Program
{
    private static List<string> UserToDo = new List<string>();

    static void ShowSeparator()
    {
        Console.WriteLine(new string('=', 50));
    }

    static void ShowHeader()
    {
        Console.Clear();
        ShowSeparator();
        Console.WriteLine("\tAPLIKASI TO-DO LIST CONSOLE ");
        ShowSeparator();
        Console.WriteLine();
    }

    static void ShowMenu()
    {
        Console.WriteLine("\tPILIH MENU:");
        Console.WriteLine();
        Console.WriteLine("  1.  Tambah Tugas Baru");
        Console.WriteLine("  2.  Hapus Tugas");
        Console.WriteLine("  3.  Lihat Semua Tugas");
        Console.WriteLine("  Q.  Keluar Aplikasi");
        Console.WriteLine();
        ShowSeparator();
        Console.Write(" Masukkan pilihan Anda [1, 2, 3, Q]: ");
    }

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n ERROR: {message}");
        Console.ResetColor();
    }

    static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n {message}");
        Console.ResetColor();
    }

    static void ShowInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  {message}");
        Console.ResetColor();
    }

    static void Main()
    {
        while (true)
        {
            ShowHeader();
            ShowMenu();

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int usrOpt))
            {
                if (usrOpt == 1)
                {
                    ShowHeader();
                    Console.WriteLine(" TAMBAH TUGAS BARU\n");
                    Console.Write("Masukkan deskripsi tugas: ");
                    string newUserToDo = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(newUserToDo))
                    {
                        UserToDo.Add(newUserToDo);
                        ShowSuccess($"Tugas '{newUserToDo}' berhasil ditambahkan!");
                    }
                    else
                    {
                        ShowError("Tugas tidak boleh kosong!");
                    }
                    Console.WriteLine("\n(Tekan Enter untuk lanjut...)");
                    Console.ReadLine();
                }
                else if (usrOpt == 2)
                {
                    ShowHeader();
                    Console.WriteLine(" HAPUS TUGAS\n");

                    if (UserToDo.Count > 0)
                    {
                        Console.WriteLine(" DAFTAR TUGAS:");
                        Console.WriteLine();
                        for (int i = 0; i < UserToDo.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {UserToDo[i]}");
                        }
                        Console.WriteLine();
                        ShowSeparator();
                        Console.Write("Pilih nomor tugas yang ingin dihapus: ");

                        if (int.TryParse(Console.ReadLine(), out int userChoice))
                        {
                            try
                            {
                                string removedTask = UserToDo[userChoice - 1];
                                UserToDo.RemoveAt(userChoice - 1);
                                ShowSuccess($"Tugas '{removedTask}' berhasil dihapus!");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                ShowError("Nomor tugas tidak ditemukan! Silakan masukkan nomor yang benar.");
                            }
                        }
                        else
                        {
                            ShowError("Input tidak valid! Harap masukkan angka.");
                        }
                    }
                    else
                    {
                        ShowInfo("Anda belum memiliki tugas. Tambahkan tugas terlebih dahulu!");
                    }
                    Console.WriteLine("\n(Tekan Enter untuk lanjut...)");
                    Console.ReadLine();
                }
                else if (usrOpt == 3)
                {
                    ShowHeader();
                    Console.WriteLine(" DAFTAR TUGAS ANDA\n");

                    if (UserToDo.Count > 0)
                    {
                        Console.WriteLine($"Total Tugas: {UserToDo.Count}\n");
                        for (int i = 0; i < UserToDo.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {UserToDo[i]}");
                        }
                    }
                    else
                    {
                        ShowInfo("Anda belum memiliki tugas. Tambahkan tugas terlebih dahulu!");
                    }
                    Console.WriteLine();
                    Console.WriteLine("(Tekan Enter untuk lanjut...)");
                    Console.ReadLine();
                }
                else
                {
                    ShowError("Pilihan tidak valid! Silakan pilih [1, 2, atau 3].");
                    Console.WriteLine("\n(Tekan Enter untuk lanjut...)");
                    Console.ReadLine();
                }
            }
            else if (userInput.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                ShowHeader();
                Console.WriteLine(" Terima kasih telah menggunakan aplikasi ini!");
                Console.WriteLine();
                ShowSeparator();
                break;
            }
            else
            {
                ShowError("Input tidak valid! Harap masukkan angka [1, 2, 3] atau [Q] untuk keluar.");
                Console.WriteLine("\n(Tekan Enter untuk lanjut...)");
                Console.ReadLine();
            }
        }
    }
}
