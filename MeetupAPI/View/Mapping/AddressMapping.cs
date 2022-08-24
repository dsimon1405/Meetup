using AutoMapper;
using MeetupAPI.Data.Models;
using MeetupAPI.View.ViewModels;

namespace MeetupAPI.View.Mapping
{
    public class AddressMapping : Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();

            CreateMap<Address, string>().ConvertUsing(src => $"г.{src.City}, ул.{src.Street}, дом.{src.House}");
        }
    }
}
