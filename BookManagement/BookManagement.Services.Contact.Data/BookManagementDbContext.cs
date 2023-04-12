using BookManagement.Services.Contact.Core.Models;
using BookManagement.Services.Contact.Data.Configurations;
using BookManagement.Services.Contact.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.Contact.Data
{
    public class BookManagementDbContext : DbContext
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options) : base(options) { }

        public DbSet<Persons> Persons { get; set; }

        public DbSet<PersonContacts> PersonContacts { get; set; }

        public DbSet<ContactTypes> ContactTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new PersonContactConfiguration());

            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ContactTypeSeed(new int[] { 1, 2, 3 }));
        }
    }
}
