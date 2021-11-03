using OnionWebApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnionWebApi.Models.Entities
{
    public class Loan : BaseEntity
    {
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public int AmountOfPayments { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public int? PaymentsMade { get; set; }
        public TermOfLoans Term { get; set; }
        public StatusOfLoan Status { get; set; }
        public int DebtorId { get; set; }
        public int CreditorId { get; set; }
        [ForeignKey("DebtorId")]
        public virtual User Debtor { get; set; }
        [ForeignKey("CreditorId")]
        public virtual User Creditor { get; set; }
        public virtual ICollection<LoanPayment> LoanPayments { get; set; }
    }
}
