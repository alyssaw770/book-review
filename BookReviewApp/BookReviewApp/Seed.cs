// using BookReviewApp.Data;
// using BookReviewApp.Models;

namespace BookReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.BookAuthors.Any())
            {
                var BookAuthors = new List<BookAuthor>()
                {
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Name = "A Court of Thorns and Roses",
                            Release = new DateTime(2015,5,5),
                            BookGenres = new List<BookGenre>()
                            {
                                new BookGenre { Genre = new Genre() { Name = "Fantasy"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="A Court of Thorns and Roses",Text = "A Court of Thorns and Roses is the best book, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="A Court of Thorns and Roses", Text = "A Court of Thorns and Roses is the best at story telling", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="A Court of Thorns and Roses",Text = "A Court of Thorns and Roses, A Court of Thorns and Roses, A Court of Thorns and Roses", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Author = new Author()
                        {
                            FirstName = "Sarah J",
                            LastName = "Mass",
                            Publisher = "Bloomsbury Publishing",
                            Country = new Country()
                            {
                                Name = "United States of America"
                            }
                        }
                    },
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Name = "Romantic Comedy",
                            Release = new DateTime(2023,4,4),
                            BookGenres = new List<BookGenre>()
                            {
                                new BookGenre { Genre = new Genre() { Name = "Romance"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Romantic Comedy", Text = "Romantic Comedy is the best Book, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Romantic Comedy",Text = "Romantic Comedy is the best at story telling", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Romantic Comedy", Text = "Romantic Comedy, Romantic Comedy, Romantic Comedy", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Author = new Author()
                        {
                            FirstName = "Curtis",
                            LastName = "Sittenfeld",
                            Publisher = "Random House",
                            Country = new Country()
                            {
                                Name = "United States of America"
                            }
                        }
                    },
                                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Name = "Fourth Wing",
                            Release = new DateTime(2023,4,5),
                            BookGenres = new List<BookGenre>()
                            {
                                new BookGenre { Genre = new Genre() { Name = "Fantasy"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Fourth Wing",Text = "Fourth Wing is the best Book, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Fourth Wing",Text = "Fourth Wing is the best at story telling", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Fourth Wing",Text = "Fourth Wing, Fourth Wing, Fourth Wing", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Author = new Author()
                        {
                            FirstName = "Rebecca",
                            LastName = "Yarros",
                            Publisher = "Entangled: Red Tower Books",
                            Country = new Country()
                            {
                                Name = "United States of America"
                            }
                        }
                    }
                };
                dataContext.BookAuthors.AddRange(BookAuthors);
                dataContext.SaveChanges();
            }
        }
    }
}
