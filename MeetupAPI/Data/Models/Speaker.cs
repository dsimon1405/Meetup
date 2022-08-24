using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.Data.Models
{
    public class Speaker : IPerson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string OrganizationOrTopic { get; set; } = null!;


        [ForeignKey("MeetupId")]
        public Meetup Meetup { get; set; } = null!;
        public int MeetupId { get; set; }
    }
}