using System;
using System.Collections.Generic;

namespace OnionWebApi.Models.Entities
{
    public class Payment : BaseEntity
    {
        public int? LoanId { get; set; }
        public string Voucher { get; set; }
        public DateTime? DateOfRealization { get; set; }
        public DateTime? StablishedDate { get; set; }
        public virtual ICollection<LoanPayment> LoanPayments { get; set; }
    }
}
