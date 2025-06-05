using AutoMapper;
using InvestmentTrackerAPI.Models;
using InvestmentTrackerAPI.Responses.Category;

namespace InvestmentTrackerAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        IMapper _mapper;

        public CategoryProfile(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CategoryProfile()
        {
            CreateMap<Category,CategoryResponse>();
        }
    }
}
