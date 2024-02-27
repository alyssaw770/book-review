using AutoMapper;
using BookReviewApp.Dto;
using BookReviewApp.Interfaces;
using BookReviewApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers
{
    //These attributes is what makes this a controller
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        { 
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

//This get is returning a list 
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            //this is bringing all the code from our repository
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());

            //ModelState is a form of validation that makes sure we are submitting the correct data
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }
//This returns id
        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        //maker sure parameter matches HttpGet parameter or API will not work
        public IActionResult GetBook(int bookId)
        {
            if(!_bookRepository.BookExists(bookId))
                return NotFound();

            var book = _mapper.Map<BookDto>(_bookRepository.GetBook(bookId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(book);
        }

        [HttpGet("{bookId}/rating")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBookRating(int bookId)
        {
            if(!_bookRepository.BookExists(bookId))
                return NotFound();

            var rating = _bookRepository.GetBookRating(bookId);

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
    }
}