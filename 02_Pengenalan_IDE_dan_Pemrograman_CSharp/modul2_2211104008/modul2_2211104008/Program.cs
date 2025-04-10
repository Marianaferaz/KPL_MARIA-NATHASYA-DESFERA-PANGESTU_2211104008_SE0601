using System;

class Program
{
    static void InputNama()
    {
        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine();
        Console.WriteLine($"Selamat datang, {nama}!");
    }

    // Untuk mencetak array dengan aturan yang sudah ditentukan
    static void PrintIndex()
    {
        int[] arr = new int[50];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0 && arr[i] % 3 == 0)
            {
                Console.WriteLine($"{arr[i]} #$#$");
            }
            else if (arr[i] % 2 == 0)
            {
                Console.WriteLine($"{arr[i]} ##");
            }
            else if (arr[i] % 3 == 0)
            {
                Console.WriteLine($"{arr[i]} $$");
            }
            else
            {
                Console.WriteLine(arr[i]);
            }
        }
    }

    // Mengecek apakah termasuk bilangan prima
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // Untuk meminta input angka dan memeriksa apakah prima
    static void CheckPrime()
    {
        Console.Write("Masukkan angka (1-10000): ");
        string input = Console.ReadLine();

        try
        {
            int angka = Convert.ToInt32(input);

            if (angka < 1 || angka > 10000)
            {
                Console.WriteLine("Angka harus antara 1 hingga 10000.");
            }
            else
            {
                if (IsPrime(angka))
                {
                    Console.WriteLine($"Angka {angka} merupakan bilangan prima.");
                }
                else
                {
                    Console.WriteLine($"Angka {angka} bukan merupakan bilangan prima.");
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Masukkan angka yang valid.");
        }
    }

    static void Main()
    {
        InputNama();
        PrintIndex();
        CheckPrime();
    }
}
