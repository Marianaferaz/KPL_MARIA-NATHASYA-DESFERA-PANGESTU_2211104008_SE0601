using System;

namespace tpmodul5_2211104008
{
    public class HaloGeneric
    {
        public static void SapaUser<T>(T user)
        {
            Console.WriteLine($"Halo user {user}");
        }
    }

    public class DataGeneric<T>
    {
        private T data;

        public DataGeneric(T data)
        {
            this.data = data;
        }

        public void PrintData()
        {
            Console.WriteLine($"Data yang tersimpan adalah: {data}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Memanggil method generic
            HaloGeneric.SapaUser("Maria Nathasya");

            // Membuat objek DataGeneric dengan tipe string (NIM)
            DataGeneric<string> data = new DataGeneric<string>("2211104008");
            data.PrintData();
        }
    }
}
