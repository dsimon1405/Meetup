namespace MeetupAPI.View.ViewModels
{
    public class GetAllMeetupViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Topic { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DateTime { get; set; } = null!;

        public string Address { get; set; } = null!;

        public List<string> Plan { get; set; } = null!;

        public List<string> Organizers { get; set; } = null!;

        public List<string> Speakers { get; set; } = null!;
    }
}
