using AutoMapper;
using MeetupAPI.Data.Models;
using MeetupAPI.View.ViewModels;

namespace MeetupAPI.View.Mapping
{
    public class MeetupMapping : Profile
    {
        public MeetupMapping()
        {
            CreateMap<Meetup, GetAllMeetupViewModel>()
                .ForMember(dst => dst.Plan, src => src.ConvertUsing<ToNumberedList<Plan>, List<Plan>>())
                .ForMember(dst => dst.Organizers, src => src.ConvertUsing<ToNumberedList<Organizer>, List<Organizer>>())
                .ForMember(dst => dst.Speakers, src => src.ConvertUsing<ToNumberedList<Speaker>, List<Speaker>>());

            CreateMap<GetByIdMeetupViewModel, Meetup>().ReverseMap();
        }
    }

    internal class ToNumberedList<T> : IValueConverter<List<T>, List<string>>
    {
        public List<string> Convert(List<T> sourceMember, ResolutionContext context)
        {
            List<string> list = context.Mapper.Map<List<string>>(sourceMember);

            for (int i = 0; i < sourceMember.Count; i++)
            {
                list[i] = $"{i + 1}. {list[i]}";
            }

            return list;
        }
    }
}
