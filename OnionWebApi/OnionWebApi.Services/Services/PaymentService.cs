using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionWebApi.BL.Dtos;
using OnionWebApi.Models.Contexts;
using OnionWebApi.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnionWebApi.Services.Services
{
    public interface IPaymentService : IBaseService<Payment, PaymentDto>
    {
    }
    public class PaymentService : BaseServices<Payment, PaymentDto>, IPaymentService
    {
        private readonly BaseContext _context;
        private readonly DbSet<Loan> _dbSet;
  

        public PaymentService(BaseContext baseContex, IMapper mapper) : base(baseContex, mapper)
        {
            _context = baseContex;
            _dbSet = _context.Set<Loan>();
        }

        public override Task<PaymentDto> Create(PaymentDto dto)
        {
            dto.DateOfRealization = DateTime.Now;
            var loanEntity = _dbSet.Where(x => x.Id == dto.LoanId).FirstOrDefault();

            loanEntity.PaymentsMade = loanEntity.PaymentsMade + 1;

            if (loanEntity.PaymentsMade == loanEntity.AmountOfPayments)
            {
                loanEntity.Status = StatusOfLoan.PaidOut;
            }
            
            return base.Create(dto);
        }
    }
}
