using BookManagement.Services.Contact.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Contact.Data.Configurations
{
    public class PersonContactConfiguration : IEntityTypeConfiguration<PersonContacts>
    {
        public void Configure(EntityTypeBuilder<PersonContacts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContactTypeId).IsRequired();

            builder.Property(x => x.Value).IsRequired();

            builder.ToTable("PersonContacts");
        }
    }
}
