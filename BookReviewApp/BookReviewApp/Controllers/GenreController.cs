using AutoMapper;
using BookReviewApp.Dto;
using BookReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
        public IActionResult GetGenres()
        {
            //Make sure you add list => if not you will get an ambigious error
            var genres = _mapper.Map<List<GenreDto>>(_genreRepository.GetGenres());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(genres);
        }
        [HttpGet("{genreId}")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400)]
        public IActionResult GetGenre(int genreId)
        {
            if(!_genreRepository.GenreExists(genreId))
                return NotFound();

            var genre = _mapper.Map<GenreDto>(_genreRepository.GetGenre(genreId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(genre);
        }
        [HttpGet("book/{genreId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBookByCategory(int genreId)
        {
            var books = _mapper.Map<List<BookDto>>(_genreRepository.GetBookByGenre(genreId));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(books);
        }
    }
}