using AutoMapper;
using InvestmentTrackerAPI.Models;
using InvestmentTrackerAPI.Responses.Type;

namespace InvestmentTrackerAPI.Profiles
{
    public class TypeProfile : Profile
    {
        IMapper _mapper;

        public TypeProfile(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TypeProfile()
        {
            CreateMap<Models.Type, TypeResponse>();
        }
    }
}
