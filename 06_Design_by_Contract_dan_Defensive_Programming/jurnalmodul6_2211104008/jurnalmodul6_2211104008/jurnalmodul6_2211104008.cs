using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException("Judul video tidak boleh null atau kosong.");
        if (title.Length > 200)
            throw new ArgumentException("Judul video tidak boleh lebih dari 200 karakter.");

        this.title = title;
        this.id = new Random().Next(10000, 99999); // Generate ID 5 digit
        this.playCount = 0; // Initialize playCount to 0
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 25000000)
            throw new ArgumentException("Play count maksimal 25.000.000 per panggilan dan tidak boleh negatif.");

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

    public string Title => title;
    public int PlayCount => playCount;
}

class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentNullException("Username tidak boleh null atau kosong.");
        if (username.Length > 100)
            throw new ArgumentException("Username tidak boleh lebih dari 100 karakter.");

        this.username = username;
        this.id = new Random().Next(10000, 99999);
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
            total += video.PlayCount;
        return total;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
            throw new ArgumentNullException("Video tidak boleh null.");
        if (video.PlayCount > int.MaxValue)
            throw new OverflowException("Jumlah play count melebihi batas maksimum integer.");

        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount()
    {
        Console.WriteLine($"User: {username}");
        int maxPrint = Math.Min(8, uploadedVideos.Count); // Postcondition: maksimal print 8 video
        for (int i = 0; i < maxPrint; i++)
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].Title}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Maria Nathasya Desfera Pangestu");

            List<string> movieList = new List<string>
            {
                "Review Film Twilight oleh Maria",
                "Review Film The Hunger Games oleh Maria",
                "Review Film The Heirs oleh Maria",
                "Review Film Fast and Furious oleh Maria",
                "Review Film Elemental oleh Maria",
                "Review Film Beauty and The Beast oleh Maria",
                "Review Film Imitation oleh Maria",
                "Review Film La Casa De Papel oleh Maria",
                "Review Film Tell Me What You Saw oleh Maria",
                "Review Film Midnight Sun oleh Maria"
            };

            foreach (var title in movieList)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);

                // Do NOT increase play count, so it remains 0
                // video.IncreasePlayCount(12345; // Removed to keep play count at 0
            }

            user.PrintAllVideoPlayCount();
            Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");

            // Simulasi exception dengan loop untuk overflow play count
            try
            {
                SayaTubeVideo overflowVideo = new SayaTubeVideo("Video dengan playcount overflow");
                for (int i = 0; i < 10; i++)
                {
                    overflowVideo.IncreasePlayCount(int.MaxValue / 2);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow terjadi: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
        }

        Console.ReadKey();
    }
}
