﻿using MusicMarket.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(int id);
        Task<Artist> CreateArtist(Artist artist);
        Task<Artist> GetArtistByIdWithMusics(int id);
        Task DeleteArtist(Artist artist);
        Task UpdateArtist(Artist artistToBeUpdated, Artist artist);
    }
}
