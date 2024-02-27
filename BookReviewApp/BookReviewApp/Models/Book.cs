namespace BookReviewApp;

public class Book
{
    public int Id {get; set; }
    public string Name {get; set; }

    public DateTime Release {get; set; }

    //These navigation properties below are nested entites
    public ICollection<Review> Reviews { get; set; }
    public ICollection<BookAuthor> BookAuthors{ get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
}
