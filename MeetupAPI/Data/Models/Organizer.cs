using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetupAPI.Data.Models
{
    public class Organizer : IPerson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required, Column("Organization")]
        public string OrganizationOrTopic { get; set; } = null!;


        [ForeignKey("MeetupId")]
        public Meetup Meetup { get; set; } = null!;
        public int MeetupId { get; set; }
    }
}