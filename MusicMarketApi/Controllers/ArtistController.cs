using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.Core.Model;
using MusicMarket.Core.Services;
using MusicMarketApi.DTO;
using MusicMarketApi.Validator;

namespace MusicMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtist()
        {
            var artists = await _artistService.GetAllArtists();
            var artistResources = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDTO>>(artists);
            return Ok(artistResources);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtist()
        {
            var artists = await _artistService.GetAllArtists();
            var artistResources = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDTO>>(artists);
            return Ok(artistResources);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistById(id);
            var artistResources = _mapper.Map<Artist,ArtistDTO>(artist);
            return Ok(artistResources);
        }

        [HttpPost]
        public async Task<ActionResult<ArtistDTO>> CreateArtist(SaveArtistDTO saveArtistDTO)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var artistToCreate = _mapper.Map<SaveArtistDTO,Artist>(saveArtistDTO);
            var newArtist = await _artistService.CreateArtist(artistToCreate);
            var artist = await _artistService.GetArtistById(newArtist.Id);
            var artistRes = _mapper.Map<Artist,ArtistDTO>(artist);
            return Ok(artistRes);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var artist = await _artistService.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }
            await _artistService.DeleteArtist(artist);
            return NoContent(); 
        }

        [HttpPut]
        public async Task<ActionResult<MusicDTO>> UpdateArtist(int id, SaveArtistDTO saveArtistRes)
        {
            var validator = new SaveArtistResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveArtistRes);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }
            var artistToUpdate = await _artistService.GetArtistById(id);
            if (artistToUpdate == null)
                return NotFound();
            var artist = _mapper.Map<SaveArtistDTO, Artist>(saveArtistRes);
            await _artistService.UpdateArtist(artistToUpdate,artist);
            var updatedArtist = await _artistService.GetArtistById(id);
            var updatedArtistRes =_mapper.Map<Artist,ArtistDTO>(updatedArtist);
            return Ok(updatedArtistRes);
        }
    }
}
