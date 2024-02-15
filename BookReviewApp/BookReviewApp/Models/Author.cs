﻿namespace BookReviewApp;

public class Author
{
    public int Id {get; set; }
    public string FirstName {get; set; }
    public string LastName { get; set; }

    public string Publisher {get; set; }
    public Country Country { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
}
