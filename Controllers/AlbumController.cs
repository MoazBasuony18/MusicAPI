using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.BL.IRepository;
using MusicAPI.DTOs;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AlbumController(ILogger<AlbumController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await unitOfWork.Albums.GetAllAsync();
            var results = mapper.Map<IList<AlbumDTO>>(albums);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetAlbum")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            var album = await unitOfWork.Albums.GetAsync(q => q.Id == id);
            var result = mapper.Map<AlbumDTO>(album);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumDTO albumDTO)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invaild Post Attempt for {nameof(CreateAlbum)}");
                return BadRequest(ModelState);
            }
            var album = mapper.Map<Album>(albumDTO);
            await unitOfWork.Albums.AddAsync(album);
            await unitOfWork.Save();
            return CreatedAtRoute("GetAlbum", new { id = album.Id }, album);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAlbum(int id, [FromBody] UpdateAlbumDTO albumDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }
            var album = await unitOfWork.Albums.GetAsync(q => q.Id == id);
            if (album == null)
            {
                logger.LogError($"Invaild Update Attempt for {nameof(UpdateAlbum)}");
                return BadRequest("Submitted is invaild");
            }
            mapper.Map(albumDTO, album);
            unitOfWork.Albums.UpdateAsync(album);
            await unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }
            var album = await unitOfWork.Albums.GetAsync(q => q.Id == id);
            if (album == null)
            {
                logger.LogError($"Invaild Delete Attempt for {nameof(DeleteAlbum)}");
                return BadRequest("Submitted is invaild");
            }
            await unitOfWork.Genres.DeleteAsync(id);
            await unitOfWork.Save();
            return NoContent();
        }
    }
}
