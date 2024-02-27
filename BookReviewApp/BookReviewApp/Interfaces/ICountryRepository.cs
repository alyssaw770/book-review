

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReviewApp.Interfaces
{
  public interface ICountryRepository
  {
    ICollection<Country> GetCountries();
    Country GetCountry(int id);
    Country GetCountryByAuthor(int authorId);
    ICollection<Author> GetAuthorsFromACountry(int countryId);
    bool CountryExits(int id);
  }
}