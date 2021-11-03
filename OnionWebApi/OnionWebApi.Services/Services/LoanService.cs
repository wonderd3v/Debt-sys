using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionWebApi.BL.Dtos;
using OnionWebApi.Models.Contexts;
using OnionWebApi.Models.Entities;
using OnionWebApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionWebApi.Services.Services
{
    public interface ILoanService : IBaseService<Loan, LoanDto>
    {
        Task UpdateStatus(StatusOfLoan newState, int loanId);
    }
    public class LoanService : BaseServices<Loan, LoanDto>, ILoanService
    {
        public LoanService(BaseContext baseContext, IMapper mapper) : base(baseContext, mapper)
        { 
        }

        public override Task<LoanDto> Create(LoanDto dto)
        {

            dto.CreationDate = DateTime.Now;
            if (dto.Term == TermOfLoans.MonthlyPayment)
            {
                dto.NextPaymentDate = dto.CreationDate.AddMonths(1);
            }
            else if ( dto.Term == TermOfLoans.AnnualPayment )
            {
                dto.NextPaymentDate = dto.CreationDate.AddYears(1);
            }
            else {
                dto.NextPaymentDate = dto.CreationDate.AddDays(15);
            }

            return base.Create(dto);
        }

        public async Task UpdateStatus(StatusOfLoan newState, int loanId)
        {

            var entity = Query().Where(x => x.Id == loanId).FirstOrDefault();

            entity.Status = newState;

            await _context.SaveChangesAsync();
           
        }
    }
}
