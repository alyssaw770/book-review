namespace BookReviewApp.Interfaces
{
    public interface IGenreRepository
    {
        //plural => returning collection
        ICollection<Genre> GetGenres();

        //Singular => returning the actual genre (1 of the entity)
        Genre GetGenre(int id);
        ICollection<Book> GetBookByGenre(int GenreId);
        bool GenreExists(int id);
    }
}