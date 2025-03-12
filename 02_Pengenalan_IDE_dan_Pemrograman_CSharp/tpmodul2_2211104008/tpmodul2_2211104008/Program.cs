using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Bagian A: Menerima input huruf dan menentukan vokal atau konsonan
        Console.Write("Masukkan satu huruf: ");
        char huruf = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if ("AIUEO".Contains(huruf))
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf vokal");
        }
        else if (char.IsLetter(huruf))
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf konsonan");
        }
        else
        {
            Console.WriteLine("Input bukan huruf yang valid!");
        }

        // Bagian B: Membuat array bilangan genap dan menampilkan isi array
        int[] bilanganGenap = { 2, 4, 6, 8, 10 };

        for (int i = 0; i < bilanganGenap.Length; i++)
        {
            Console.WriteLine($"Angka genap {i + 1} : {bilanganGenap[i]}");
        }
    }
}
