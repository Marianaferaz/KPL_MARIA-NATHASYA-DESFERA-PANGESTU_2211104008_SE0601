using System;

class Program
{
    static void Main()
    {
        // Menggunakan tiga angka dari dua digit NIM: 22, 11, dan 08
        int angka1 = 22;
        int angka2 = 11;
        int angka3 = 08;

        // Create an instance of SimpleDataBase to store the numbers
        SimpleDataBase<int> database = new SimpleDataBase<int>();

        // Add numbers to the database
        database.AddNewData(angka1);
        database.AddNewData(angka2);
        database.AddNewData(angka3);

        // Calculate sum
        int hasil = Penjumlahan.JumlahTigaAngka(angka1, angka2, angka3);

        // Display results
        Console.WriteLine("NIM 2211104008");
        Console.WriteLine("Penjumlahan tiga input angka dari 2-digit NIM (22+11+08)");
        Console.WriteLine($"\n--- Hasil penjumlahan: {hasil} ---");

        // Print all stored data
        Console.WriteLine("Data yang tersimpan:");
        database.PrintAllData();
    }
}
