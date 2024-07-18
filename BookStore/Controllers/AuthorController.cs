using AutoMapper;
using BookStore.Dto;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        private new List<string> _allowedExtenstions = new() { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1024 * 1024 * 5;

        public AuthorController(IAuthorService authorService,IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromForm] AuthorDto dto)
        {
            var author=_mapper.Map<Author>(dto);
            if (dto.ImageAuthor != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(dto.ImageAuthor.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed");

                if (_maxAllowedPosterSize < dto.ImageAuthor.Length)
                    return BadRequest("Max size 1 mb");

                using var dataStream = new MemoryStream();
                await dto.ImageAuthor.CopyToAsync(dataStream);

                author.ImageAuthor = dataStream.ToArray();
            }
            await _authorService.AddAsync(author);
            return Ok(author);

        }
        
        


        
        
    }
}
