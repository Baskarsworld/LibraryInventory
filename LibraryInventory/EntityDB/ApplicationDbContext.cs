using LibraryInventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.EntityDB
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreCongration());
            modelBuilder.ApplyConfiguration(new BookCongration());

            const string MANAGEBOOK_ROLE_ID = "b421e928-0613-9ebd-a64c-f10b6a706e73";

            // Add manageboook role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = MANAGEBOOK_ROLE_ID,
                Name = "ManageBook",
                NormalizedName = "ManageBook"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
