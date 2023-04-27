using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Model;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(DbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await dbContext.Musics.Include(m => m.Artist).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await dbContext.Musics.Include(m=>m.Artist).Where(x=>x.ArtistId == artistId).ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int Id)
        {
            return await dbContext.Musics.Include(x => x.Artist).SingleOrDefaultAsync(x => x.Id == Id);
        }
        private MusicMarketDbContext dbContext
        {
            get { return context as MusicMarketDbContext; }
        }
    }
}
