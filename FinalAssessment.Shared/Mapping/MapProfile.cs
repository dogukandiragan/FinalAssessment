using AutoMapper;
using FinalAssessment.Core.Models;
using FinalAssessment.Core.DTOs;

namespace FinalAssessment.Shared.Mapping
{
          public class MapProfile : Profile
        {
            public MapProfile()
            {
                CreateMap<UserAppDto,UserApp>().ReverseMap();
                CreateMap<TransactionDto, TransactionApp>().ReverseMap();
                CreateMap<CustomerDto, CustomerApp>().ReverseMap();
        }
        }
    }
