using System;

namespace OnlineRadioDatabase_EXER
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string songLength;
        private bool validSong;

        public Song(string artistName, string songName, string songLength, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongLength = songLength;
            this.ValidSong = true;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    validSong = false;
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    validSong = false;
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }

                this.songName = value;
            }
        }

        public string SongLength
        {
            get { return this.songLength; }
            private set
            {
                var minutes = int.Parse(value.Split(':')[0]);
                if (minutes < 0 || minutes > 14)
                {
                    validSong = false;
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }

                var seconds = int.Parse(value.Split(':')[1]);
                if (seconds < 0 || seconds > 59)
                {
                    validSong = false;
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }

                this.songLength = value;
            }
        }

        public bool ValidSong
        {
            get { return this.validSong; }
            private set
            {
                if (!value)
                {
                    throw new ArgumentException("Invalid song.");
                }

                this.validSong = value;
            }
        }
    }
}