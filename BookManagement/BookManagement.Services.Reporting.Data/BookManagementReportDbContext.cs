using BookManagement.Services.Reporting.Core.Models;
using BookManagement.Services.Reporting.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.Reporting.Data
{
    public class BookManagementReportDbContext : DbContext
    {
        public BookManagementReportDbContext(DbContextOptions<BookManagementReportDbContext> options) : base(options){}

        public DbSet<Reports> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportsConfiguration());
        }
    }
}
