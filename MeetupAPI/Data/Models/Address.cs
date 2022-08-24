using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetupAPI.Data.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Meetup")]
        public int Id { get; set; }

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Street { get; set; } = null!;

        [Required]
        public int House { get; set; }


        public Meetup Meetup { get; set; } = null!;
    }
}