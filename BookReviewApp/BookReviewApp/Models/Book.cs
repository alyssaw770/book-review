namespace BookReviewApp;

public class Book
{
    public int Id {get; set; }
    public string Name {get; set; }

    public DateTime Release {get; set; }
    public ICollection<Review> Reviews { get; set; }
}
