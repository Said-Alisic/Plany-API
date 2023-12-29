using API.Common.Dto;
using API.Models;
using AutoMapper;

namespace API.Common.Helpers.AutoMapper;

public class CalendarEventMapperProfile : Profile
{
    public CalendarEventMapperProfile()
    {
        CreateMap<CalendarEvent, GetCalendarEventResponseDto>()
            .ForMember(dest => dest.EventParticipants, opt => opt.Ignore());
    }
}
