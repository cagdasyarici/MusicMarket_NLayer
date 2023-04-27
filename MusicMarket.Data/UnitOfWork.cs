using MusicMarket.Core;
using MusicMarket.Core.Repositories;
using MusicMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicMarketDbContext _context;
        private IMusicRepository _musicRepository;
        private IArtistRepository _artistRepository;

        public UnitOfWork(MusicMarketDbContext context)
        {
            _context = context;
        }

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);
        public IArtistRepository Artists => _artistRepository;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
