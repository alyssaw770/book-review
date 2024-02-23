//Repository is a way to get our database calls
using BookReviewApp.Interfaces;

namespace BookReviewApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }


        public Book GetBook(int id)
        {
            //First or Default returns the first vaule with corresponding id
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBook(string name)
        {
            return _context.Books.Where(b => b.Name == name).FirstOrDefault();
        }

        public decimal GetBookRating(int bookId)
        {
            var review = _context.Reviews.Where(b => b.Book.Id == bookId);

            if(review.Count() <= 0)
                return 0;

                return (decimal)review.Sum(r => r.Rating)/review.Count();
        }

        public bool BookExists(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }

        public ICollection<Book> GetBooks()
        {
            //OrderBy is how we manipulate the data
            //ToList - explicit about what your are return; if you do not add this you will get a lot of errors
            return _context.Books.OrderBy(b => b.Id).ToList();
        }
    }
}