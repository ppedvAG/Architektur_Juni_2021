using Microsoft.EntityFrameworkCore;
using ppedv.Musicplayer.Model;
using System;

namespace ppedv.Musicplayer.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MusicplayerDB_dev;Trusted_Connection=true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
