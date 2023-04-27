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
    public class ArtistRepository: Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(DbContext context) : base(context) 
        {

        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await dbContext.Artists.Include(x=>x.Musics).ToListAsync();
        }

        public Task<Artist> GetWithMusicByIdAsync(int Id)
        {
            return dbContext.Artists.Include(x=>x.Musics).SingleOrDefaultAsync(x=>x.Id==Id);
        }
        private MusicMarketDbContext dbContext
        {
            get { return context as MusicMarketDbContext; }
        }
    }
}
