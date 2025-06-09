using System;

class Program
{
    static void Main()
    {
        // Menggunakan tiga angka dari dua digit NIM: 22, 11, dan 08
        int angka1 = 22;
        int angka2 = 11;
        int angka3 = 08;

        int hasil = Penjumlahan.JumlahTigaAngka(angka1, angka2, angka3);
        Console.WriteLine("NIM 2211104008");
        Console.WriteLine("Penjumlahan Tiga Angka dari NIM saya (22+11+08)");
        Console.WriteLine($"\nHasil penjumlahan: {hasil}");
    }
}
