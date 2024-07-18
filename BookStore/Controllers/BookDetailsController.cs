using AutoMapper;
using BookStore.Services;
using BookStore.Dto;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore.Services.Imp;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookDetailService _bookDetailService;
        private readonly IAuthorService _authorService;

        public BookDetailsController(IBookDetailService bookDetailService, IAuthorService authorService, IMapper mapper)
        {
            _bookDetailService = bookDetailService;
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _bookDetailService.GetAllAsync());

        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] BookDetailsDto dto) 
        {
            var author = await _authorService.GetByIDAsync(dto.AuthorId);
            if (author == null)
                return BadRequest("Author isn't found");

            using var dataStream = new MemoryStream();
       
            await dto.BookImage.CopyToAsync(dataStream);

            var book=_mapper.Map<BookDetail>(dto);

            book.BookImage =  dataStream.ToArray();
            await _bookDetailService.AddAsync(book);
            _authorService.AddBookToAuthor(book.Author, book);
            return Ok(book);
        }



    }
}
