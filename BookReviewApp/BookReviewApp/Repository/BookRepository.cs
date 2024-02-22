//Repository is a way to get our database calls
using BookReviewApp.Inerfaces;

namespace BookReviewApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooks()
        {
            //OrderBy is how we manipulate the data
            //ToList - explicit about what your are return
            return _context.Books.OrderBy(b => b.Id).ToList();
        }
    }
}