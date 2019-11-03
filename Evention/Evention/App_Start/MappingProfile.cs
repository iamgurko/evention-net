using AutoMapper;
using Evention.Controllers.Api;
using Evention.Core.Dtos;
using Evention.Core.Models;

namespace Evention.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}