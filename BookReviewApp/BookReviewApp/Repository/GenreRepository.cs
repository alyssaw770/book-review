using BookReviewApp.Interfaces;

namespace BookReviewApp.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public bool GenreExists(int id)
        //context => code that sits on top of your database and gives you access to you database
        //Genres => we made within modles and datacontext
        //Any(bool)=> Determines whether any element of a sequence satisfies a condition.
        {
            return _context.Genres.Any(g => g.Id == id);
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
        public Genre GetGenre(int id)
        {
            return _context.Genres.Where(g => g.Id == id).FirstOrDefault();
        }
        public ICollection<Book> GetBookByGenre(int genreId)
        {
            //select is needed if you have nested entites/navigation properties b/c they do not load automatically; 
            //explictly tell EF to load it or it will not do it for you
            return _context.BookGenres.Where(g => g.BookId == genreId).Select(b => b.Book).ToList();
        }
    }
}