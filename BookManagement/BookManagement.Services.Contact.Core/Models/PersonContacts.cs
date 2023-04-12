namespace BookManagement.Services.Contact.Core.Models
{
    public class PersonContacts : IEntity
    {

        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }

        public virtual Persons Person { get; set; }
        public virtual ContactTypes ContactType { get; set; }
    }
}
