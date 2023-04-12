namespace BookManagement.Services.Reporting.Core.Models
{
    public class Reports
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string Data { get; set; }
    }
}
