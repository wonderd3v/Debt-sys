using OnionWebApi.Models.Entities;
using OnionWebApi.Models.Enums;
using OnionWebApi.Services.Dtos;
using System;
using System.Collections.Generic;

namespace OnionWebApi.BL.Dtos
{
    public class LoanDto : BaseDto
    {
        public double Amount { get; set; }   
        public DateTime CreationDate { get; set; }
        public int AmountOfPayments { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public int PaymentsMade { get; set; }

        public TermOfLoans Term { get; set; }
        public StatusOfLoan Status { get; set; }
        public int DebtorId { get; set; }
        public int CreditorId { get; set; }
    }
}
