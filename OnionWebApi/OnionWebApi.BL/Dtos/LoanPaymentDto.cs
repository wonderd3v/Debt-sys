using OnionWebApi.Services.Dtos;

namespace OnionWebApi.BL.Dtos
{
    public class LoanPaymentDto : BaseDto
    {
        public int LoanId { get; set; }
        public int PaymentId { get; set; }
    }
}