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
    public class GenreController : ControllerBase
    {
        private readonly ILogger<GenreController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GenreController(ILogger<GenreController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await unitOfWork.Genres.GetAllAsync();
            var results = mapper.Map<IList<GenreDTO>>(genres);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetGenre")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var genre = await unitOfWork.Genres.GetAsync(q => q.Id == id, new List<string> { "Albums" });
            var result = mapper.Map<GenreDTO>(genre);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDTO genreDTO)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invaild Post Attempt for {nameof(CreateGenre)}");
                return BadRequest(ModelState);
            }
            var genre = mapper.Map<Genre>(genreDTO);
            await unitOfWork.Genres.AddAsync(genre);
            await unitOfWork.Save();
            return CreatedAtRoute("GetGenre", new { id = genre.Id }, genre);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreDTO genreDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }
            var genre = await unitOfWork.Genres.GetAsync(q => q.Id == id);
            if (genre == null)
            {
                logger.LogError($"Invaild Update Attempt for {nameof(UpdateGenre)}");
                return BadRequest("Submitted is invaild");
            }
            mapper.Map(genreDTO, genre);
            unitOfWork.Genres.UpdateAsync(genre);
            await unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }
            var genre = await unitOfWork.Genres.GetAsync(q => q.Id == id);
            if (genre == null)
            {
                logger.LogError($"Invaild Delete Attempt for {nameof(DeleteGenre)}");
                return BadRequest("Submitted is invaild");
            }
            await unitOfWork.Genres.DeleteAsync(id);
            await unitOfWork.Save();
            return NoContent();
        }
    }
}
