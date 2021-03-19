using AutoMapper;
using NanoSurvey.API.DTOs;
using NanoSurvey.Application.Entities;

namespace NanoSurvey.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuestionAnswersDTO, Question>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Question.Id))
                .ForMember(dest => dest.Title, o => o.MapFrom(src => src.Question.Title))
                .ReverseMap();

            CreateMap<ResultDTO, Result>().ReverseMap();
        }
    }
}
