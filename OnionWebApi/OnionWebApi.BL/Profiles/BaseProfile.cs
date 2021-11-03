using AutoMapper;
using OnionWebApi.BL.Dtos;
using OnionWebApi.Models.Entities;

namespace OnionWebApi.Services.Profiles
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            #region Loans
            CreateMap<Loan, LoanDto>().ReverseMap();
            #endregion

            #region Users
            CreateMap<User, UsersDto>().ReverseMap();
            #endregion

            #region Payment
            CreateMap<Payment, PaymentDto>().ReverseMap();
            #endregion

            #region LoanPayment
            CreateMap<LoanPayment, LoanPaymentDto>().ReverseMap();
            #endregion
        }
    }
}
