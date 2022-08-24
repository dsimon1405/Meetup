using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.Data.Models
{
    public class Meetup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Topic { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime DateTime { get; set; }


        public Address Address { get; set; } = null!;
        public List<Plan> Plan { get; set; } = null!;
        public List<Organizer> Organizers { get; set; } = null!;
        public List<Speaker> Speakers { get; set; } = null!;
    }
}
