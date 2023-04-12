using BookManagement.Services.Contact.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Services.Contact.Data.Configurations
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactTypes>
    {
        public void Configure(EntityTypeBuilder<ContactTypes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Value).IsRequired().HasMaxLength(50);

            builder.ToTable("ContactTypes");
        }
    }
}
