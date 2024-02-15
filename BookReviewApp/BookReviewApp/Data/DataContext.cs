using Microsoft.EntityFrameworkCore;

namespace BookReviewApp;

public class DataContext : DbContext
{
    //base is pushing data that is being recevied from an outside class into the DbContext -> entity framework core
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    //tell the context what all our tables/models are
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }

    //OnModelCreating is how you go in to customize tables without having to go into the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });
        modelBuilder.Entity<BookGenre>()
            .HasOne(b => b.Book)
            .WithMany(bg => bg.BookGenres)
            .HasForeignKey(b => b.BookId);
        modelBuilder.Entity<BookGenre>()
            .HasOne(b => b.Genre)
            .WithMany(bg => bg.BookGenres)
            .HasForeignKey(g => g.GenreId);

        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });
        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Book)
            .WithMany(ba => ba.BookAuthors)
            .HasForeignKey(b => b.BookId);
        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Author)
            .WithMany(ba => ba.BookAuthors)
            .HasForeignKey(g => g.AuthorId);
    }
}