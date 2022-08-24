using AutoMapper;
using MeetupAPI.Data.Models;
using MeetupAPI.View.ViewModels;

namespace MeetupAPI.View.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<IPerson, PersonViewModel>().ReverseMap();

            CreateMap<PersonViewModel, Organizer>();

            CreateMap<PersonViewModel, Speaker>();

            CreateMap<IPerson, string>().ConvertUsing(src => $"{src.FirstName} {src.LastName} : {src.OrganizationOrTopic}");
        }
    }
}
