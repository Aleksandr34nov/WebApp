using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IAlbumRepository
    {
        public IEnumerable<Album> GetAllAlbums(bool includeMaterials = false);
        public Album GetAlbumById(int directoryId, bool includeMaterials = false);
        public void SaveAlbum(Album item);
        public void DeleteAlbum(Album item);
    }
}
