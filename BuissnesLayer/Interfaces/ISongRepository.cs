using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface ISongRepository
    {
        public IEnumerable<Song> GetAllSongs(bool includeMaterials = false);
        public Song GetSongById(int directoryId, bool includeMaterials = false);
        public void SaveSong(Song item);
        public void DeleteSong(Song item);
    }
}
