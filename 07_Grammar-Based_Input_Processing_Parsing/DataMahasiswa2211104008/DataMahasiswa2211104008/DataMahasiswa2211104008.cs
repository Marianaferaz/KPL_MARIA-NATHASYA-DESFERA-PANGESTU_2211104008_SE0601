using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

class DataMahasiswa2211104008
{
    public Nama Nama { get; set; }
    public long Nim { get; set; }
    public string Fakultas { get; set; }

    public void ReadJSON()
    {
        string filePath = "tp7_1_2211104008.json";

        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                // Parsing JSON ke Object
                DataMahasiswa2211104008 mahasiswa = JsonConvert.DeserializeObject<DataMahasiswa2211104008>(jsonData);

                if (mahasiswa != null)
                {
                    string namaDepan = mahasiswa.Nama.Depan;
                    string namaBelakang = mahasiswa.Nama.Belakang;
                    long nim = mahasiswa.Nim;
                    string fakultas = mahasiswa.Fakultas;

                    Console.WriteLine($"Nama {namaDepan} {namaBelakang} dengan NIM {nim} dari fakultas {fakultas}");
                }
                else
                {
                    Console.WriteLine("Deserialisasi gagal. Pastikan format JSON benar.");
                }
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan! Pastikan file berada di folder project.");
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: File tidak ditemukan: {e.Message}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Error: Gagal deserialisasi JSON: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: Terjadi kesalahan: {e.Message}");
        }
    }
}

public class Nama
{
    public string Depan { get; set; }
    public string Belakang { get; set; }
}
