using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services.Contact.Core.DTO
{
    public class ReportDataDto
    {
        public string Location { get; set; }
        public int RegisteredPersonCount { get; set; }
        public int RegisteredPhoneNoCount { get; set; }
    }
}
