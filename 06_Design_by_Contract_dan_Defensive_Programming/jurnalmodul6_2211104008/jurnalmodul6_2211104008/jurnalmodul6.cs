using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private int id;
    public string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random rand = new Random();
        this.title = title;
        this.id = rand.Next(10000, 99999); // Generate ID 5 digit
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 20000000)
            throw new ArgumentException("Play count harus positif dan maksimal 20.000.000 jumlahnya");

        checked
        {
            this.playCount += count;
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Judul: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }

    // Untuk mengakses title (getter)
    public string Title
    {
        get { return title; }
    }

 
    public int PlayCount // Properti untuk mengakses playCount
    {
        get { return playCount; }
    }
}

class SayaTubeUser
{
    private int id;
    public string Username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        Random rand = new Random();
        this.Username = username;
        this.id = rand.Next(10000, 99999); // Generate ID 5 digit
        this.uploadedVideos = new List<SayaTubeVideo>(); // Perbaikan: Inisialisasi List
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
            total += video.PlayCount; // Menggunakan properti PlayCount
        return total;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
            throw new ArgumentNullException("Video tidak bisa jika null");
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {Username}");
        for (int i = 0; i < Math.Min(8, uploadedVideos.Count); i++)
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].Title}"); // Perbaikan: Gunakan properti Title
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user = new SayaTubeUser("MariaNathasya");

        List<string> movieList = new List<string>
        {
            "Movie Review by MariaNathasya: Twilight",
            "Movie Review by MariaNathasya: The Hunger Games",
            "Movie Review by MariaNathasya: The Heirs",
            "Movie Review by MariaNathasya: Fast and Furious",
            "Movie Review by MariaNathasya: Elemental",
            "Movie Review by MariaNathasya: Beauty and The Beast",
            "Movie Review by MariaNathasya: Imitation",
            "Movie Review by MariaNathasya: La Casa De Papel",
            "Movie Review by MariaNathasya: Midnight Sun",
            "Movie Review by MariaNathasya: Tell Me What You Saw"
        };

        // Variabel untuk menyimpan pesan error
        string errorMessage = null;

        foreach (var title in movieList)
        {
            SayaTubeVideo video = new SayaTubeVideo(title);
            user.AddVideo(video);
            try
            {
                video.IncreasePlayCount(new Random().Next(1, 10000)); // Simulasi play count acak
            }
            catch (ArgumentException ex)
            {
                errorMessage = $"Error pada video '{title}': {ex.Message}";
            }
        }

        user.PrintAllVideoPlaycount();
        Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");

        // Tampilkan pesan error (jika ada) setelah total play count
        if (errorMessage != null)
        {
            Console.WriteLine(errorMessage);
        }

        // Tambahan: Contoh penanganan exception (dipindahkan ke akhir)
        try
        {
            SayaTubeVideo invalidVideo = new SayaTubeVideo("Video dengan playcount invalid");
            invalidVideo.IncreasePlayCount(30000000); // Melebihi batas
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.ReadKey(); // Agar console tidak langsung menutup
    }
}
