using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

class Program
{
    static Process? currentMpvProcess = null;

    static void Main(string[] args)
    {
        Random random = new Random();

        string userName = Environment.UserName;
        string folderPath = $"/home/{userName}/Videos/MotivationVideos/";
        string[] app = ["ghostty", "arduino-ide"];

        Console.WriteLine("Cek jumlah Video yang dimiliki!");

        var sortedFiles = Directory
            .EnumerateFiles(folderPath, "*.mp4", SearchOption.TopDirectoryOnly)
            .Select(filePath => new
            {
                Path = filePath,
                Name = Path.GetFileNameWithoutExtension(filePath),
            })
            .Where(file => Regex.IsMatch(file.Name, @"^\d+$")) // Pastikan nama hanya angka
            .Select(file => new { file.Path, Number = int.Parse(file.Name) }) // Ubah teks jadi angka asli
            .OrderBy(file => file.Number) // Urutkan: 1, 2, 3... bukan 1, 10, 2
            .Select(file => file.Path)
            .ToList();

        int amountOfVideos = sortedFiles.Count;

        if (amountOfVideos == 0)
        {
            Console.WriteLine(
                "Tidak ditemukan Video, Video wajib memiliki ektensi mp4 dan memiliki nama yang berurutan!"
            );
            Console.WriteLine("ex: 1.mp4 2.mp4 3.mp4 dll\nTerminate");

            return;
        }

        Console.WriteLine($"Ditemukan sebanyak {amountOfVideos} Videos");

        Console.WriteLine("Aplikasi berjalan di latar belakang...");

        List<int> currentPlayedVideo = new List<int>();

        while (true)
        {
            if (currentPlayedVideo.Count >= amountOfVideos)
            {
                currentPlayedVideo.Clear();
            }

            int whatCurrentVideoArePlayed;
            do
            {
                whatCurrentVideoArePlayed = random.Next(1, amountOfVideos + 1);
            }
            while (currentPlayedVideo.Contains(whatCurrentVideoArePlayed));

            bool isPlaying = currentMpvProcess != null && !currentMpvProcess.HasExited;

            if (!IsAppOpen(app) && !isPlaying)
            {
                Console.WriteLine($"Playing {whatCurrentVideoArePlayed}.mp4");

                currentPlayedVideo.Add(whatCurrentVideoArePlayed);

                ProcessStartInfo startInfo = new()
                {
                    FileName = "mpv",
                    Arguments = $"--fs \"{folderPath}{whatCurrentVideoArePlayed}.mp4\"",
                    UseShellExecute = true,
                };

                Console.WriteLine("Ayo bang lanjut jangan menyerah!!");
                currentMpvProcess = Process.Start(startInfo);

            }
            else
            {
                Console.WriteLine("Semangat jangan pantah menyerah!");
            }

            Thread.Sleep(60000);
        }
    }

    static bool IsAppOpen(string[] app)
    {
        // int amountOfAppsOpen = 0;

        // for (int i = 0; i < app.Length; i++)
        // {
        //     int process = Process.GetProcessesByName(app[i]).Length;

        //     amountOfAppsOpen += process;
        // }

        // return amountOfAppsOpen > 0;

        // Simple Version
        return app.Any(app => Process.GetProcessesByName(app).Length > 0);
    }

    static void CleanUp()
    {
        if (currentMpvProcess != null && !currentMpvProcess.HasExited)
        {
            Console.WriteLine("\nClean Up Mpv Process...");

            currentMpvProcess.Kill();
            currentMpvProcess.Dispose();
        }
    }
}
