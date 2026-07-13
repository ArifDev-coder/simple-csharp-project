using System;
using System.Net.Mail;
using System.Text;

namespace SimpleEncryption.Libs;

/*
1. Loop tiap karakter di message
2. Cek jenis karakter (IsLower / IsUpper / lainnya) pakai if-else if-else
3. Kalau huruf, terapkan rumus geser (offset - kurangi - geser+modulo - tambah offset lagi)
    - Logika dasar
        2. ambil nilai ASCII nya
        3. kurangi dengan 97
        4. tambahkan dengan kunci
        5. modulo dengan panjang alphabet
        6. tambahkan dengan 97
        7. balikkan dengan huruf ASCII nya
4. Kalau bukan huruf, masukin apa adanya
5. Semua hasil dikumpulin pakai StringBuilder.Append(...)
6. Di akhir, ambil hasil final string-nya
*/

public class EncryptLibs
{
    public static string Encrypt(string msg, int key)
    {
        StringBuilder txt = new(msg.Length);
        int offset = 0;
        int AsciiResult = 0;

        foreach (char ch in msg)
        {
            if (char.IsLower(ch))
            {
                int atoi = ch;

                offset = 97;
                AsciiResult = ((atoi - offset + key) % 26) + offset;
                txt.Append((char)AsciiResult);
            }
            else if (char.IsUpper(ch))
            {
                int atoi = ch;

                offset = 65;
                AsciiResult = ((atoi - offset + key) % 26) + offset;
                txt.Append((char)AsciiResult);
            }
            else
            {
                txt.Append(ch);
            }
        }

        return txt.ToString();
    }

    public static string Decrypt(string msg, int key)
    {

        return msg;
    }
}