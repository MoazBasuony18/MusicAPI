using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.BL.IRepository;
using MusicAPI.DTOs;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArtistController(ILogger<ArtistController>logger,IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetArtistes()
        {
            var artistes = await unitOfWork.Artists.GetAllAsync();
            var results=mapper.Map<IList<ArtistDTO>>(artistes);
            return Ok(results);
        }
    }
}
