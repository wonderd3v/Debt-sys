using Microsoft.AspNetCore.Mvc;
using OnionWebApi.BL.Dtos;
using OnionWebApi.Models.Entities;
using OnionWebApi.Presentation.Controllers;
using OnionWebApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionWebApi.Controllers
{
    public class LoanController : BaseController<Loan, LoanDto>
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService) : base(loanService)
        {
            _loanService = loanService;
        }

        [HttpPut("UpdateStatus")]
       
        public async Task<IActionResult> UpdateStatus([FromHeader] StatusOfLoan newStatus, [FromHeader] int loanId)
        {
            var result = _loanService.UpdateStatus(newStatus, loanId);

            return Ok();
        }
    }
}
