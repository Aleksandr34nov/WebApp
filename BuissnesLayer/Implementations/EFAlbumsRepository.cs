using BuissnesLayer.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BuissnesLayer.Implementations
{
    class EFAlbumsRepository : IAlbumRepository
    {
        private ASContext context;
        public EFAlbumsRepository(ASContext context)
        {
            this.context = context;
        }
        public void SaveAlbum(Album item)
        {
            if (item.AlbumId == 0)
                context.Album.Add(item);
            else
                context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAlbum(Album item)
        {
            context.Album.Remove(item);
            context.SaveChanges();
        }

        public Album GetAlbumById(int Id, bool includeSongs = false)
        {
            if (includeSongs)
                return context.Set<Album>().Include(x => x.SongList).AsNoTracking().FirstOrDefault(x => x.AlbumId == Id);
            else
                return context.Album.FirstOrDefault(x => x.AlbumId == Id);
        }

        public IEnumerable<Album> GetAllAlbums(bool includeSongs = false)
        {
            if (includeSongs)
                return context.Set<Album>().Include(x => x.SongList).AsNoTracking().ToList();
            else
                return context.Album.ToList();
        }
    }
}
