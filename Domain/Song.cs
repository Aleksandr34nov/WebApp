﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public Song(int songId = -1, string song_Title = "", int albumId = -1)
        {
            SongTitle = song_Title;
            SongId = songId;
            AlbumId = albumId;
        }
    }
}
