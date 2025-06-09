using System;

class Penjumlahan
{
    public static T JumlahTigaAngka<T>(T angka1, T angka2, T angka3)
    {
        dynamic a = angka1, b = angka2, c = angka3;
        return (T)(a + b + c);
    }
}
