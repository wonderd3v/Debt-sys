using OnionWebApi.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionWebApi.BL.Dtos
{
    public class PaymentDto : BaseDto
    {
        public int? LoanId { get; set; }
        public string Voucher { get; set; }
        public DateTime? DateOfRealization { get; set; }
        public DateTime? StablishedDate { get; set; }
        public ICollection<LoanPaymentDto> LoanPayments { get; set; }
    }
}
