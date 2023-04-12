namespace BookManagement.Web.Models
{
    public class PersonContactDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }
    }
}
