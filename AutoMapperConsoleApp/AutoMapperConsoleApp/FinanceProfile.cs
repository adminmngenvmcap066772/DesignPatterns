using AutoMapper;

namespace AutoMapperConsoleApp
{
    // AutoMapper profile for configuring mappings between domain and DTO classes
    // Place this class in the same namespace as the rest of your project for correct type resolution.
    public class FinanceProfile : Profile
    {
        public FinanceProfile()
        {
            // Map Transaction to TransactionDTO with custom member mappings
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.DateString, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));
        }
    }
}
