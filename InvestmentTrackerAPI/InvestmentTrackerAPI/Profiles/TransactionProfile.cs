using AutoMapper;
using InvestmentTrackerAPI.Models;
using InvestmentTrackerAPI.Requests.Transactions;
using InvestmentTrackerAPI.Responses.Transactions;

namespace InvestmentTrackerAPI.Mapper
{
    public class TransactionProfile : Profile
    {
        IMapper _mapper;

        public TransactionProfile(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TransactionProfile()
        {
            CreateMap<TransactionRequest, Transaction>();
            CreateMap<Transaction, TransactionResponse>();
        }
    }
}
