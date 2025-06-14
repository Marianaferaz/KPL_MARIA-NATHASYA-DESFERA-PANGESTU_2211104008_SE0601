using System;

public class GreetingService
{
    public static void GreetUser<T>(T user)
    {
        Console.WriteLine($"Halo user {user}");
    }
}

public class GenericData<T>
{
    private readonly T _data;

    public GenericData(T data)
    {
        _data = data;
    }

    public void PrintData()
    {
        Console.WriteLine($"Data yang tersimpan adalah: {_data}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Memanggil method untuk menyapa pengguna
        GreetingService.GreetUser("Maria Nathasya");

        // Membuat objek GenericData dengan tipe string (NIM)
        var nimData = new GenericData<string>("2211104008");
        nimData.PrintData();
    }
}
