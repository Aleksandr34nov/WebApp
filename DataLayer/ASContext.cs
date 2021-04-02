using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore.Design;
using Domain;

namespace DataLayer
{
    public class ASContext : DbContext
    {
        public DbSet<Album> Album { get; set; }

        public DbSet<Song> Song { get; set; }

        public ASContext(DbContextOptions<ASContext> options) : base(options) { }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<ASContext>
    {
        public ASContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ASContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AlbumsSongsDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

            return new ASContext(optionsBuilder.Options);
        }
    }
}
