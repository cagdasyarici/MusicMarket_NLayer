using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Model;
using MusicMarket.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data
{
    public class MusicMarketDbContext:DbContext
    {
        public MusicMarketDbContext(DbContextOptions option):base (option) 
        {
        
        }
        
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
