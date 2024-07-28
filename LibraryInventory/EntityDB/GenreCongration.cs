using LibraryInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInventory.EntityDB
{
    public class GenreCongration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder
                .Property(g => g.Id)
                .IsRequired(true);
            builder
                .Property(g => g.Name)
            .IsRequired(true);

            builder
                .HasData(
                    new Genre
                    {
                        Id = 1,
                        Name = "Fiction"
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Romance"
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Action"
                    },
                    new Genre
                    {
                        Id = 4,
                        Name = "Mystery"
                    }
                );
        }
    }
}
