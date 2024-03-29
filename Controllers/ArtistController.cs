﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.BL.IRepository;
using MusicAPI.DTOs;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArtistController(ILogger<ArtistController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetArtistes()
        {
            var artistes = await unitOfWork.Artists.GetAllAsync();
            var results = mapper.Map<IList<ArtistDTO>>(artistes);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetArtist")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await unitOfWork.Artists.GetAsync(q => q.Id == id, new List<string> { "Albums" });
            var result = mapper.Map<ArtistDTO>(artist);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistDTO artistDTO)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invaild Post Attempt for {nameof(CreateArtist)}");
                return BadRequest(ModelState);
            }
            var artist = mapper.Map<Artist>(artistDTO);
            await unitOfWork.Artists.AddAsync(artist);
            await unitOfWork.Save();
            return CreatedAtRoute("GetArtist", new { id = artist.Id }, artist);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] UpdateArtistDTO artistDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }
            var artist = await unitOfWork.Artists.GetAsync(q => q.Id == id);
            if (artist == null)
            {
                logger.LogError($"Invaild Update Attempt for {nameof(UpdateArtist)}");
                return BadRequest("Submitted is invaild");
            }
            mapper.Map(artistDTO, artist);
            unitOfWork.Artists.UpdateAsync(artist);
            await unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>DeleteArtist(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }
            var artist=await unitOfWork.Artists.GetAsync(q => q.Id == id);
            if (artist == null)
            {
                logger.LogError($"Invaild Delete Attempt for {nameof(DeleteArtist)}");
                return BadRequest("Submitted is invaild");
            }
            await unitOfWork.Artists.DeleteAsync(id);
            await unitOfWork.Save();
            return NoContent();
        }
    }
}
