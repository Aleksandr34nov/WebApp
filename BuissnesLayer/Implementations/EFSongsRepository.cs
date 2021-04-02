using BuissnesLayer.Interfaces;
using DataLayer;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implementations
{
    class EFSongsRepository : ISongRepository
    {
        private ASContext context;
        public EFSongsRepository(ASContext context)
        {
            this.context = context;
        }
        public void SaveSong(Song item)
        {
            if (item.SongId == 0)
                context.Song.Add(item);
            else
                context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteSong(Song item)
        {
            context.Song.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<Song> GetAllSongs(bool includeAlbum = false)
        {
            if (includeAlbum)
                return context.Set<Song>().Include(x => x.Album).AsNoTracking().ToList();
            else
                return context.Song.ToList();
        }

        public Song GetSongById(int Id, bool includeAlbum = false)
        {
            if (includeAlbum)
                return context.Set<Song>().Include(x => x.Album).AsNoTracking().FirstOrDefault(x => x.SongId == Id);
            else
                return context.Song.FirstOrDefault(x => x.SongId == Id);
        }
    }
}
