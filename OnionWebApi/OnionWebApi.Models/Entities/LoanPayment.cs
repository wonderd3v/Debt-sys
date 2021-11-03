using System;
using System.Collections.Generic;
using System.Text;

namespace OnionWebApi.Models.Entities
{
    public class LoanPayment : BaseEntity
    {
        public int LoanId { get; set; }
        public int PaymentId { get; set; }
    }
}
