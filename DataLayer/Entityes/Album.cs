using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class Album
    {
        public int AlbumId { get; set; }
        public List<Song> SongList { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public Album() { }

        public Album(List<Song> songs, int albumId = -1, string title = "", string artist = "")
        {
            AlbumId = albumId;
            SongList = songs;
            Title = title;
            Artist = artist;
        }
    }
}
