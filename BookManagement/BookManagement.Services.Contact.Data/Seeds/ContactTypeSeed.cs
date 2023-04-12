using BookManagement.Services.Contact.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Contact.Data.Seeds
{
    public class ContactTypeSeed : IEntityTypeConfiguration<ContactTypes>

    {
        private readonly int[] _ids;

        public ContactTypeSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<ContactTypes> builder)
        {
            builder.HasData(
                  new ContactTypes { Id = _ids[0], Value = "Telefon No" }
                , new ContactTypes { Id = _ids[1], Value = "E-mail" }
                , new ContactTypes { Id = _ids[2], Value = "Konum" });
        }

    }
}
