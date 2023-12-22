using System;
using System.Collections.Generic;
using System.Text;

namespace Rudas16.Model
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public Song()
        {
            // Constructor vacío
        }

        public Song(string title, string artist, string duration, DateTime releaseDate, string imageUrl)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            ReleaseDate = releaseDate;
            ImageUrl = imageUrl;
        }
    }

    public class MusicApiResponse
    {
        public List<Song> songs { get; set; }
    }
}
