using System;
using System.Collections.Generic;

namespace OnlineRadioDatabase_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var listOfSongs = new List<Song>();
            var totalMinutes = 0;
            var totalSeconds = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var timeTokens = input[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var minutes = 0;
                var seconds = 0;
                var ifMinParsed = int.TryParse(timeTokens[0], out minutes);
                var ifSecParsed = int.TryParse(timeTokens[1], out seconds);
                if (!ifMinParsed || !ifSecParsed)
                {
                    throw new ArgumentException("Invalid song length.");
                }

                try
                {
                    var song = new Song(input[0], input[1], input[2], minutes, seconds);
                    if (song.ValidSong == true)
                    {
                        listOfSongs.Add(song);
                        Console.WriteLine("Song added.");

                        totalMinutes += minutes;
                        totalSeconds += seconds;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Songs added: {listOfSongs.Count}");
            var playlistLength = totalMinutes * 60 + totalSeconds;
            var result = TimeSpan.FromSeconds(playlistLength);
            Console.WriteLine($"Playlist length: {result.Hours}h {result.Minutes}m {result.Seconds}s");
        }
    }
}
