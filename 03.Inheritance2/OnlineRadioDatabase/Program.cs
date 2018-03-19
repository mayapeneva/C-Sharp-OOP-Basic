using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var songsList = new List<Song>();

        var songsNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < songsNumber; i++)
        {
            var input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var artistName = input[0];
            var songName = input[1];
            var time = input[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var minutes = 0;
                var ifMinParsed = int.TryParse(time[0], out minutes);
                var seconds = 0;
                var ifSecParsed = int.TryParse(time[1], out seconds);
                if (!ifMinParsed || !ifSecParsed)
                {
                    throw new ArgumentException("Invalid song length.");
                }

                var song = new Song(artistName, songName, minutes, seconds);
                songsList.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        Console.WriteLine($"Songs added: {songsList.Count}");
        var length = 0;
        foreach (var song in songsList)
        {
            length += song.Minutes * 60;
            length += song.Seconds;
        }

        TimeSpan playlistLength = TimeSpan.FromSeconds(length);
        Console.WriteLine($"Playlist length: {playlistLength.Hours}h {playlistLength.Minutes}m {playlistLength.Seconds}s");
    }
}