namespace BookReviewApp.Inerfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
    }
}