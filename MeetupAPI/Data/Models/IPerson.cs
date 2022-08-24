namespace MeetupAPI.Data.Models
{
    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationOrTopic { get; set; }
    }
}
