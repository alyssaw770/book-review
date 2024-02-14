﻿namespace BookReviewApp;

public class Author
{
    public int Id {get; set; }
    public string Name {get; set; }

    public string Publisher {get; set; }
    public Country Country { get; set; }
}
