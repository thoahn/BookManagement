using BookManagement.Services.Contact.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Services.Contact.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Company).HasMaxLength(250);

            builder.ToTable("Persons");
        }
    }
}
