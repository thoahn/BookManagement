using System.Collections.ObjectModel;

namespace BookManagement.Services.Contact.Core.Models
{
    public class Persons : IEntity
    {
        public Persons()
        {
            PersonContacts = new Collection<PersonContacts>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<PersonContacts> PersonContacts { get; set; }
    }
}
