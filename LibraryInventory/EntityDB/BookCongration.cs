using LibraryInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibraryInventory.EntityDB
{
    public class BookCongration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder
                .Property(g => g.Id)
                .IsRequired(true);
            builder
               .Property(g => g.Title)
               .IsRequired(true);
            builder
                .Property(g => g.AuthorFirstName)
                .IsRequired(true);
            builder
               .Property(g => g.AuthorLastName)
               .IsRequired(true);
            builder
              .Property(g => g.PublishDate)
              .IsRequired(false);
            builder
             .Property(g => g.DateAdded)
             .IsRequired(false);
            builder
             .Property(g => g.NumberInStock)
             .IsRequired(false);
            builder
           .Property(g => g.NumberAvailable)
           .IsRequired(false);
            builder
           .Property(g => g.GenreId)
            .IsRequired(true);

            builder
                .HasData(
                    new Book
                    {
                        Id = 1,
                        GenreId = 1,
                        Title = "A Life Less Punishing",
                        AuthorFirstName = "Matt",
                        AuthorLastName = "Heath",
                        PublishDate = DateTime.Parse("1-1-1990"),
                        DateAdded = DateTime.Now,
                        NumberInStock = 10
                    },
                     new Book
                     {
                         Id = 2,
                         GenreId = 2,
                         Title = "RecipeTin Eats: Dinner",
                         AuthorFirstName = "Nagi",
                         AuthorLastName = "Maehashi",
                         PublishDate = DateTime.Parse("2-2-2000"),
                         DateAdded = DateTime.Now,
                         NumberInStock = 9
                     },
                    new Book
                    {
                        Id = 3,
                        GenreId = 3,
                        Title = "Atomic Habits",
                        AuthorFirstName = "James",
                        AuthorLastName = "Clear",
                        PublishDate = DateTime.Parse("3-3-2010"),
                        DateAdded = DateTime.Now,
                        NumberInStock = 8
                    },
                    new Book
                    {
                        Id = 4,
                        GenreId = 4,
                        Title = "Baby Food Bible",
                        AuthorFirstName = "Julia ",
                        AuthorLastName = "Tellidis",
                        PublishDate = DateTime.Parse("4-4-2020"),
                        DateAdded = DateTime.Now,
                        NumberInStock = 7
                    },
                    new Book
                    {
                        Id = 5,
                        GenreId = 1,
                        Title = "The Life of Dai",
                        AuthorFirstName = "Dai",
                        AuthorLastName = "Henwood",
                        PublishDate = DateTime.Parse("5-5-2021"),
                        DateAdded = DateTime.Now,
                        NumberInStock = 5
                    }
                );
        }
    }
}
