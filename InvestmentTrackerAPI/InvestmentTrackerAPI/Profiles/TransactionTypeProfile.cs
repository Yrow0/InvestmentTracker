using AutoMapper;
using InvestmentTrackerAPI.Models;
using InvestmentTrackerAPI.Responses.Type;

namespace InvestmentTrackerAPI.Profiles
{
    public class TransactionTypeProfile : Profile
    {
        IMapper _mapper;

        public TransactionTypeProfile(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TransactionTypeProfile()
        {
            CreateMap<Models.TransactionType, TransactionTypeResponse>();
        }
    }
}
