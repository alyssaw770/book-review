using BookReviewApp.Inerfaces;
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
        public BookController(IBookRepository bookRepository)
        { 
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            //this is bringing all the code from our repository
            var books = _bookRepository.GetBooks();
            //ModelState is a form of validation that makes sure we are submitting the correct data
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }
    }
}