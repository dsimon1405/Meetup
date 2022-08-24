using AutoMapper;
using MeetupAPI.Data.Models;

namespace MeetupAPI.View.Mapping
{
    public class PlanMapping : Profile
    {
        public PlanMapping()
        {
            CreateMap<Plan, string>().ConvertUsing(src => src.Item);

            CreateMap<string, Plan>().ConvertUsing(src => new Plan() { Item = src });
        }
    }
}
