using AutoMapper;
using System.Globalization;

namespace MeetupAPI.View.Mapping
{
    public class DateTimeMapping : Profile
    {
        public DateTimeMapping()
        {
            CreateMap<DateTime, string>().ConvertUsing<DateTimeToStrngConverter>();

            CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();
        }
    }

    internal class StringToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return DateTime.Parse(source, CultureInfo.GetCultureInfo("de-DE"));
        }
    }

    internal class DateTimeToStrngConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("g", CultureInfo.GetCultureInfo("de-DE"));
        }
    }
}
