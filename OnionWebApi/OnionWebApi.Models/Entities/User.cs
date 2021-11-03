

using System.Collections.Generic;

namespace OnionWebApi.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Dni { get; set; } 
        public virtual ICollection<Loan> DebtorLoans { get; set; }
        public virtual ICollection<Loan> CreditorLoans { get; set; }
    }
}
