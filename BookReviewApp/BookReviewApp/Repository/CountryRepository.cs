using BookReviewApp.Interfaces;

namespace BookReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExits(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        
        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByAuthor(int authorId)
        {
            return _context.Authors.Where( a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
        }
    public ICollection<Author> GetAuthorsFromACountry(int countryId)
        {
            return _context.Authors.Where(c => c.Country.Id == countryId).ToList();
        }       
    }
}